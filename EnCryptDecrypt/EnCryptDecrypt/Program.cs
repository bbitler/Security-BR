using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnCryptDecrypt
{
    static class Program
    {
       
        /// The main entry point for the application.
        
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}