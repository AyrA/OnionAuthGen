using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnionAuthGen
{
    public static class KeyDerivation
    {
        public static byte[] GetDefaultSalt()
        {
            return new byte[]
            {
                0x00, 0xFF, 0x11, 0xEE, 0x22, 0xDD, 0x33, 0xCC,
                0x44, 0xBB, 0x55, 0xAA, 0x66, 0x99, 0x77, 0x88
            };
        }

        public static byte[] GetCustomSalt(string Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException($"'{nameof(Key)}' cannot be null or empty.", nameof(Key));
            }
            return GetCustomSalt(Encoding.UTF8.GetBytes(Key));
        }

        public static byte[] GetCustomSalt(byte[] Key)
        {
            if (Key == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            var Salt = GetDefaultSalt();

            for(var i = 0; i < Key.Length; i++)
            {
                Salt[(i + Key[i]) % Salt.Length] ^= Key[i];
            }

            return Salt;
        }

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

            if (Iterations < 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(Iterations), "Value must be at least 10'000");
            }

            if (ByteCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(ByteCount),"Value must be at least 1");
            }

            using (var PBKDF = new Rfc2898DeriveBytes(Password, Salt, Iterations, new HashAlgorithmName("SHA512")))
            {
                return PBKDF.GetBytes(ByteCount);
            }
        }
    }
}
