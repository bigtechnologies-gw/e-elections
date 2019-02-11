using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            linkLabelActivate.LinkClicked += (object sender, LinkLabelLinkClickedEventArgs e) =>
            {
                using (LicenseForm licenseForm = new LicenseForm())
                {
                    if (licenseForm.ShowDialog(this) == DialogResult.OK && RegistryUtils.IsLicensed())
                    {
                        pictureBoxLicense.Image = Properties.Resources.Ok_96px;
                        pictureBoxLicense.Refresh();
                        //pictureBoxLicense.Load();
                    }
                }
            };

            // check activation through registry
            if (RegistryUtils.IsLicensed())
            {
                // display green *check image.
                pictureBoxLicense.Image = Properties.Resources.Ok_96px;
                pictureBoxLicense.Refresh();

                linkLabelActivate.Enabled = false;
                linkLabelActivate.Visible = false;
            }
        }

    }
}
