using DVLD_Presentation.Applications_Forms;
using DVLD_Presentation.Licenses_Forms;
using System;
using System.Windows.Forms;


namespace DVLD_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginScreen());
           

        }
    }
}
