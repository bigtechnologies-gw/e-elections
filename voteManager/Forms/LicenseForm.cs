using EElections.Helpers;
using System;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();

            // check if trial hasn't already finish

            if (RegistryUtils.IsTrialModeExpired())
            {
                // disable 
                radioButtonLicense.Enabled = false;
                radioButtonTrial.Enabled = false;

                radioButtonLicense.Visible = false;
                radioButtonTrial.Visible = false;

                radioButtonLicense.Checked = true;
                //maskedTextBox1.Enabled = true;
            }
        }

        private /*async*/ void ButtonActivate_Click(object sender, EventArgs e)
        {
            // wait 3 seconds
#if !DEBUG
            await Task.Delay(1000 * 3).ConfigureAwait(true); 
#endif

            if (radioButtonLicense.Checked)
            {
                LicenseActivation(maskedTextBox1.Text.Trim('{', '}').Trim());
            }
            else
            {
                TrialActivation();
            }

            // close this form and start showing login form
            // since at least a user is available at this point.
            //Close();
        }

        private void TrialActivation()
        {
            //var resourceWriter = new ResourceWriter("VoteManager.Properties.Resources");
            //resourceWriter.Generate()
            //System.Diagnostics.Debug.WriteLine($"is valid {resourceWriter != null}");
            //var fileTime = DateTime.UtcNow.ToFileTimeUtc();
            //Properties.Resources.TrialTime = fileTime;
            RegistryUtils.ActivateTrial();
            MessageBox.Show($"Trial mode is activated with sucess. The trial will end in: {DateTime.Now + TimeSpan.FromDays(1)} ", "Trial mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LicenseActivation(string license)
        {
            if (ValidateLincese(license))
            {
                RegistryUtils.StoreLicenseKey(license);
                MessageBox.Show("Activated with success :), thanks for buying our product!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult diagResult = MessageBox.Show("Invalid license, please contact us in www.big-technologies.com!",
                    "Failed!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                switch (diagResult)
                {
                    case DialogResult.None:
                    case DialogResult.Abort:
                    case DialogResult.Ignore:
                    case DialogResult.Cancel:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                    case DialogResult.Retry:
                        maskedTextBox1.Focus();
                        maskedTextBox1.SelectAll();
                        return;
                    default:
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                }
            }

        }

        private bool ValidateLincese(string license) => RegistryUtils.LicenseStore.Contains(license);

        private void RadioButtonTrial_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = false;
        }

        private void RadioButtonLicense_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = true;
        }
    }
}
