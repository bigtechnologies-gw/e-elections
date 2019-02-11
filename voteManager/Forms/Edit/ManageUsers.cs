using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Forms
{
    public partial class EditUserSettings : Form
    {
        private readonly LoginUserContext _userContext;

        public EditUserSettings(LoginUserContext userContext)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            Paint += (sender, e) =>
            {
                // draw top banner
                SolidBrush primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
                SolidBrush secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

                // draw bottom banner
                e.Graphics.FillRectangle(primaryBrush, 0, 0, Width, 25);
                e.Graphics.FillRectangle(secondaryBrush, 0, ClientRectangle.Height - 25, Width, 25);
            };
            _userContext = userContext;

            MaximizeBox = false;
            //this.SetMAxSize();
            InitUI();
        }

        private void ButtonUpdateUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            string fullName = textBoxEditFullName.Text.Trim();
            string rawPassword = textBoxEditPasswowrd.Text.Trim();
            string userName = textBoxEditLogin.Text.Trim();

            User selUser = ((DisplayItem<User>)listBoxUsers.SelectedItem).Item;

            if (!DataValidator.IsValidFullName(fullName))
            {
                Name = null;
            }
            if (!DataValidator.IsValidUserName(userName))
            {
                userName = null;
            }
            if (!DataValidator.IsValidPassword(rawPassword))
            {
                rawPassword = null;
            }

            (string hashPassword, string salt) = PwdUtils.GetSaltyPassword(rawPassword);

            // TODO: refact? user selUser directly?
            User currentUser = DbUtils.AppEntities.Users.FirstOrDefault(u => u.Name == selUser.Name);

            if (currentUser == null)
            {
                Debug.WriteLine("Sel user not found!");
                return;
            }

            currentUser.Name = userName ?? currentUser.Name;
            currentUser.FullName = fullName;

            if (string.IsNullOrEmpty(hashPassword) == false)
            {
                currentUser.Password = hashPassword;
                currentUser.Salt = salt;
            }

            //var user = DbUtils.AppEntities.Users.FirstOrDefault(usr => usr.Name.Equals(_userContext.User.Name));
            //USEFUL: _userContext.VoteDbContext.Entry(_userContext.User).State = System.Data.Entity.EntityState.
            //var set = DbUtils.AppEntities.Set(typeof(User));

            //DbUtils.AppEntities.Users.
            //_userContext.VoteDbContext.SaveChanges();

            DbUtils.AppEntities.SaveChanges();
            //_voteEntities.Entry(null).

            UpdateUserView();
            MessageBox.Show("user info updated!", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.Items.Count == 0)
            {
                return;
            }

            User user = ((DisplayItem<User>)listBoxUsers.SelectedItem)?.Item;
            if (user == null)
            {
                return;
            }

            _userContext.VoteDbContext.Users.Remove(user);
            listBoxUsers.Items.RemoveAt(listBoxUsers.SelectedIndex);
            _userContext.VoteDbContext.SaveChanges();

            MessageBox.Show($"User: {user.Name} removed with success", "Remove user", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            if (!DataValidator.IsValidUserName(userName))
            {
                MessageBox.Show("Invalid user name!");
                // notify error
                return;
            }
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Invalid Full-Name");
                return;
            }

            if (!DataValidator.IsValidFullName(fullName))
            {
                MessageBox.Show("Invalid user name!");
                textBoxFullName.Focus();
                return;
            }

            if (!password.Equals(passwordConfirm, StringComparison.Ordinal))
            {
                MessageBox.Show("Invalid password!");
                return;
            }

            if (comboBoxTypeUser.SelectedItem == null)
            {
                MessageBox.Show("Select type user!");
                comboBoxTypeUser.Focus();
                return;
            }

            Province province = ((DisplayItem<Province>)comboBoxProvince.SelectedItem).Item;
            TypeUser typeUser = ((DisplayItem<TypeUser>)comboBoxTypeUser.SelectedItem).Item;

            (string hashPassword, string salt) = PwdUtils.GetSaltyPassword(password);
            User user = new User
            {
                Enabled = true,
                Name = userName,
                FullName = fullName,
                Password = hashPassword,
                DateCreation = DateTime.Now,
                Type = typeUser,
                ProvinceId = comboBoxProvince.Enabled ? province.Id : 0,// 0 is none for non-admin users
                OwnerId = _userContext.ID,
                Salt = salt
            };

            _userContext.VoteDbContext.Users.Add(user);
            _userContext.VoteDbContext.SaveChanges();
            MessageBox.Show("User added");

            UpdateUserView();

        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            User selUser = ((DisplayItem<User>)listBoxUsers.SelectedItem).Item;

            if (selUser == null)
            {
                return;
            }

            textBoxEditLogin.Text = selUser.Name;
            textBoxEditFullName.Text = selUser.FullName;
            checkBoxEnableEditUser.Checked = selUser.Enabled;

            bool isNotSel = _userContext.ID != selUser.Id;
            checkBoxEnableEditUser.Enabled = isNotSel;
            buttonRemoveUser.Enabled = isNotSel;
            textBoxEditPasswowrd.Text = string.Empty;
        }

        public void InitUI()
        {
            // set banners color
            //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            comboBoxProvince.BeginUpdate();
            comboBoxProvince.Items.Clear();
            comboBoxTypeUser.BeginUpdate();
            comboBoxTypeUser.Items.Clear();

            //foreach (var user in _userContext.VoteDbContext.Users.Where(user => user.OwnerId == _userContext.User.Id || user.Id == _userContext.User.Id).OrderBy(user => user.Name))
            //{
            //    listBoxUsers.Items.Add(new DisplayItem<User>(user));
            //}
            UpdateUserView();

            foreach (Province province in _userContext.VoteDbContext.Provinces)
            {
                comboBoxProvince.Items.Add(new DisplayItem<Province>(province));
            }

            foreach (string item in Enum.GetNames(typeof(TypeUser)))
            {
                TypeUser obj = (TypeUser)Enum.Parse(typeof(TypeUser), item);
                DisplayItem<TypeUser> displayItem = new DisplayItem<TypeUser>(obj)
                {
                    DisplayProperty = item,
                };
                comboBoxTypeUser.Items.Add(displayItem);
            }

            comboBoxProvince.EndUpdate();
            comboBoxTypeUser.EndUpdate();
        }

        private void UpdateUserView()
        {
            listBoxUsers.BeginUpdate();
            listBoxUsers.Items.Clear();
            foreach (User user in _userContext.VoteDbContext.Users)
            {
                listBoxUsers.Items.Add(new DisplayItem<User>(user));
            }
            listBoxUsers.EndUpdate();
        }

        private void ComboBoxTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeUser typeUser = ((DisplayItem<TypeUser>)comboBoxTypeUser.SelectedItem).Item;
            comboBoxProvince.Enabled = typeUser == TypeUser.Admin;

            if (comboBoxProvince.Enabled && comboBoxProvince.Items.Count > 0)
            {
                comboBoxProvince.SelectedIndex = 0;
            }

        }

    }
}