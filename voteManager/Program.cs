using System;
using System.Diagnostics;
using System.Windows.Forms;
using VoteManager.Forms;
using VoteManager.Helpers;

namespace VoteManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // may throw exception if its doesn' find a database
                var entities = DbUtils.AppEntities;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO DATABASE FOUND");
                Trace.WriteLine(ex.Message);
                //return;
            }
            bool isReady = false;
            if (!IsActivated())
            {
                // check if app is already activated through windows registry
                var enterLicense = new EnterLicense();
                Application.Run(enterLicense);
                isReady = enterLicense.IsActivated;
            }
            else
            {
                isReady = true;
            }

            // TODO: Check for atleast one user?
#if DEBUG
            isReady = true;
#else
            isReady = false;
#endif

            if (isReady)
            {
                // show main
                Application.Run(new LoginForm());
            }
            else
            {

            }
        }

        private static bool IsActivated()
        {
            // check through registry
            return false;
        }
    }
}
