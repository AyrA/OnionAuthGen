using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OnionAuthGen
{
    public static class Tools
    {
        private const string RES_START= "OnionAuthGen.Resources.";
        public static Stream GetResource(string Filename)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream($"{RES_START}{Filename}");
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
