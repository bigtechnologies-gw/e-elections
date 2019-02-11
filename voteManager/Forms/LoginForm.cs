using EElections.Helpers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class LoginForm : Form
    {
        private Main _main;
        private voteAppEntities DbContext;
        private User _loginUser;
        private volatile Form _loadingForm = null;
        public delegate void CloseLoadingForm();

        public LoginForm()
        {
            InitializeComponent();
            DbContext = DbUtils.AppEntities;

            // try fixing problem, control not redrawing itself.
            Shown += delegate
            {
                //Invalidate();
                Refresh();
            };

            // directoryEntry1
            // var result = directorySearcher1.FindOne();

#if DEBUG
            foreach (CheckBox checkbox in groupBox1.Controls.OfType<CheckBox>())
            {
                checkbox.Enabled = true;
                checkbox.CheckedChanged += Checkbox_CheckedChanged;
            }
#endif
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked)
            {
                textBoxLogin.Text = checkbox.Text;
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            // progressBar1.Style = ProgressBarStyle.Marquee;
            Hide();

            //taskSplashScreen.ConfigureAwait(false);

            string userName = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            textBoxPassword.Text = string.Empty;

            if (CheckLogin(userName, password))
            {
                //System.Threading.ThreadPool.QueueUserWorkItem()
                //Task.Factory.StartNew(() =>
                // {
                //     // NOT SAME THREAD AS THE MAIN APPLICATION
                //     // Application.EnableVisualStyles();
                //     // Application.SetCompatibleTextRenderingDefault(false);

                //     _loadingForm = new LoadingForm();
                //     Application.Run(_loadingForm);
                // }, TaskCreationOptions.None);

                var loadingFormThread = new Thread(() =>
                {
                    _loadingForm = new LoadingForm();
                    Application.Run(_loadingForm);
                });
                loadingFormThread.Start();

                _main = new Main(_loginUser);

                //_main.Shown += delegate
                //{
                //    // close the splash screen
                //    _loadingForm?.Invoke(new CloseLoadingForm(() =>
                //    {
                //        _loadingForm?.Close();
                //    }));
                //};

                _loginUser = null;

                //var bindingList = new System.ComponentModel.BindingList<string>();
                // INFO: notifies on changes
                //bindingList.AddingNew += delegate
                //{
                //};

                if (_loadingForm.InvokeRequired && _loadingForm.IsHandleCreated)
                {
                    //close the splash screen
                    _loadingForm?.Invoke(new CloseLoadingForm(() =>
                    {
                        _loadingForm?.Close();
                    }));
                }

                _main.Show(this);
            }
            else
            {
                Show();
                MessageBox.Show("Incorrect login, please contact the admin", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool CheckLogin(string userName, string rawPassword)
        {
            // TODO: HASH PASSWORD
            DbContext = new voteAppEntities();

            if (!DbContext.Users.Any())
            {
                return false;
            }

            // Authentication
            _loginUser = DbContext.Users.FirstOrDefault(login => login.Name.Equals(userName, StringComparison.Ordinal));
            if (_loginUser == null)
            {
                return false;
            }

            string hashPassword = PwdUtils.GetHashedPassword(rawPassword, _loginUser.Salt);
            if (_loginUser.Password.Equals(hashPassword, StringComparison.Ordinal) == false)
            {
                return false;
            }

            if (!_loginUser.Enabled)
            {
                MessageBox.Show($"User: {_loginUser.Name} disabled");
                textBoxPassword.Text = string.Empty;
                return false;
            }

            return true;
        }
        
        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            Invalidate(ClientRectangle, true);
            //this.UpdateBounds()
            Update();

            // Refresh(); would re-paint all control+child
        }
    }
}
