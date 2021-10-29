using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;

namespace OnionAuthGen
{
    /// <summary>
    /// Provides PBKDF2 key derivation function from unmanaged windows API
    /// </summary>
    /// <remarks>
    /// This is massively faster than the .NET internal mechanism
    /// </remarks>
    public static class UnmanagedPBKDF2
    {
        /// <summary>
        /// Flags for BCrypt functions
        /// </summary>
        private enum BCryptFlags : int
        {
            /// <summary>
            /// No flags
            /// </summary>
            NO_FLAGS = 0,
            /// <summary>
            /// Hash provider operates in HMAC mode
            /// </summary>
            BCRYPT_ALG_HANDLE_HMAC_FLAG = 0x8
        }

        /// <summary>
        /// Derive a key using PBKDF2
        /// </summary>
        /// <param name="hAlgorithm">Algorithm opened using <see cref="BCryptOpenAlgorithmProvider"/></param>
        /// <param name="pbPassword">Private piece of key material</param>
        /// <param name="cbPassword">Byte length of <paramref name="pbPassword"/></param>
        /// <param name="pbSalt">Public piece of key material</param>
        /// <param name="cbSalt">Byte length of <paramref name="pbSalt"/></param>
        /// <param name="cIterations">Number of iterations</param>
        /// <param name="pbDerivedKey">Memory to hold derived bytes</param>
        /// <param name="cbDerivedKey">Length of <paramref name="pbDerivedKey"/></param>
        /// <param name="dwFlags">Reserved. Must be <see cref="BCryptFlags.NO_FLAGS"/></param>
        /// <returns>NT status</returns>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/nf-bcrypt-bcryptderivekeypbkdf2"/>
        [DllImport("Bcrypt.dll")]
        private static extern int BCryptDeriveKeyPBKDF2(
            IntPtr hAlgorithm,
            byte[] pbPassword,
            int cbPassword,
            byte[] pbSalt,
            int cbSalt,
            long cIterations,
            [Out]
            byte[] pbDerivedKey,
            int cbDerivedKey,
            BCryptFlags dwFlags
            );

        /// <summary>
        /// Opens a BCrypt algorithm
        /// </summary>
        /// <param name="phAlgorithm">Pointer to algorithm</param>
        /// <param name="pszAlgId">Algorithm name</param>
        /// <param name="pszImplementation">Implementation name. <see cref="null"/> for default</param>
        /// <param name="dwFlags">Algorithm flags</param>
        /// <returns>NT status</returns>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider"/>
        [DllImport("Bcrypt.dll")]
        private static extern int BCryptOpenAlgorithmProvider(
            out IntPtr phAlgorithm,
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszAlgId,
            [MarshalAs(UnmanagedType.LPWStr)]
            string pszImplementation,
            BCryptFlags dwFlags
            );

        /// <summary>
        /// Closes algorithm that was opened with <see cref="BCryptOpenAlgorithmProvider(out IntPtr, string, string, BCryptFlags)"/>
        /// </summary>
        /// <param name="phAlgorithm">Algorithm handle</param>
        /// <param name="dwFlags">Must be <see cref="BCryptFlags.NO_FLAGS"/></param>
        /// <returns>NT status</returns>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/nf-bcrypt-bcryptclosealgorithmprovider"/>
        [DllImport("Bcrypt.dll")]
        private static extern int BCryptCloseAlgorithmProvider(
            IntPtr phAlgorithm,
            BCryptFlags dwFlags
            );

        /// <summary>
        /// Derives a key using PBKDF2
        /// </summary>
        /// <param name="Key">Password</param>
        /// <param name="Salt">Salt</param>
        /// <param name="Iterations">Iteration count</param>
        /// <param name="ByteCount">Number of bytes to derive</param>
        /// <returns>Derived bytes</returns>
        public static byte[] PBKDF2(string Key, byte[] Salt, int Iterations, int ByteCount)
        {
            return PBKDF2(Encoding.UTF8.GetBytes(Key), Salt, Iterations, ByteCount);
        }

        /// <summary>
        /// Derives a key using PBKDF2
        /// </summary>
        /// <param name="Key">Password</param>
        /// <param name="Salt">Salt</param>
        /// <param name="Iterations">Iteration count</param>
        /// <param name="ByteCount">Number of bytes to derive</param>
        /// <returns>Derived bytes</returns>
        public static byte[] PBKDF2(byte[] Key, byte[] Salt, int Iterations, int ByteCount)
        {
            if (Key == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (Salt == null)
            {
                throw new ArgumentNullException(nameof(Salt));
            }
            if (Iterations < KeyDerivation.MinIterations)
            {
                throw new ArgumentOutOfRangeException(nameof(Iterations), $"Value must be at least {KeyDerivation.MinIterations}");
            }

            if (ByteCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(ByteCount), "Value must be at least 1");
            }

            int Ret = BCryptOpenAlgorithmProvider(out IntPtr Alg, "SHA512", null, BCryptFlags.BCRYPT_ALG_HANDLE_HMAC_FLAG);
            using (var Handle = new SafeBcryptAlgorithmHandle(Alg))
            {
                if (Alg != IntPtr.Zero)
                {
                    Debug.Print($"Opened: Ptr: {Alg}");

                    byte[] Result = new byte[ByteCount];

                    Ret = BCryptDeriveKeyPBKDF2(
                        Alg,
                        Key, Key.Length,
                        Salt, Salt.Length,
                        Iterations,
                        Result, Result.Length,
                        BCryptFlags.NO_FLAGS);
                    if (Ret != 0)
                    {
                        throw new Win32Exception($"Key generator failed with NT Status {Ret}");
                    }
                    return Result;
                }
                else
                {
                    throw new Win32Exception($"Open failed with NT Status {Ret}");
                }
            }
        }

        /// <summary>
        /// Safe handle for BCrypt algorithm
        /// </summary>
        private class SafeBcryptAlgorithmHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeBcryptAlgorithmHandle(IntPtr Handle) : base(true)
            {
                SetHandle(Handle);
            }

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                BCryptCloseAlgorithmProvider(handle, BCryptFlags.NO_FLAGS);
                SetHandleAsInvalid();
                return true;
            }
        }
    }
}
