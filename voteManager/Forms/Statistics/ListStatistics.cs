using EElections.Enums;
using EElections.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//using System.Linq.Expressions;

namespace EElections.Forms.Statistics
{
    public partial class GlobalStats : Form
    {
        private readonly User _user;

        private Dictionary<int, long> _mapTotalVote;

        public GlobalStats(User user)
        {
            InitializeComponent();

            _mapTotalVote = new Dictionary<int, long>();

            // set banners color
            panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            comboBoxDisplayResultBy.BeginUpdate();
            comboBoxDisplayResultBy.Items.Clear();

            // init combobox display type (province, regions, sector, ce, voting-table)
            switch (user.Type)
            {
                case TypeUser.Standard:
                case TypeUser.SuperAdmin:
                    foreach (string name in Enum.GetNames(typeof(DisplayType)).Skip(1))
                    {
                        comboBoxDisplayResultBy.Items.Add(name);
                    }
                    break;

                case TypeUser.Admin:
                    foreach (string name in Enum.GetNames(typeof(DisplayType)).Skip(2))
                    {
                        comboBoxDisplayResultBy.Items.Add(name);
                    }
                    break;
            }

            _user = user;
            comboBoxDisplayResultBy.EndUpdate();
        }

        private void ComboBoxDisplayResultBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayType displayType = DisplayType.None;
            string SelItem = comboBoxDisplayResultBy.SelectedItem?.ToString();
            switch (_user.Type)
            {
                // note: can view stats from all provinces
                case TypeUser.Standard:
                    displayType = (DisplayType)Enum.Parse(typeof(DisplayType), SelItem);
                    break;

                case TypeUser.Admin:
                    displayType = (DisplayType)Enum.Parse(typeof(DisplayType), SelItem);
                    break;

                // TODO: Remove
                case TypeUser.SuperAdmin:
                    string selItem = comboBoxDisplayResultBy.SelectedItem.ToString();
                    displayType = (DisplayType)Enum.Parse(typeof(DisplayType), selItem);
                    break;
            }

            UpdateListViewColumns(displayType);
        }

