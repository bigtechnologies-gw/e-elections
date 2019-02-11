using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EElections.Helpers;

namespace EElections.Forms.Statistics
{
    public partial class GeneralStats : Form
    {
        private readonly int _mpPerElectoralCircle;

        public GeneralStats(int mpPerElecCicle)
        {
            InitializeComponent();
            _mpPerElectoralCircle = mpPerElecCicle;

            // todo:
            //comboBoxByProvince.AutoCompleteCustomSource 

            InitUI();
        }

        // ReSharper disable once InconsistentNaming
        private void InitUI()
        {
            // banners
            panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            voteAppEntities dbContext = DbUtils.AppEntities;

            // init combobox province
            comboBoxByProvince.BeginUpdate();

            // linq doesn't support init with param
            //comboBoxByProvince.Items.AddRange(dbContext.Provinces.OrderBy(p => p.Name).Select(p => new DisplayItem<Province>(p)).ToArray());
            foreach (Province item in dbContext.Provinces.OrderBy(p => p.Name))
            {
                comboBoxByProvince.Items.Add(new DisplayItem<Province>(item));
            }

            comboBoxByProvince.SelectedIndexChanged -= ComboBoxByProvince_SelectedIndexChanged;
            // sel first item
            if (comboBoxByProvince.Items.Count > 0)
            {
                comboBoxByProvince.SelectedIndex = 0;
            }

            comboBoxByProvince.EndUpdate();
            comboBoxByProvince.SelectedIndexChanged += ComboBoxByProvince_SelectedIndexChanged;

            #region ListView

            listViewLegislative.BeginUpdate();
            listViewLegislative.Columns.Clear();

            listViewLegislative.Items.Clear();

            listViewLegislative.Columns.Add(new ColumnHeader() {Text = "Partido", Width = 108,});

            foreach (Province province in dbContext.Provinces.OrderBy(p => p.Id))
            {
                listViewLegislative.Columns.Add(new ColumnHeader() {Text = province.Name, Width = 108,});
            }

            // add parties

            //var items = dbContext.Partidos.Select(p => new ListViewItem(p.Name) { Tag = p }).ToArray();

            foreach (IGrouping<int, Vote> item in dbContext.Votes.GroupBy(v => v.idPartido))
            {
                Partido partie = dbContext.Partidos.FirstOrDefault(p => p.Id == item.Key);
                if (partie == null)
                {
                    continue;
                }

                ListViewItem lvi = new ListViewItem(partie.Name) {Tag = partie.Id};

                foreach (IGrouping<int, Vote> vote in item.OrderBy(i => i.provinceId).GroupBy(v => v.provinceId))
                {
                    int numberOfMpPerProvine = vote.Sum(v => v.voteData) / _mpPerElectoralCircle;
                    lvi.SubItems.Add(numberOfMpPerProvine.ToString());
                }

                listViewLegislative.Items.Add(lvi);
            }

            listViewLegislative.EndUpdate();

            #endregion

            #region Chart

            UpdateChart();

            #endregion
        }

        private void UpdateChart()
        {
            if (DbUtils.AppEntities.Votes.Any() == false)
            {
                return;
            }

            voteAppEntities dbContext = DbUtils.AppEntities;

            chart1.BeginInit();

            Series series = chart1.Series.FirstOrDefault();

            series.Points.Clear();

            if (series == null)
            {
                Debug.WriteLine("NO SERIE FOUND!");
                return;
            }

            Province selProvince = ((DisplayItem<Province>) comboBoxByProvince.SelectedItem).Item;
            // calculate top 5 partie with more MP (deputados)
            IGrouping<int, Vote> provinceVote = dbContext.Votes.GroupBy(v => v.provinceId).FirstOrDefault(g => g.Key == selProvince.Id);

            // find top five partie with more vote
            var topFivePartieWithMoreVote = provinceVote.GroupBy(v => v.idPartido)
                .Select(v => new {PartieId = v.Key, TotalVote = v.Sum(vt => vt.voteData)})
                .OrderByDescending(t => t.TotalVote)
                .Take(5);

            // variante #1
            double totalVotePerSelProvince = dbContext.Votes.Where(v => v.provinceId == selProvince.Id)
                .Sum(v => v.voteData);

            // variante #2
            double totalMPInSelProvince = dbContext.Votes.Where(v => v.provinceId == selProvince.Id)
                                              .Sum(v => v.voteData) / _mpPerElectoralCircle;

            foreach (var topFivePartie in topFivePartieWithMoreVote)
            {
                Partido partie = dbContext.Partidos.First(p => p.Id == topFivePartie.PartieId);

                //double partieTotalVoteInSelProvince = dbContext.Votes
                //    .Where(v => v.provinceId == selProvince.Id && v.idPartido == partie.Id)
                //    .Sum(v => v.voteData);

                double partieTotalMPInProvince = dbContext.Votes
                                                     .Where(v => v.provinceId == selProvince.Id &&
                                                                 v.idPartido == partie.Id)
                                                     .Sum(v => v.voteData) / totalMPInSelProvince;

                DataPoint dp = new DataPoint()
                {
                    LegendText = partie.Name, // name displayed in legend column
                    Label =
                        $"{partie.Name} - {partieTotalMPInProvince / totalMPInSelProvince * Math.Pow(10, 3):00.00} %", // name display in cicle
                };

                dp.SetValueY(topFivePartie.TotalVote);

                series.Points.Add(dp);
            }

            //series.Points.ad
            chart1.EndInit();
        }

        private void ComboBoxByProvince_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateChart();
        }
    }
}
