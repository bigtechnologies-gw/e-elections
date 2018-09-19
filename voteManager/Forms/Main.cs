using System;
using System.Linq;
using System.Windows.Forms;
using VoteManager.Forms;
using VoteManager.Helpers;

namespace VoteManager
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
#if !DEBUG
            groupBoxAddVote.Enabled = loginUser.Type == TypeUser.Admin;
#endif
            InitUI();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner?.Show();
        }


        public void InitUI()
        {

            // partidos
            comboBoxPartidos.BeginUpdate();
            comboBoxPartidos.BeginUpdate();
            foreach (var partido in DbUtils.AppEntities.Partidos.OrderBy(p => p.Name))
            {
                comboBoxPartidos.Items.Add(new DisplayItem<Partido>(partido));
            }
            if (comboBoxPartidos.Items.Count > 0)
            {
                comboBoxPartidos.SelectedIndex = 0;
            }
            comboBoxPartidos.EndUpdate();

            // regions
            IOrderedQueryable<Region> userRegions = null;
            switch (_loginUser.Type)
            {
                case TypeUser.Admin:
                case TypeUser.Standard:
                    userRegions = _voteEntities.Regions.Where(region => region.idProvince == _loginUser.ProvinceId).OrderBy(region => region.Name);
                    break;
                case TypeUser.SuperAdmin:
                    userRegions = _voteEntities.Regions;
                    break;
            }

            //foreach (var region in userRegions)
            //{
            //    if (region == null)
            //    {
            //        MessageBox.Show("NULL REGION FOUND!");
            //        continue;
            //    }
            //    var lvg = new ListViewGroup($"group{region.Name}", region.Name)
            //    {
            //        Tag = Region
            //    };
            //    listViewVotes.Groups.Add(lvg);
            //}
            listViewVotes.EndUpdate();

            comboBoxRegions.BeginUpdate();
            comboBoxRegions.Items.Clear();
            foreach (var region in userRegions)
            {
                comboBoxRegions.Items.Add(new DisplayItem<Region>(region));

            }
            if (comboBoxRegions.Items.Count > 0)
            {
                comboBoxRegions.SelectedIndex = 0;
            }
            // if there is only one region, select it and display radion-button region
            comboBoxRegions.EndUpdate();

            // update settings content

            // only super-admin has the rights to modify entities.
            if (_loginUser.Type != TypeUser.SuperAdmin)
            {
                for (int i = settingsToolStripMenuItem.DropDownItems.Count - 1; i >= 0; i--)
                {
                    // TODO: verify & remove
                    settingsToolStripMenuItem.DropDownItems.RemoveAt(i);
                }
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

            int idPartido = ((DisplayItem<Partido>)comboBoxPartidos.SelectedItem).Item.Id;
            int idRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item.Id;
            int idSector = ((DisplayItem<Sector>)comboBoxSectors.SelectedItem).Item.Id;
            int idCE = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item.Id;
            int idTable = ((DisplayItem<VoteTable>)comboBoxVotingTable.SelectedItem).Item.Id;
            int provinceId = _loginUser.ProvinceId;

            // check if vote isn't already inserted
            bool isInDatabase = _voteEntities.Votes.Any(v => v.idPartido == idPartido
            && v.idRegion == idRegion && v.idSector == idSector
            && v.idCE == idCE && v.idVoteTable == idTable);

            if (isInDatabase)
            {
                MessageBox.Show("Vote already in data base", "Vote already in DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // refresh listview
                return;
            }

            var vote = new Vote
            {
                idPartido = idPartido,
                idRegion = idRegion,
                idSector = idSector,
                idCE = idCE,
                idVoteTable = idTable,
                voteData = votes,
                provinceId = provinceId
            };

            _voteEntities.Votes.Add(vote);
            _voteEntities.SaveChanges();
            UpdateListViewVotes();
            MessageBox.Show("Vote added!", "Vote added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxVote.Text = string.Empty;
        }

        private void ComboBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSectors.BeginUpdate();
            comboBoxSectors.Items.Clear();

            var selRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item;
            if (selRegion == null)
            {
                return;
            }
            foreach (var sector in selRegion.sectors)
            {
                comboBoxSectors.Items.Add(new DisplayItem<Sector>(sector));
            }
            if (comboBoxSectors.Items.Count > 0)
            {
                comboBoxSectors.SelectedIndex = 0;
            }

            comboBoxSectors.EndUpdate();
        }

        private void ComboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            var sector = ((DisplayItem<Sector>)comboBoxSectors.SelectedItem).Item;
            // todo: remove this check.
            if (sector == null)
            {
                return;
            }
            foreach (var ce in sector.CEs)
            {
                comboBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }
            comboBoxCE.EndUpdate();
        }

        private void ComboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVotingTable.BeginUpdate();
            comboBoxVotingTable.Items.Clear();
            var ce = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;
            foreach (var table in ce.voteTables)
            {
                comboBoxVotingTable.Items.Add(new DisplayItem<VoteTable>(table));
            }
            if (comboBoxVotingTable.Items.Count > 0)
            {
                comboBoxVotingTable.SelectedIndex = 0;
            }
            comboBoxVotingTable.EndUpdate();
            // add data to vote-table
        }

        private void TextBoxVote_KeyDown(object sender, KeyEventArgs e)
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
            // Note: could be achived with marsked-textbox-control
        }

        public void UpdateListViewVotes(IQueryable<Region> userRegions = null)
        {
            listViewVotes.BeginUpdate();
            listViewVotes.Items.Clear();

            // UNDONE: _voteEntities.votes.GroupBy(v => v.idPartido).OrderBy(v => v.Key);

            foreach (Vote vote in _voteEntities.Votes.OrderBy(v => v.idSector))
            {
                if (vote == null)
                {
                    continue;
                }

                var partido = _voteEntities.Partidos.FirstOrDefault(p => p.Id == vote.idPartido);
                var sector = _voteEntities.Sectors.FirstOrDefault(p => p.Id == vote.idSector);
                var ce = _voteEntities.CEs.FirstOrDefault(p => p.Id == vote.idCE);
                var voteTable = _voteEntities.VoteTables.FirstOrDefault(p => p.Id == vote.idVoteTable);

                if (partido == null || sector == null || ce == null || voteTable == null)
                {
                    continue;
                }

                var lvi = new ListViewItem(partido.Name)
                {
                    SubItems = { sector.Name, ce.Name, voteTable.Name, vote.voteData.ToString() }
                };

                //foreach (ListViewGroup lvg in listViewVotes.Groups)
                //{
                //    if (!(lvg.Tag is Region))
                //    {
                //        continue;
                //    }

                //    if (((Region)lvg.Tag).Id == sector.RegionId)
                //    {
                //        lvi.Group = lvg;
                //        break;
                //    }

                //}

                listViewVotes.Items.Add(lvi);
            }

            listViewVotes.EndUpdate();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userContext = new LoginUserContext(_loginUser)
            {
                VoteDbContext = _voteEntities,
                LoginTime = DateTime.Now,
                User = _loginUser,
            };

            //using (var settings = new Settings(_userContet)
            ////{

            ////}
        }

        private void EditPartidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var editPartido = new EditPartidos())
            {
                editPartido.ShowDialog(this);
            }
        }

        private void EditCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var editCE = new EditCE(_loginUser))
            {
                editCE.ShowDialog(this);
            }
        }

        private void EditVotingTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var editVotingTable = new EditVotingTable(_loginUser))
            {
                editVotingTable.ShowDialog(this);
            }
        }

        private void ManageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // NOTE: ONLY SUPERADMIN HAS THE RIGHT TO INVOKE THIS METHOD
#if !DEBUG
            if (_loginUser.Type != TypeUser.SuperAdmin)
            {
                return;
            } 
#endif

            // TODO: this should be precomputed
            var userContext = new LoginUserContext(_loginUser)
            {
                MachineName = Environment.MachineName,
                LoginTime = DateTime.Now, // Incorrect!
                VoteDbContext = DbUtils.AppEntities
            };

            using (var formEditUsers = new EditUserSettings(userContext))
            {
                if (formEditUsers.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var formStats = new Statistics(_loginUser))
            {
                formStats.ShowDialog(this);
            }
        }

        private void CostumizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var costumizeForm = new CustomForm())
            {
                if (costumizeForm.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }
    }
}

// if user is admin of region east he/she can only see sectros/ce/voting-table from east-region