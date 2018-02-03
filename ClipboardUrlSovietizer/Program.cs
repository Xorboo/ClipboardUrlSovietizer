using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardUrlSovietizer
{
    static class Program
    {
        public const string MinimizedTag = "--minimized";


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool isMinimized = args.Length > 0 && args[0] == MinimizedTag;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(isMinimized));
        }
    }
}
