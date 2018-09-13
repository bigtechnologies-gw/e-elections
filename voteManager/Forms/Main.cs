using System;
using System.Linq;
using System.Windows.Forms;

namespace voteManager
{
    public partial class Main : Form
    {
        private readonly voteAppEntities _voteEntities;
        private readonly User _loginUser;

        public Main(voteAppEntities voteEntities, User loginUser)
        {
            InitializeComponent();

            FormClosed += Main_FormClosed;
            _voteEntities = voteEntities;
            _loginUser = loginUser;

            if (!(loginUser.Type == TypeUser.Admin || loginUser.Type == TypeUser.Sytem))
            {
                groupBox6.Enabled = false;
            }
            else
            {
                groupBox6.Enabled = true;
            }

            // load async
            UpdateListPartidos();

            UpdateUI();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner?.Show();
        }

        private void buttonAddPartidos_Click(object sender, EventArgs e)
        {
            // validate partidos
            string partido = textBoxPartidos.Text.Trim();

            // check if partido with that name doesn't already exit

            if (_voteEntities.partidos.Any(p => p.name.Equals(partido, StringComparison.OrdinalIgnoreCase)))
            {
                // partido already exists
                MessageBox.Show("partido* already exists", "Duplicated partido*", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // send to db
            _voteEntities.partidos.Add(new partido() { name = partido });

            // todo: save changes async
            _voteEntities.SaveChanges();

            // update listview
            UpdateListPartidos();
        }

        private void UpdateListPartidos()
        {
            listBoxPartidos.BeginUpdate();
            comboBoxPeritidos.BeginUpdate();

            // remove all pre-existing items from controls
            listBoxPartidos.Items.Clear();
            comboBoxPeritidos.Items.Clear();

            foreach (var part in _voteEntities.partidos.OrderBy(p => p.name))
            {
                listBoxPartidos.Items.Add(part);
                comboBoxPeritidos.Items.Add(part);
            }

            comboBoxPeritidos.EndUpdate();
            listBoxPartidos.EndUpdate();
        }

        private void buttonRemovePartido_Click(object sender, EventArgs e)
        {
            var partido = listBoxPartidos.SelectedItem as partido;

            if (partido == null)
            {
                MessageBox.Show("Select a partido*", "No partido selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (partido != null)
            {
                // remove from listview
                listBoxPartidos.Items.RemoveAt(listBoxPartidos.SelectedIndex);
                // remove from database (warm user that all the data linked with the *partido will be delete aswell.
                _voteEntities.partidos.Remove(partido);
                //_voteModel.SaveChanges();
            }

            // remove partido from combobox partiso
            for (int i = comboBoxPeritidos.Items.Count - 1; i >= 0; i--)
            {
                var it = comboBoxPeritidos.Items[i] as partido;
                if (it?.name.Equals(partido.name, StringComparison.Ordinal) == true)
                {
                    comboBoxPeritidos.Items.RemoveAt(i);
                    break;
                }
            }
            _voteEntities.SaveChanges();

            // TODO: Make sure all the date from the partido is also removed from the database?
            // NOTE: vote-table doesn't have any relatioship with other table with means the data
            // would still be stored even after the we remove *partido.
        }

        public void UpdateUI()
        {
            comboBoxRegions.BeginUpdate();
            comboBoxRegions.Items.Clear();
            IOrderedQueryable<Region> userRegions = null;
            switch (_loginUser.Type)
            {
                case TypeUser.Admin:
                case TypeUser.Standard:
                    userRegions = _voteEntities.Regions.Where(region => region.idProvince == _loginUser.ProvinceId).OrderBy(region => region.Name);
                    break;
                case TypeUser.Sytem:
                    userRegions = _voteEntities.Regions;
                    break;
            }
            if (_loginUser.Type == TypeUser.Admin || _loginUser.Type == TypeUser.Standard || _loginUser.Type == TypeUser.Sytem)
            {
                foreach (Region Region in userRegions)
                {
                    comboBoxRegions.Items.Add(Region);
                }
            }
            else
            {
                groupBoxAddUser.Enabled = false;
            }

            if (comboBoxRegions.Items.Count > 0)
            {
                comboBoxRegions.SelectedIndex = 0;
            }

            // if there is only one region, select it and display radion-button region
            comboBoxRegions.EndUpdate();

            if (comboBoxPeritidos.Items.Count > 0)
            {
                comboBoxPeritidos.SelectedIndex = 0;
            }

            UpdateListViewVotes(userRegions);
        }

        private void buttonAddVote_Click(object sender, EventArgs e)
        {
            int votes;
            string voteData = textBoxVote.Text; // .TrimStart('0'); // TODO: Uncomment
            if (!int.TryParse(voteData, out votes))
            {
                // invalid data entered
                MessageBox.Show("Invalid data!");
                return;
            }

            int idPartido = ((partido)comboBoxPeritidos.SelectedItem).Id;
            int idRegion = ((Region)comboBoxRegions.SelectedItem).Id;
            int idSector = ((sector)comboBoxSectors.SelectedItem).Id;
            int idCE = ((CE)comboBoxCE.SelectedItem).Id;
            int idTable = ((voteTable)comboBoxTable.SelectedItem).Id;
            int provinceId = _loginUser.ProvinceId;

            // check if vote isn't already inserted
            bool isInDatabase = _voteEntities.votes.Any(v => v.idPartido == idPartido
            && v.idRegion == idRegion && v.idSector == idSector
            && v.idCE == idCE && v.idVoteTable == idTable);

            if (isInDatabase)
            {
                MessageBox.Show("Vote already in data base", "Vote already in DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // refresh listview
                return;
            }

            var vote = new vote
            {
                idPartido = idPartido,
                idRegion = idRegion,
                idSector = idSector,
                idCE = idCE,
                idVoteTable = idTable,
                voteData = votes,
                provinceId = _loginUser.ProvinceId
            };

            _voteEntities.votes.Add(vote);
            _voteEntities.SaveChanges();
            UpdateListViewVotes();
            MessageBox.Show("Vote added!", "Vote added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxVote.Text = string.Empty;
        }

        private void comboBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSectors.BeginUpdate();
            // comboBoxTable.BeginUpdate();

            comboBoxSectors.Items.Clear();
            comboBoxCE.Items.Clear();

            var Region = comboBoxRegions.SelectedItem as Region;

            foreach (var sector in Region.sectors)
            {
                comboBoxSectors.Items.Add(sector);
            }
            if (comboBoxSectors.Items.Count > 0)
            {
                comboBoxSectors.SelectedIndex = 0;
            }
            comboBoxSectors.EndUpdate();
        }

        private void comboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxCE.Enabled = true;

            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            var sector = comboBoxSectors.SelectedItem as sector;
            // todo: remove this check.
            if (sector == null)
            {
                return;
            }
            foreach (var ce in sector.CEs)
            {
                comboBoxCE.Items.Add(ce);
            }
            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }
            comboBoxCE.EndUpdate();
        }

        private void comboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTable.BeginUpdate();
            comboBoxTable.Items.Clear();
            var ce = comboBoxCE.SelectedItem as CE;

            foreach (var table in ce.voteTables)
            {
                comboBoxTable.Items.Add(table);
            }

            if (comboBoxTable.Items.Count > 0)
            {
                comboBoxTable.SelectedIndex = 0;
            }

            comboBoxTable.EndUpdate();
            // add data to vote-table
        }

        private void textBoxVote_KeyDown(object sender, KeyEventArgs e)
        {
            // only allow number to be entered
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers != Keys.Shift) ||
                (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 ||
                 e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5 ||
                 e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 ||
                 e.KeyCode == Keys.NumPad9))
            {
                // present it from be sent to child controls (would still display the char in textbox)
                e.Handled = true;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
            // note: could be achived with marsked-textbox-control
        }

        private void tabControlMenu_Selected(object sender, TabControlEventArgs e)
        {
            listBoxUsers.BeginUpdate();
            listBoxUsers.Items.Clear();
            foreach (var login in _voteEntities.Users.Where(user => user.OwnerId == _loginUser.Id || user.Id == _loginUser.Id).OrderBy(user => user.Name))
            {
                listBoxUsers.Items.Add(login);
            }
            listBoxUsers.EndUpdate();
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
            User user = listBoxUsers.SelectedItem as User;
            if (user == null)
            {
                return;
            }
            _voteEntities.Users.Remove(user);
            listBoxUsers.Items.RemoveAt(listBoxUsers.SelectedIndex);
            _voteEntities.SaveChanges();
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

            var selUser = listBoxUsers.SelectedItem as User;

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
            _loginUser.Name = userName ?? _loginUser.Name;
            _loginUser.FullName = fullName ?? _loginUser.FullName;
            _loginUser.Password = password ?? _loginUser.Password;

            _voteEntities.SaveChanges();

            //_voteEntities.Entry(null).

            // TODO:
            // - any use an updates it's info 
            // - admin can disable any-use he/she created
            // - admin can enable/disble any-user he/she created
            // - login-user cannot enable/disable itself

            // update UI
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            // Add standard user to same province as logged in user.
            string userName = textBoxUserName.Text.Trim();
            string fullName = textBoxFullName.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string passwordConfirm = textBoxConfirmPassword.Text.Trim();

            if (_voteEntities.Users.Any(u => u.Name.Equals(userName, StringComparison.Ordinal)))
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
                // notify error
                return;
            }

            if (!password.Equals(passwordConfirm, StringComparison.Ordinal))
            {
                // message user password doesn't match
                return;
            }

            // NOTE: by default use same province as admin
            var user = new User
            {
                Enabled = true,
                Name = userName,
                FullName = fullName,
                Password = password,
                DateCreation = DateTime.Now,
                Type = TypeUser.Standard,
                ProvinceId = _loginUser.ProvinceId,
                OwnerId = _loginUser.Id
            };

            _voteEntities.Users.Add(user);
            _voteEntities.SaveChanges();

            MessageBox.Show("User added");
        }

        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }

