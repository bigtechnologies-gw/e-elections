using EElections.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class EditVotingTable : Form
    {
        public EditVotingTable(User userAdmin)
        {
            InitializeComponent();

            Paint += (sender, e) =>
            {
                // draw top banner
                SolidBrush primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
                SolidBrush secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

                // draw bottom banner
                e.Graphics.FillRectangle(primaryBrush, 0, 0, Width, 25);
                e.Graphics.FillRectangle(secondaryBrush, 0, ClientRectangle.Height - 25, Width, 25);
            };

            textBoxRegistedVoters.KeyDown += UIUtils.TextBoxKeyDownHandler;
            textBoxInvalidVotes.KeyDown += UIUtils.TextBoxKeyDownHandler;

            MaximizeBox = false;
            //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            IQueryable<Region> regionsFiltered = userAdmin.Type == TypeUser.SuperAdmin ? DbUtils.AppEntities.Regions : DbUtils.AppEntities.Regions.Where(r => r.idProvince == userAdmin.ProvinceId);
            comboBoxRegion.BeginUpdate();
            comboBoxRegion.Items.Clear();
            foreach (Region region in regionsFiltered)
            {
                comboBoxRegion.Items.Add(new DisplayItem<Region>(region));
            }
            comboBoxRegion.EndUpdate();
            if (comboBoxRegion.Items.Count > 0)
            {
                comboBoxRegion.SelectedIndex = 0;
            }

            UpdateListBox();
        }

        private void ButtonAddModify_Click(object sender, EventArgs e)
        {

            if (comboBoxCE.SelectedItem == null)
            {
                MessageBox.Show("Please select a CE");
                comboBoxCE.Focus();
                return;
            }

            string votingTableName = textBoxVotingTableName.Text;

            int invalidVotes = Convert.ToInt32(textBoxInvalidVotes.Text);
            int registedVoters = Convert.ToInt32(textBoxRegistedVoters.Text); // recensiado


            CE selCe = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;

            voteAppEntities dbContext = DbUtils.AppEntities;

            // try select table with same name if doesn't already exits (add new one)
            // if table already exits modify the properties only


            VoteTable workingVoteTable = dbContext.VoteTables.FirstOrDefault(vt => vt.Name == votingTableName);

            if (workingVoteTable == null)
            {
                workingVoteTable = new VoteTable
                {
                    Name = votingTableName,
                    InvalidVotes = invalidVotes,
                    TotalRegisted = registedVoters
                };

                selCe.voteTables.Add(workingVoteTable);
            }
            else
            {
                // refresh info
                workingVoteTable.Name = votingTableName;
                workingVoteTable.InvalidVotes = invalidVotes;
                workingVoteTable.TotalRegisted = registedVoters;
            }

            DbUtils.AppEntities.SaveChanges();

            UpdateListBox();
        }

        private void UpdateListBox()
        {
            if (comboBoxCE.SelectedItem == null)
            {
                return;
            }
            listBoxVotingTable.BeginUpdate();
            listBoxVotingTable.Items.Clear();
            CE selSector = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;
            foreach (VoteTable vt in selSector.voteTables)
            {
                listBoxVotingTable.Items.Add(new DisplayItem<VoteTable>(vt));
            }
            listBoxVotingTable.EndUpdate();
        }

        private void ListBoxVotingTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxVotingTable.Items.Count == 0)
            {
                return;
            }

            if (listBoxVotingTable.SelectedItems.Count == 0)
            {
                return;
            }

            VoteTable selItem = ((DisplayItem<VoteTable>)listBoxVotingTable.SelectedItem).Item;

            if (selItem == null)
            {
                return;
            }

            textBoxVotingTableName.Text = selItem.Name;
            textBoxInvalidVotes.Text = selItem.InvalidVotes.ToString();
            textBoxRegistedVoters.Text = selItem.TotalRegisted.ToString();
            foreach (object item in comboBoxCE.Items)
            {
                if (item.ToString().Equals(selItem.CE.Name, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxCE.SelectedItem = item;
                    break;
                }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Region region = ((DisplayItem<Region>)comboBoxRegion.SelectedItem).Item;
            comboBoxSector.BeginUpdate();
            comboBoxSector.Items.Clear();
            foreach (Sector sector in region.sectors)
            {
                comboBoxSector.Items.Add(new DisplayItem<Sector>(sector));
            }
            comboBoxSector.EndUpdate();

            if (comboBoxSector.Items.Count > 0)
            {
                comboBoxSector.SelectedIndex = 0;
            }
        }

        private void ComboBoxSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sector sector = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;
            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            foreach (CE ce in sector.CEs)
            {
                comboBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            comboBoxCE.EndUpdate();

            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }
        }

        private void ComboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ignore
        }
    }
}