        /// <summary>
        /// Available only for user that statistic user
        /// </summary>
        /// <param name="displayType"></param>
        private void UpdateListViewColumns(DisplayType displayType)
        {
            // NO VOTE IN DB!
            if (DbUtils.AppEntities.Votes.Any() == false)
            {
                return;
            }

            /* NOT REALLY!
            if (displayType == DisplayType.None)
            {
                listViewGlobalStats.BeginUpdate();
                listViewGlobalStats.Items.Clear();
                listViewGlobalStats.EndUpdate();
                return;
            }
            */

            listViewGlobalStats.BeginUpdate();
            listViewGlobalStats.Columns.Clear(); // !
            listViewGlobalStats.Items.Clear();

            listViewGlobalStats.Columns.Add("Partidos", 108, HorizontalAlignment.Center);

            // TODO: Keep this static!
            foreach (Partido partie in DbUtils.AppEntities.Partidos)
            {
                listViewGlobalStats.Items.Add(new ListViewItem(partie.Name)
                {
                    Tag = partie
                });
            }

            //var gfx = listViewGlobalStats.CreateGraphics();
            voteAppEntities dbContext = DbUtils.AppEntities;

            bool displayAll = _user.Type == TypeUser.SuperAdmin || _user.Type == TypeUser.Standard;
            IQueryable<Region> regions = dbContext.Regions.Where(r => r.idProvince == _user.ProvinceId || displayAll);

            switch (displayType)
            {
                case DisplayType.Província:
                    // init columns
                    foreach (Province province in DbUtils.AppEntities.Provinces.OrderBy(p => p.Id))
                    {
                        //var size = gfx.MeasureString(province.Name, listViewGlobalStats.Font);
                        //var width = (int)Math.Round(size.Width + 4.5);
                        listViewGlobalStats.Columns.Add(province.Name, 108, HorizontalAlignment.Center);
                    }
                    listViewGlobalStats.Columns.Add("Total", (int)Math.Round(108 * 1.5), HorizontalAlignment.Center);

                    // add datas
                    foreach (ListViewItem itemPartie in listViewGlobalStats.Items)
                    {
                        Partido partie = itemPartie.Tag as Partido;
                        long totalSum = dbContext.Votes.Where(v => v.idPartido == partie.Id).Sum(v => v.voteData);
                        itemPartie.SubItems.Add(totalSum.ToString());
                    }
                    break;

                case DisplayType.Região:

                    // add columns region
                    foreach (Region region in regions.OrderBy(r => r.Id))
                    {
                        listViewGlobalStats.Columns.Add(region.Name, 108, HorizontalAlignment.Center);
                    }

                    listViewGlobalStats.Columns.Add("Total", (int)Math.Round(108 * 1.5), HorizontalAlignment.Center);
                    foreach (ListViewItem itemPartie in listViewGlobalStats.Items)
                    {
                        Partido partie = itemPartie.Tag as Partido;
                        foreach (IGrouping<int, Vote> voteGroup in dbContext.Votes.Where(v => v.provinceId == _user.ProvinceId || displayAll).GroupBy(v => v.idRegion))
                        {
                            int sum = voteGroup.Where(v => v.idPartido == partie.Id).OrderBy(vote => vote.idRegion).Sum(v => v.voteData);
                            itemPartie.SubItems.Add(sum.ToString());
                        }
                        itemPartie.SubItems.Add(_mapTotalVote[partie.Id].ToString());
                    }
                    
                    break;

                case DisplayType.Sector:
                    foreach (Region item in regions)
                    {
                        foreach (Sector sector in item.sectors.OrderBy(sector => sector.Id))
                        {
                            listViewGlobalStats.Columns.Add(sector.Name, 108, HorizontalAlignment.Center);
                        }
                    }
                    listViewGlobalStats.Columns.Add("Total", (int)Math.Round(108 * 1.5), HorizontalAlignment.Center);

                    //foreach (var sector in regions.Sectors.Where(sec => sec.Region.idProvince == _user.ProvinceId || displayAll).OrderBy(sector => sector.Id))
                    //{
                    //    //var size = gfx.MeasureString(sector.Name, listViewGlobalStats.Font);
                    //    //var width = (int)Math.Round(size.Width + 4.5);
                    //    listViewGlobalStats.Columns.Add(sector.Name, 108, HorizontalAlignment.Center);
                    //    //listViewGlobalStats.Columns.Insert(listViewGlobalStats.Columns.Count, sector.Name);
                    //}

                    foreach (ListViewItem itemPartie in listViewGlobalStats.Items)
                    {
                        Partido partie = itemPartie.Tag as Partido;
                        foreach (IGrouping<int, Vote> voteGroup in dbContext.Votes.Where(v => v.provinceId == _user.ProvinceId || displayAll).GroupBy(v => v.idSector))
                        {
                            // voteGroup.Key == region
                            int result = voteGroup.Where(v => v.idPartido == partie.Id).OrderBy(vote => vote.idSector).Sum(v => v.voteData);
                            itemPartie.SubItems.Add(result.ToString());
                        }
                        itemPartie.SubItems.Add(_mapTotalVote[partie.Id].ToString());
                    }

                    //foreach (ListViewItem item in listViewGlobalStats.Items)
                    //{
                    //    var partie = (Partido)item.Tag;
                    //    var totalVote = dbContext.Votes.Where(v => v.Id == partie.Id).Sum(v => v.voteData);
                    //    item.SubItems.Add(totalVote.ToString());
                    //}

                    break;

                case DisplayType.CE:

                    foreach (CE ce in regions.SelectMany(s => s.sectors).SelectMany(ce => ce.CEs).OrderBy(ce => ce.Id))
                    {
                        //var size = gfx.MeasureString(ce.Name, listViewGlobalStats.Font);
                        //var width = (int)Math.Round(size.Width + 4.5);

                        listViewGlobalStats.Columns.Add(ce.Name, 108, HorizontalAlignment.Center);
                        //listViewGlobalStats.Columns.Insert(listViewGlobalStats.Columns.Count, ce.Name);
                    }
                    listViewGlobalStats.Columns.Add("Total", (int)Math.Round(108 * 1.5), HorizontalAlignment.Center);
                    foreach (ListViewItem itemPartie in listViewGlobalStats.Items)
                    {
                        Partido partie = itemPartie.Tag as Partido;
                        foreach (IGrouping<int, Vote> voteGroup in dbContext.Votes.Where(v => v.provinceId == _user.ProvinceId || displayAll).GroupBy(v => v.idCE))
                        {
                            // voteGroup.Key == region
                            int result = voteGroup.Where(v => v.idPartido == partie.Id).OrderBy(vote => vote.idCE).Sum(v => v.voteData);
                            itemPartie.SubItems.Add(result.ToString());
                        }
                        itemPartie.SubItems.Add(_mapTotalVote[partie.Id].ToString());
                    }
                    break;

                case DisplayType.Mesa:
                    foreach (VoteTable table in regions.SelectMany(s => s.sectors).SelectMany(ce => ce.CEs).OrderBy(ce => ce.Id).SelectMany(ce => ce.voteTables).OrderBy(vt => vt.Id))
                    {
                        //var size = gfx.MeasureString(table.Name, listViewGlobalStats.Font);
                        //var width = (int)Math.Round(size.Width + 4.5);
                        listViewGlobalStats.Columns.Add(table.Name, 108, HorizontalAlignment.Center);
                        //listViewGlobalStats.Columns.Insert(listViewGlobalStats.Columns.Count, table.Name);
                    }
                    listViewGlobalStats.Columns.Add("Total", (int)Math.Round(108 * 1.5), HorizontalAlignment.Center);
                    foreach (ListViewItem itemPartie in listViewGlobalStats.Items)
                    {
                        Partido partie = itemPartie.Tag as Partido;
                        foreach (IGrouping<int, Vote> voteGroup in dbContext.Votes.Where(v => v.provinceId == _user.ProvinceId || displayAll).GroupBy(v => v.idVoteTable))
                        {
                            // voteGroup.Key == region
                            int result = voteGroup.Where(v => v.idPartido == partie.Id).OrderBy(vote => vote.idVoteTable).Sum(v => v.voteData);
                            itemPartie.SubItems.Add(result.ToString());
                        }
                        itemPartie.SubItems.Add(_mapTotalVote[partie.Id].ToString());
                    }
                    //foreach (ListViewItem item in listViewGlobalStats.Items)
                    //{
                    //    var partie = (Partido)item.Tag;
                    //    var totalVote = dbContext.Votes.Where(v => v.Id == partie.Id).Sum(v => v.voteData);
                    //    item.SubItems.Add(totalVote.ToString());
                    //}
                    break;
            }

            listViewGlobalStats.EndUpdate();
        }

