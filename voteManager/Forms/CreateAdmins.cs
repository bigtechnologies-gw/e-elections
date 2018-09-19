using System;
using System.Linq;
using System.Windows.Forms;

namespace VoteManager.Forms
{
    public partial class CreateAdminForm : Form
    {
        private readonly CreateAdminConfigurations _configs;

        /// <summary>
        /// Created user.
        /// </summary>
        public User User { get; set; }

        public CreateAdminForm(CreateAdminConfigurations configs)
        {
            InitializeComponent();

            _configs = configs;
            InitUI(configs.TypeUser);
            Text = configs.Title;
        }

        private void InitUI(TypeUser typsUser)
        {
            LayoutButtons();

            if (typsUser == TypeUser.SuperAdmin)
            {
                labelProvince.Enabled = false;
                labelProvince.Visible = false;
                comboBoxProvince.Enabled = false;
                comboBoxProvince.Visible = false;
            }
            else
            {
                using (var dbContext = new voteAppEntities())
                {
                    foreach (var province in dbContext.Provinces)
                    {
                        comboBoxProvince.Items.Add(new DisplayItem<Province>(province));
                    }
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // validation
            string userName = textBoxUserName.Text;
            string fullName = textBoxFullName.Text;
            string password = textBoxPassword.Text;
            string passwordConfirm = textBoxConfirmPassword.Text;

            if (!DataValidator.IsValidUserName(userName))
            {

                return;
            }
            if (!DataValidator.IsValidName(fullName))
            {

                return;
            }
            if (!DataValidator.IsValidPassword(password, passwordConfirm))
            {

                return;
            }


            bool isProvinceAdmin = _configs.TypeUser == TypeUser.Admin;

            if (isProvinceAdmin && comboBoxProvince.SelectedItem == null)
            {
                return;
            }

            // create new super admin
            var newUser = new User
            {
                DateCreation = DateTime.Now,
                FullName = fullName,
                Password = password, // todo: hash
                Enabled = true,
                Name = userName,
                Salt = string.Empty,
                Type = isProvinceAdmin ? TypeUser.Admin : TypeUser.SuperAdmin,
                OwnerId = 0,
                ProvinceId = isProvinceAdmin ? ((DisplayItem<Province>)comboBoxProvince.SelectedItem).Item.Id : 0
            };

            using (var dbContext = new voteAppEntities())
            {
                // check if admin for the selected province doesn't already exits
                if (_configs.TypeUser == TypeUser.Admin)
                {
                    if (dbContext.Users.Any(user => user.ProvinceId == newUser.ProvinceId))
                    {
                        MessageBox.Show("Province already contain a admin, please choose another province");
                        // diselect selected province
                        return;
                    }
                }
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                User = newUser;
            }

            MessageBox.Show("User added succesfully", "User added with success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_configs.TypeUser == TypeUser.SuperAdmin)
            {
                buttonButtonOK_Click(null, null);
            }
            else
            {
                ClearControls();
            }
        }

        private void buttonButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ClearControls()
        {
            foreach (var control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }

                if (control is ComboBox)
                {

                }
            }
        }

        private void LayoutButtons()
        {
            if (_configs.TypeUser == TypeUser.SuperAdmin)
            {
                buttonButtonOK.Enabled = false;
                buttonButtonOK.Visible = false;
                return;
            }

            buttonSubmit.Left = comboBoxProvince.Right + 10;
            buttonSubmit.Top = comboBoxProvince.Top;
            buttonSubmit.Text = "Add";

        }

    }

    public class CreateAdminConfigurations
    {
        public TypeUser TypeUser { get; set; }

        public string Title { get; set; }
    }
}
