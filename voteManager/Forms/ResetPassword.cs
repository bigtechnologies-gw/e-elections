using System;
using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Forms
{
    public partial class ResetPassword : Form
    {
        private readonly User _user;

        public ResetPassword(User user)
        {
            InitializeComponent();

            panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;
            _user = user;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            voteAppEntities dbContext = DbUtils.AppEntities;

            // hash password

            string password = textBoxPassword.Text;
            string passwordCheck = textBoxPasswordCheck.Text;

            if (DataValidator.IsValidPassword(password, passwordCheck) == false)
            {
                MessageBox.Show("Invalid password");
                return;
            }

            _user.Password = "";
            dbContext.SaveChanges();

        }
    }
}
