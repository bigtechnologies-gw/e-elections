using System;
using System.Linq;
using System.Windows.Forms;

namespace voteManager.Forms
{
    public partial class CreateUser : Form
    {
        private readonly voteAppEntities _voteEntities;

        public CreateUser(voteAppEntities voteEntities)
        {
            InitializeComponent();
            _voteEntities = voteEntities;

            // populate province combobox

            comboBoxAdminProvince.BeginUpdate();
            foreach (var province in _voteEntities.Provinces.OrderBy(o => o.Name))
            {
                comboBoxAdminProvince.Items.Add(province);
            }
            if (comboBoxAdminProvince.Items.Count > 0)
            {
                comboBoxAdminProvince.SelectedIndex = 0;
            }
            comboBoxAdminProvince.EndUpdate();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            DataValidator.IsValidName(textBoxFullName.Text);
            DataValidator.IsValidPassword(textBoxPassword.Text, textBoxConfirmPassword.Text);
            DataValidator.IsValidUserName(textBoxUserName.Text);
            Province province = (Province)comboBoxAdminProvince.SelectedItem;

            // user System.Security.SecureString to store password
            if (_voteEntities.Users.Any(user => user.ProvinceId == province.Id))
            {
                MessageBox.Show($"Admin already exits for province: {province.Name}");
                return;
            }

            var newUser = new User
            {
                Name = textBoxUserName.Text,
                FullName = textBoxFullName.Text,
                Password = textBoxPassword.Text,
                Enabled = true,
                DateCreation = DateTime.Now,
                ProvinceId = province.Id,
                Salt = ""
            };

            _voteEntities.Users.Add(newUser);

            _voteEntities.SaveChanges();

            MessageBox.Show($"New admin for province {province.Name} is added");
            DialogResult = DialogResult.OK;
        }
    }
}