        private void UpdateListViewColumns(Enum @enum)
        {
            // remove all subitems from items
            // add/update columns

            listViewGlobalStats.BeginUpdate();

            foreach (ListViewItem item in listViewGlobalStats.Items)
            {
                item.SubItems.Clear();
            }

            for (int i = listViewGlobalStats.Columns.Count - 1; i > 0; i--)
            {
                listViewGlobalStats.Columns.RemoveAt(i);
            }

            //Enum.GetValues
            foreach (string name in Enum.GetNames(@enum.GetType()))
            {
                // skip none;
                if (name.Equals("none", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                listViewGlobalStats.Columns.Add(name);
            }

            listViewGlobalStats.EndUpdate();
        }

        private void GlobalStats_Shown(object sender, EventArgs e)
        {
            // no vote record is currently in database
            voteAppEntities dbContext = DbUtils.AppEntities;
            if (dbContext.Votes.Any() == false)
            {
                return;
            }

            if (_mapTotalVote.Count == 0)
            {
                // map total vote
                foreach (Partido partie in dbContext.Partidos)
                {
                    long totalVote = dbContext.Votes.Where(v => v.idPartido == partie.Id && v.provinceId == _user.ProvinceId)
                        .Sum(v => v.voteData);
                    _mapTotalVote.Add(partie.Id, totalVote);
                }
            }

            listViewGlobalStats.BeginUpdate();
            foreach (Partido partie in DbUtils.AppEntities.Partidos)
            {
                // ignore disabled parties
                if (partie.Enabled == false)
                {
                    continue;
                }
                ListViewItem lvi = new ListViewItem(partie.Name)
                {
                    Tag = partie,
                };
                listViewGlobalStats.Items.Add(lvi);
            }

            if (comboBoxDisplayResultBy.Items.Count > 0)
            {
                comboBoxDisplayResultBy.SelectedIndex = 0;
            }

            listViewGlobalStats.EndUpdate();

        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (Owner == null)
            {
                Close();
            }
            DialogResult = DialogResult.OK;
        }
    }
}
