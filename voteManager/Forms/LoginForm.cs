using System;
using System.Linq;
using System.Windows.Forms;

namespace voteManager
{
    public partial class LoginForm : Form
    {
        private Main _main;
        private voteAppEntities _voteModel;
        private User _loginUser;

        public LoginForm()
        {
            InitializeComponent();

            //textBoxLogin.UseSystemPasswordChar = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string userName = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            // validation

            if (CheckLogin(userName, password))
            {
                _main = new Main(_voteModel, _loginUser);
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
            _voteModel = new voteAppEntities();
            _loginUser = _voteModel.Users.FirstOrDefault(login => login.Name.Equals(userName, StringComparison.Ordinal) && login.Password.Equals(hashedPassword));

            if (_loginUser == null)
            {
                MessageBox.Show("Username or password doesn't exists", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
#endif
            //return _voteModel.logins.Any(rec => rec.loginAdmin.TrimEnd().Equals(login, StringComparison.Ordinal));
        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void checkBoxHideShowLogin_CheckedChanged(object sender, EventArgs e)
        {
            //textBoxLogin.UseSystemPasswordChar = !textBoxLogin.UseSystemPasswordChar;
            //textBoxLogin.Text = 
        }
    }
}
