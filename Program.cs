using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPF_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TO:DO Add when Home page is ready
            Application.Run(new UPF_HomePage());

            //Application.Run(new Form1()); //Remove when Hompage is ready
        }
    }
}