        public void UpdateListViewVotes(IQueryable<Region> userRegions = null)
        {
            // create groups
            if (userRegions != null)
            {
                listViewVotes.BeginUpdate();
                listViewVotes.Groups.Clear();
                foreach (var Region in userRegions)
                {
                    var lvg = new ListViewGroup($"group{Region.Name}", Region.Name);
                    lvg.Tag = Region;
                    listViewVotes.Groups.Add(lvg);
                }
                listViewVotes.EndUpdate();
            }

            listViewVotes.BeginUpdate();
            listViewVotes.Items.Clear();

            // UNDONE: _voteEntities.votes.GroupBy(v => v.idPartido).OrderBy(v => v.Key);

            foreach (vote vote in _voteEntities.votes.OrderBy(v => v.idSector))
            {
                var partido = _voteEntities.partidos.First(p => p.Id == vote.idPartido);
                var sector = _voteEntities.sectors.First(p => p.Id == vote.idSector);
                var ce = _voteEntities.CEs.First(p => p.Id == vote.idCE);
                var voteTable = _voteEntities.voteTables.First(p => p.Id == vote.idVoteTable);

                var lvi = new ListViewItem(partido.name)
                {
                    SubItems = { sector.name, ce.Id.ToString(), voteTable.ToString(), vote.voteData.ToString() }
                };

                foreach (ListViewGroup lvg in listViewVotes.Groups)
                {
                    if (((Region)lvg.Tag).Id == sector.RegionId)
                    {
                        lvi.Group = lvg;
                        break;
                    }
                }

                listViewVotes.Items.Add(lvi);
            }

            listViewVotes.EndUpdate();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            var selUser = listBoxUsers.SelectedItem as User;

            if (selUser == null)
            {
                return;
            }

            textBoxEditLogin.Text = selUser.Name;
            textBoxEditFullName.Text = selUser.FullName;
            checkBoxEnableEditUser.Checked = selUser.Enabled;

            bool isNotSel = _loginUser.Id != selUser.Id;
            checkBoxEnableEditUser.Enabled = isNotSel;
            buttonRemoveUser.Enabled = isNotSel;
        }


        #region Tab one

        #endregion

        #region Tab two

        #endregion
    }
}

// if user is admin of region east he/she can only see sectros/ce/voting-table from east-region