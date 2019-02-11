using EElections.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class EditVote : Form
    {
        public Vote Vote { get; }

        public EditVote(Vote vote, User user)
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

            Vote = vote;
            MaximizeBox = false;
            InitUI();
        }

        private void InitUI()
        {
            voteAppEntities DbContext = DbUtils.AppEntities;

            // combobox partido
            comboBoxPartidos.BeginUpdate();
            comboBoxPartidos.Items.Clear();
            foreach (Partido partie in DbContext.Partidos)
            {
                comboBoxPartidos.Items.Add(new DisplayItem<Partido>(partie));
            }
            comboBoxPartidos.EndUpdate();
            if (comboBoxPartidos.Items.Count > 0)
            {
                comboBoxPartidos.SelectedIndex = 0;
            }

            IQueryable<Region> voteRegions = DbContext.Regions.Where(r => r.idProvince == Vote.provinceId);

            // combobox region
            comboBoxRegions.BeginUpdate();
            comboBoxRegions.Items.Clear();
            foreach (Region region in voteRegions)
            {
                comboBoxRegions.Items.Add(new DisplayItem<Region>(region));
            }
            comboBoxRegions.EndUpdate();

            textBoxVote.Text = Vote.voteData.ToString();

            // UNDONE: pre-select combobox items from vote information
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ComboBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Region selRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item;

            comboBoxSectors.BeginUpdate();
            comboBoxSectors.Items.Clear();

            foreach (Sector sector in selRegion.sectors)
            {
                comboBoxSectors.Items.Add(new DisplayItem<Sector>(sector));
            }

            comboBoxSectors.EndUpdate();

            if (comboBoxSectors.Items.Count > 0)
            {
                comboBoxSectors.SelectedIndex = 0;
            }
        }

        private void ComboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sector selSector = ((DisplayItem<Sector>)comboBoxSectors.SelectedItem).Item;

            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();

            foreach (CE ce in selSector.CEs)
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
            CE selCE = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;

            comboBoxVotingTable.BeginUpdate();
            comboBoxVotingTable.Items.Clear();

            foreach (VoteTable voteTable in selCE.voteTables)
            {
                comboBoxVotingTable.Items.Add(new DisplayItem<VoteTable>(voteTable));
            }

            comboBoxVotingTable.EndUpdate();

            if (comboBoxVotingTable.Items.Count > 0)
            {
                comboBoxVotingTable.SelectedIndex = 0;
            }
        }

        private void ButtonAddVote_Click(object sender, EventArgs e)
        {
            Vote.idPartido = ((DisplayItem<Partido>)comboBoxPartidos.SelectedItem).Item.Id;
            Vote.idRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item.Id;
            Vote.idSector = ((DisplayItem<Sector>)comboBoxPartidos.SelectedItem).Item.Id;
            Vote.idCE = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item.Id;
            Vote.idVoteTable = ((DisplayItem<VoteTable>)comboBoxVotingTable.SelectedItem).Item.Id;

            DbUtils.AppEntities.SaveChanges();
            MessageBox.Show("Vot modified with successs!", "Modify vote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}
