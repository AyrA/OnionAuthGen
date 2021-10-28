using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public static class Tools
    {
        private const string RES_START = "OnionAuthGen.Resources.";

        public static readonly string[] WordList;

        static Tools()
        {
            WordList = GetResourceText("Wordlist.txt")
                .Split(new string[] { "\r\n" }, StringSplitOptions.None);
        }

        public static Stream GetResource(string Filename)
        {
            var Asm = Assembly.GetExecutingAssembly();
            var S = Asm.GetManifestResourceStream($"{RES_START}{Filename}");
            if (S == null)
            {
                S = Asm.GetManifestResourceStream($"{RES_START}{Filename}.gz");
                if (S == null)
                {
                    return null;
                }
                using (var Decompressor = new System.IO.Compression.GZipStream(S, System.IO.Compression.CompressionMode.Decompress))
                {
                    var MS = new MemoryStream();
                    Decompressor.CopyTo(MS);
                    MS.Position = 0;
                    return MS;
                }
            }
            return S;
        }

        public static string GetResourceText(string Filename)
        {
            using (var Res = GetResource(Filename))
            {
                using (var SR = new StreamReader(Res))
                {
                    return SR.ReadToEnd();
                }
            }
        }

        public static void ScaleForm(Form F)
        {
            //Apply zoom
            if (F.Font.Size < 12.0)
            {
                F.Font = new System.Drawing.Font(F.Font.FontFamily, Math.Max(12f, F.Font.Size));
            }

        }

        public static string[] GetResourceNames()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetManifestResourceNames()
                .Where(m => m.StartsWith(RES_START))
                .Select(m => m.Substring(RES_START.Length))
                .ToArray();
        }
    }
}
