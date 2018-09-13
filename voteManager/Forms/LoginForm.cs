using System;
using System.Linq;
using System.Windows.Forms;
using voteManager.Forms;
using voteManager.Helpers;

namespace voteManager
{
    public partial class LoginForm : Form
    {
        private Main _main;
        private voteAppEntities _appEntities;
        private User _loginUser;

        public LoginForm()
        {
            InitializeComponent();
            _appEntities = DbUtils.AppEntities;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string userName = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            textBoxPassword.Text = string.Empty;

            if (CheckLogin(userName, password))
            {
                _main = new Main(_appEntities, _loginUser);
                _loginUser = null;
                Hide();
                _main.Show(this);
            }
            else
            {
                MessageBox.Show("Incorrect login, please contact the admin", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool CheckLogin(string userName, string password)
        {
#if !DEBUG
            return true;
#else
            // todo: hash passsword
            string hashedPassword = password;
            _appEntities = new voteAppEntities();

            if (!_appEntities.Users.Any())
            {
                return false;
            }

            _loginUser = _appEntities.Users.FirstOrDefault(login => login.Name.Equals(userName, StringComparison.Ordinal) && login.Password.Equals(hashedPassword));

            if (_loginUser == null)
            {
                return false;
            }

            // only enabled user is allowed to login.
            if (!_loginUser.Enabled)
            {
                MessageBox.Show($"User: {_loginUser.Name} disabled");
                textBoxPassword.Text = string.Empty;
                return false;
            }
            return true;
#endif
            //return _voteModel.logins.Any(rec => rec.loginAdmin.TrimEnd().Equals(login, StringComparison.Ordinal));
        }

        private void checkBoxHideShowLogin_CheckedChanged(object sender, EventArgs e)
        {
            //textBoxLogin.UseSystemPasswordChar = !textBoxLogin.UseSystemPasswordChar;
            //textBoxLogin.Text = 
        }

        private void linkLabelCreateUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var createUser = new CreateUser(_appEntities))
            {
                createUser.ShowDialog(this);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}
