using EElections.Forms;
using EElections.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace EElections
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
                voteAppEntities entities = DbUtils.AppEntities;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NOT CONNECTED TO A DATABASE!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Trace.WriteLine(ex.Message);
                return;
            }

            bool isLicensed = RegistryUtils.IsLicensed();

            if (!isLicensed)
            {
                // check if app is already activated through windows registry
                using (LicenseForm enterLicense = new LicenseForm())
                {
                    //enterLicense.ShowDialog();
                    Application.Run(enterLicense);
                    isLicensed = enterLicense.DialogResult == DialogResult.OK;
                }
            }

            // invalid license
            if (!isLicensed)
            {
                return;
            }

            // if there is at least one user (superadmin) show the login form
            if (DbUtils.AppEntities.Users.Any(user => user.Type == TypeUser.SuperAdmin) == false)
            {
                CreateAdminConfigurations configs = new CreateAdminConfigurations
                {
                    Title = "Create super admin!",
                    TypeUser = TypeUser.SuperAdmin
                };
                bool showLoginForm = false;
                //User loginUser = null;
                using (CreateAdminForm formCreateSuperAdmin = new CreateAdminForm(configs))
                {
                    if (formCreateSuperAdmin.ShowDialog() == DialogResult.OK)
                    {
                        showLoginForm = formCreateSuperAdmin.User != null;
                    }
                }
                if (showLoginForm)
                {
                    using (CustomForm customForm = new CustomForm())
                    {
                        customForm.ShowDialog();
                    }
                }
            }

            Application.Run(new LoginForm());

        }
    }
}
