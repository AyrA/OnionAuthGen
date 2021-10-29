using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnionAuthGen
{
    /// <summary>
    /// Provides methods to derive keys from user input
    /// such as a password or passphrase.
    /// </summary>
    public static class KeyDerivation
    {
        /// <summary>
        /// Minimum allowed iterations
        /// </summary>
        public const int MinIterations = 10000;

        /// <summary>
        /// Gets the default salt value used by this implementation
        /// </summary>
        /// <returns>Default salt</returns>
        /// <remarks>
        /// The salt is 0x00, 0x11, 0x22, ... , 0xFF but alternating (00-FF-11-EE-...)
        /// </remarks>
        public static byte[] GetDefaultSalt()
        {
            return new byte[]
            {
                0x00, 0xFF, 0x11, 0xEE, 0x22, 0xDD, 0x33, 0xCC,
                0x44, 0xBB, 0x55, 0xAA, 0x66, 0x99, 0x77, 0x88
            };
        }

        /// <summary>
        /// Gets the custom salt that matches the supplied key
        /// </summary>
        /// <param name="Key">User supplied key</param>
        /// <returns>Custom salt</returns>
        public static byte[] GetCustomSalt(string Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException($"'{nameof(Key)}' cannot be null or empty.", nameof(Key));
            }
            return GetCustomSalt(Encoding.UTF8.GetBytes(Key));
        }

        /// <summary>
        /// Gets the custom salt that matches the supplied key
        /// </summary>
        /// <param name="Key">User supplied key</param>
        /// <returns>Custom salt</returns>
        public static byte[] GetCustomSalt(byte[] Key)
        {
            if (Key == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            var Salt = GetDefaultSalt();

            for (var i = 0; i < Key.Length; i++)
            {
                Salt[(i + Key[i]) % Salt.Length] ^= Key[i];
            }

            return Salt;
        }

        /// <summary>
        /// Derives a key from the supplied key material
        /// </summary>
        /// <param name="Password">Private key part</param>
        /// <param name="Salt">Public key part</param>
        /// <param name="Iterations">Number of iterations</param>
        /// <param name="ByteCount">Byte count to derive</param>
        /// <returns>Derived bytes</returns>
        public static byte[] DeriveKey(string Password, byte[] Salt, int Iterations, int ByteCount)
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException($"'{nameof(Password)}' cannot be null or empty.", nameof(Password));
            }

            if (Salt == null || Salt.Length == 0)
            {
                throw new ArgumentNullException(nameof(Salt));
            }

            if (Iterations < MinIterations)
            {
                throw new ArgumentOutOfRangeException(nameof(Iterations), $"Value must be at least {MinIterations}");
            }

            if (ByteCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(ByteCount), "Value must be at least 1");
            }

            //The .NET PBKDF2 implementation (Rfc2898DeriveBytes is PBKDF2) is abysmally slow.
            //Because of this, we prefer the unamanged API when on Windows.
            //For Linux and Mac, using OpenSSL may be better
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                //The function was introduced in Windows Vista, so earlier NT versions may fail,
                //unless they have a 3rd party crypto provider that adds this algorithm.
                try
                {
                    return UnmanagedPBKDF2.PBKDF2(Password, Salt, Iterations, 32);
                }
                catch (Exception ex)
                {
                    Debug.Print($"Unmanaged key derivation failed. Fallback to .NET. Error: {ex.Message}");
                }
            }
            return FallbackDerive(Password, Salt, Iterations, 32);
        }

        /// <summary>
        /// Fallback PBKDF2 implementation
        /// </summary>
        /// <param name="Password">Private key part</param>
        /// <param name="Salt">Public key part</param>
        /// <param name="Iterations">Number of iterations</param>
        /// <param name="ByteCount">Byte count to derive</param>
        /// <returns>Derived bytes</returns>
        private static byte[] FallbackDerive(string Password, byte[] Salt, int Iterations, int ByteCount)
        {
            using (var PBKDF = new Rfc2898DeriveBytes(Password, Salt, Iterations, new HashAlgorithmName("SHA512")))
            {
                return PBKDF.GetBytes(ByteCount);
            }
        }
    }
}
