using System;
using System.Windows.Forms;

namespace OnionAuthGen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var c = Tools.GetResourceText("Wordlist.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Console.WriteLine(c);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
