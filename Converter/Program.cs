using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    static class Program
    {
        /// <summary>
        /// Main program
        /// This runs the GUI for the image to block-element ascii conversion tool
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new FormMain());
        }
    }
}
