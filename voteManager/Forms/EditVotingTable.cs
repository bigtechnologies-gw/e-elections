using System;
using System.Linq;
using System.Windows.Forms;
using VoteManager.Helpers;

namespace VoteManager.Forms
{
    public partial class EditVotingTable : Form
    {
        public EditVotingTable(User userAdmin)
        {
            InitializeComponent();

            comboBoxRegion.BeginUpdate();
            comboBoxRegion.Items.Clear();

            var regionsFiltered = userAdmin.Type == TypeUser.SuperAdmin ? DbUtils.AppEntities.Regions : DbUtils.AppEntities.Regions.Where(r => r.idProvince == userAdmin.ProvinceId);

            foreach (var region in regionsFiltered)
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

            CE selCe = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;

            //validate name
            if (selCe.voteTables.Any(vt => vt.Name.Equals(votingTableName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("ALREADY ADDED!");
                return;
            }

            CE sector = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;

            sector.voteTables.Add(new VoteTable
            {
                Name = votingTableName,
            });

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
            var selSector = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;
            foreach (var vt in selSector.voteTables)
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

            var selItem = ((DisplayItem<VoteTable>)listBoxVotingTable.SelectedItem).Item;

            if (selItem == null)
            {
                return;
            }

            textBoxVotingTableName.Text = selItem.Name;
            foreach (var item in comboBoxCE.Items)
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
            var region = ((DisplayItem<Region>)comboBoxRegion.SelectedItem).Item;
            comboBoxSector.BeginUpdate();
            comboBoxSector.Items.Clear();
            foreach (var sector in region.sectors)
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
            var sector = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;
            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            foreach (var ce in sector.CEs)
            {
                comboBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            comboBoxCE.EndUpdate();

            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }
        }

        private void comboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ignore
        }
    }
}
