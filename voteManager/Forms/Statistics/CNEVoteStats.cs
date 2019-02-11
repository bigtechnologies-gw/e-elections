using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using EElections.Enums;
using EElections.Helpers;

namespace EElections.Forms.Statistics
{
    public partial class CNEVoteStats : Form
    {
        private readonly voteAppEntities DbContext;

        public CNEVoteStats()
        {
            InitializeComponent();

            DbContext = DbUtils.AppEntities;

            InitUI();

            PopulateListView();
        }

        private void PopulateListView()
        {
            string selValue = (string)comboBoxStatsType.SelectedItem;
            if (string.IsNullOrEmpty(selValue))
            {
                Debug.WriteLine($"{nameof(selValue)} is null/empty");
                return;
            }

            DisplayType dt = (DisplayType)Enum.Parse(typeof(DisplayType), selValue);

            listViewStats.BeginUpdate();
            listViewStats.Items.Clear();

            switch (dt)
            {
                case DisplayType.Província:
                    foreach (Province province in DbContext.Provinces.OrderBy(p => p.Name))
                    {
                        //comboBoxStatsType.Items.Add(new DisplayItem<Province>(province));
                        listViewStats.Items.Add(province.Name);
                    }
                    break;

                case DisplayType.Região:
                    foreach (Region region in DbContext.Regions.OrderBy(r => r.Name))
                    {
                        listViewStats.Items.Add(region.Name);
                    }
                    //Calculate(dt);
                    break;

                case DisplayType.Sector:
                    foreach (Sector sector in DbContext.Sectors.OrderBy(s => s.Name))
                    {
                        listViewStats.Items.Add(sector.Name);
                    }
                    break;

                case DisplayType.CE:
                    foreach (CE ce in DbContext.CEs.OrderBy(ce => ce.Name))
                    {
                        listViewStats.Items.Add(ce.Name);
                    }
                    break;

                case DisplayType.Mesa:
                    foreach (VoteTable table in DbContext.VoteTables.OrderBy(vt => vt.Name))
                    {
                        listViewStats.Items.Add(table.Name);
                    }
                    break;
            }

            listViewStats.EndUpdate();

        }

        private void InitUI()
        {
            // set the banner color
            panel1.BackColor = Configurations.PartieInfo.PrimaryColor;
            statusStrip1.BackColor = Configurations.PartieInfo.SecondaryColor;

            // init comboboxs
            comboBoxStatsType.BeginUpdate();
            comboBoxStatsType.Items.Clear();

            foreach (string displayType in Enum.GetNames(typeof(DisplayType)))
            {
                comboBoxStatsType.Items.Add(displayType);
            }
            comboBoxStatsType.EndUpdate();

            if (comboBoxStatsType.Items.Count > 0)
            {
                comboBoxStatsType.SelectedIndex = 0;
            }

            comboBoxStatsType.EndUpdate();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxStatsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void Calculate(DisplayType dt)
        {
            //throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
