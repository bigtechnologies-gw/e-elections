using System;
using System.Linq;
using System.Windows.Forms;
using VoteManager.Helpers;

namespace VoteManager.Forms
{
    public partial class EditUserSettings : Form
    {
        private readonly LoginUserContext _userContext;

        public EditUserSettings(LoginUserContext userContext)
        {
            InitializeComponent();
            _userContext = userContext;

            InitUI();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            string fullName = textBoxEditFullName.Text.Trim();
            string password = textBoxEditPasswowrd.Text.Trim();
            string userName = textBoxEditLogin.Text.Trim();

            var selUser = ((DisplayItem<User>)listBoxUsers.SelectedItem).Item;

            if (!DataValidator.IsValidName(fullName))
            {
                Name = null;
            }
            if (!DataValidator.IsValidUserName(userName))
            {
                userName = null;
            }
            if (!DataValidator.IsValidPassword(password))
            {
                password = null;
            }

            // username 
            _userContext.User.Name = userName ?? _userContext.User.Name;
            _userContext.User.FullName = fullName ?? _userContext.User.FullName;
            _userContext.User.Password = password ?? _userContext.User.Password;

            _userContext.VoteDbContext.SaveChanges();

            //_voteEntities.Entry(null).

            // TODO:
            // - any use an updates it's info 
            // - admin can disable any-use he/she created
            // - admin can enable/disble any-user he/she created
            // - login-user cannot enable/disable itself

            // update UI
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.Items.Count == 0)
            {
                return;
            }
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }
            User user = ((DisplayItem<User>)listBoxUsers.SelectedItem).Item;
            if (user == null)
            {
                return;
            }
            _userContext.VoteDbContext.Users.Remove(user);
            listBoxUsers.Items.RemoveAt(listBoxUsers.SelectedIndex);
            _userContext.VoteDbContext.SaveChanges();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            // Add standard user to same province as logged in user.
            string userName = textBoxUserName.Text.Trim();
            string fullName = textBoxFullName.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string passwordConfirm = textBoxConfirmPassword.Text.Trim();

            if (_userContext.VoteDbContext.Users.Any(u => u.Name.Equals(userName, StringComparison.Ordinal)))
            {
                // user exits
                MessageBox.Show("Users already exits!");
                return;
            }

            // if system {admin=0, standard=1, system=2}
            // if admin {standard = 0}
            if (!DataValidator.IsValidPassword(password, passwordConfirm))
            {
                // notify error
                return;
            }

            if (!DataValidator.IsValidUserName(userName))
            {
                // notify error
                return;
            }

            if (!DataValidator.IsValidName(fullName))
            {
                MessageBox.Show("Invalid user name!");
                // notify error
                return;
            }

            if (!password.Equals(passwordConfirm, StringComparison.Ordinal))
            {
                MessageBox.Show("Invalid password!");
                // message user password doesn't match
                return;
            }

            var province = ((DisplayItem<Province>)comboBoxProvince.SelectedItem).Item;

            var typeUser = ((DisplayItem<TypeUser>)comboBoxTypeUser.SelectedItem).Item;

            var user = new User
            {
                Enabled = true,
                Name = userName,
                FullName = fullName,
                Password = password,
                DateCreation = DateTime.Now,
                Type = TypeUser.Standard,
                ProvinceId = comboBoxProvince.Enabled ? province.Id : 0,// 0 is none for non-admin users
                OwnerId = _userContext.User.Id,
                Salt = string.Empty
            };

            _userContext.VoteDbContext.Users.Add(user);
            _userContext.VoteDbContext.SaveChanges();

            // udpate listBoxUsers
            listBoxUsers.BeginUpdate();
            // TODO: call method which will refresh listboxuser (remove/add) new user

            listBoxUsers.EndUpdate();

            MessageBox.Show("User added");
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            var selUser = ((DisplayItem<User>)listBoxUsers.SelectedItem).Item;

            if (selUser == null)
            {
                return;
            }

            textBoxEditLogin.Text = selUser.Name;
            textBoxEditFullName.Text = selUser.FullName;
            checkBoxEnableEditUser.Checked = selUser.Enabled;

            bool isNotSel = _userContext.User.Id != selUser.Id;
            checkBoxEnableEditUser.Enabled = isNotSel;
            buttonRemoveUser.Enabled = isNotSel;
            textBoxEditPasswowrd.Text = string.Empty;
        }

        public void InitUI()
        {
            listBoxUsers.BeginUpdate();
            listBoxUsers.Items.Clear();

            comboBoxProvince.BeginUpdate();
            comboBoxProvince.Items.Clear();

            comboBoxTypeUser.BeginUpdate();
            comboBoxTypeUser.Items.Clear();

            //foreach (var user in _userContext.VoteDbContext.Users.Where(user => user.OwnerId == _userContext.User.Id || user.Id == _userContext.User.Id).OrderBy(user => user.Name))
            //{
            //    listBoxUsers.Items.Add(new DisplayItem<User>(user));
            //}
            foreach (var user in _userContext.VoteDbContext.Users)
            {
                listBoxUsers.Items.Add(new DisplayItem<User>(user));
            }

            foreach (var province in _userContext.VoteDbContext.Provinces)
            {
                comboBoxProvince.Items.Add(new DisplayItem<Province>(province));
            }

            foreach (var item in Enum.GetNames(typeof(TypeUser)))
            {
                var obj = (TypeUser)Enum.Parse(typeof(TypeUser), item);
                var displayItem = new DisplayItem<TypeUser>(obj)
                {
                    DisplayProperty = item,
                };
                comboBoxTypeUser.Items.Add(displayItem);
            }

            listBoxUsers.EndUpdate();
            comboBoxProvince.EndUpdate();
            comboBoxTypeUser.EndUpdate();
        }

        private void comboBoxTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeUser typeUser = ((DisplayItem<TypeUser>)comboBoxTypeUser.SelectedItem).Item;
            comboBoxProvince.Enabled = typeUser != TypeUser.Standard;
        }
    }
}
