using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionAuthGen
{
    /// <summary>
    /// Provides a base32 generator
    /// </summary>
    /// <remarks>
    /// This class is specifically tailored to the way Tor uses Base32
    /// </remarks>
    public static class Base32
    {
        /// <summary>
        /// Base32 alphabet
        /// </summary>
        private const string ALPHA = "abcdefghijklmnopqrstuvwxyz234567";

        /// <summary>
        /// Checks if a string is made up exclusively of base32 segments
        /// </summary>
        /// <param name="PotentialBase32">String</param>
        /// <returns>true, if Base32</returns>
        public static bool IsBase32(string PotentialBase32)
        {
            var Paddings = new int[] { 6, 4, 3, 1, 0 };
            if (PotentialBase32 == null)
            {
                throw new ArgumentNullException(nameof(PotentialBase32));
            }
            //check padding
            if (PotentialBase32.EndsWith("="))
            {
                if (PotentialBase32.Length % 8 != 0)
                {
                    return false;
                }
                var OldLen = PotentialBase32.Length;
                PotentialBase32 = PotentialBase32.TrimEnd('=');
                var Count = OldLen - PotentialBase32.Length;
                //Invalid padding length
                if (!Paddings.Contains(Count))
                {
                    return false;
                }
            }
            else if (!Paddings.Contains(PotentialBase32.Length % 8))
            {
                return false;
            }
            return PotentialBase32.ToLower().All(m => ALPHA.Contains(m));
        }

        /// <summary>
        /// Encodes data into Base32
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <returns>Base32</returns>
        public static string Encode(byte[] Data)
        {
            if (Data is null)
            {
                throw new ArgumentNullException(nameof(Data));
            }
            StringBuilder SB = new StringBuilder();
            var Alphabet = ALPHA.ToCharArray();
            for (var i = 0; i < Data.Length; i += 5)
            {
                ulong l =
                    (ulong)Get(Data, i + 0) << 32 |
                    (ulong)Get(Data, i + 1) << 24 |
                    (ulong)Get(Data, i + 2) << 16 |
                    (ulong)Get(Data, i + 3) << 8 |
                    (ulong)Get(Data, i + 4) << 0;
                for (var j = 0; j < 8; j++)
                {
                    SB.Append(Alphabet[(l >> (35 - j * 5)) & 0x1F]);
                }
            }
            //6-4-3-1
            int pad = new int[] { 0, 6, 4, 3, 1 }[Data.Length % 5];
            if (pad > 0)
            {
                for (var i = 1; i <= pad; i++)
                {
                    SB[SB.Length - i] = '=';
                }
            }
            return SB.ToString();
        }

        /// <summary>
        /// Decodes data from a Base32 string
        /// </summary>
        /// <param name="Value">Base32 string</param>
        /// <returns>Decoded bytes</returns>
        /// <remarks>Padding is optional</remarks>
        public static byte[] Decode(string Value)
        {
            if (!IsBase32(Value))
            {
                throw new FormatException("Supplied value not valid base32");
            }
            Value = Value.ToLower();
            //Add missing padding
            while (Value.Length % 8 > 0)
            {
                Value += "=";
            }
            int trim = 0;
            using (var MS = new MemoryStream())
            {
                for (var i = 0; i < Value.Length; i += 8)
                {
                    ulong num = 0;
                    for (var j = i; j < i + 8; j++)
                    {
                        var index = ALPHA.IndexOf(Value[j]);
                        num <<= 5;
                        if (index >= 0)
                        {
                            num |= (uint)index;
                        }
                        else
                        {
                            ++trim;
                        }
                    }
                    MS.WriteByte((byte)(num >> 32 & 0xFF));
                    MS.WriteByte((byte)(num >> 24 & 0xFF));
                    MS.WriteByte((byte)(num >> 16 & 0xFF));
                    MS.WriteByte((byte)(num >> 8 & 0xFF));
                    MS.WriteByte((byte)(num >> 0 & 0xFF));
                }
                if (trim > 0)
                {
                    trim = new int[] { 1, -1, 2, 3, -1, 4 }[trim - 1];
                    MS.SetLength(MS.Length - trim);
                }
                return MS.ToArray();
            }
        }

        /// <summary>
        /// Gets a value from a byte array, or the default value if index out of bound
        /// </summary>
        /// <param name="Data">Array to get value from</param>
        /// <param name="Index">Array index</param>
        /// <returns>Value or default</returns>
        /// <remarks>The default for numerical types is zero</remarks>
        private static T Get<T>(T[] Data, int Index)
        {
            return Index >= 0 && Index < Data.Length ? Data[Index] : default;
        }
    }
}
