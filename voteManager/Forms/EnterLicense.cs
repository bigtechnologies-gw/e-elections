using System;
using System.Windows.Forms;

namespace VoteManager.Forms
{
    public partial class EnterLicense : Form
    {
        public bool IsActivated { get; set; }

        public EnterLicense()
        {
            InitializeComponent();
        }

        private async void ButtonActivate_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // wait 3 seconds
#if !DEBUG
            await Task.Delay(1000 * 3).ConfigureAwait(true); 
#endif

            string license = maskedTextBox1.Text;
            if (ValidateLincese(license))
            {
                MessageBox.Show("Activated with success :), thanks for buying our product!",
                    "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // store info in windows registry
                // Microsoft.Win32.Registry
            }
            else
            {
                var diagResult = MessageBox.Show("Invalid license, please contact us in www.big-technologies.com!",
                    "Failed!",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);

                if (diagResult == DialogResult.Cancel)
                {
                    // exit app.
                }
            }

            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Visible = false;

            // create admin configuration
            var configs = new CreateAdminConfigurations
            {
                Title = "Create super admin",
                TypeUser = TypeUser.SuperAdmin
            };

            using (var formCreateAdmin = new CreateAdminForm(configs))
            {
                if (formCreateAdmin.ShowDialog(this) != DialogResult.OK)
                {
                    // close app
                    //Application.Exit();
                    //Environment.Exit()
                    MessageBox.Show("Must add super-admin!");
                    return;
                }

                // update configuration
                configs = new CreateAdminConfigurations
                {
                    Title = "Create admin province",
                    TypeUser = TypeUser.Admin
                };

                using (var costumForm = new CustomForm())
                {
                    if (costumForm.ShowDialog(this) == DialogResult.OK)
                    {
                        var partidoInfo = costumForm.PartidoInfo;
                        // TODO: move logo to app-directory
                        // add path to xml file
                        // add both color property to xml file
                    }
                }

                //using (var createProvinceAdmins = new CreateAdminForm(configs))
                //{
                //    if (createProvinceAdmins.ShowDialog(this) != DialogResult.OK)
                //    {
                //        //Application.Exit();
                //    }
                //}

                //using (var editCEForm = new EditCE())
                //{
                //    if (IsDisposed)
                //    {
                //        Trace.WriteLine("Dispose due to Application.Exit call");
                //    }
                //    if (editCEForm.ShowDialog(this) != DialogResult.OK)
                //    {
                //        //Application.Exit();
                //    }
                //}

                //using (var editVoteTableForm = new EditVotingTable())
                //{
                //    if (editVoteTableForm.ShowDialog(this) != DialogResult.OK)
                //    {
                //        //Application.Exit();
                //    }
                //}

            }


            // close this form and start showing login form
            // since at least a user is available at this point.
            Close();
        }

        private bool ValidateLincese(string lincense)
        {
#if DEBUG
            return true;
#endif
            return false;
        }
    }
}
