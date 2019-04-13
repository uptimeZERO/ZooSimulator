using System;
using System.Windows.Forms;

namespace Zoo_Simulator
{
    /// <summary>
    /// The main program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmZooSimulator());
        }
    }
}
