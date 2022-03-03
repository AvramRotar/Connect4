
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Connect4New
{
    static class Program
    {

        #region Private Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm());
        }
        
        #endregion Private Methods

    }
}
