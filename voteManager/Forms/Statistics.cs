using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VoteManager.Forms;
using VoteManager.Helpers;

namespace VoteManager
{
    public partial class Statistics : Form
    {
        // legends partido
        private readonly List<LegendItem> _legends;

        public Statistics(User user)
        {
            InitializeComponent();

            // init combobox provinces
            comboBoxProvince.BeginUpdate();
            comboBoxProvince.Items.Clear(); // just in case :P

            groupBoxOptions.Enabled = user.Type == TypeUser.SuperAdmin;

            int selcIdx = 0;

            foreach (var province in DbUtils.AppEntities.Provinces.OrderBy(p => p.Name))
            {
                if (province.Id == user.ProvinceId)
                {
                    selcIdx = comboBoxProvince.Items.Count;
                }
                comboBoxProvince.Items.Add(new DisplayItem<Province>(province));
            }
            comboBoxProvince.EndUpdate();

            comboBoxProvince.SelectedIndex = selcIdx;
            // TODO: list random color which will be used for partidos

            // build legendItem
            //foreach (var partido in DbUtils.AppEntities.Partidos.OrderBy(p => p.Name))
            //{
            //    //var legend = new LegendItem(partido.Name, Color.Blue, string.Empty);
            //    // research: LegendCell?

            //    var li = new LegendItem
            //    {
            //        Name = partido.Name
            //    };
            //}
        }

        private void ComboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            // remove all the date in chart if any
            // will contain partido info
            //chartSeries.Points.Add
            // compute new data
            // legendas = partidos (cant be constant)
            // insert into chart
            var chartSeries = chart1.Series.FirstOrDefault();
            chartSeries.Points.Clear();
            var selProvince = ((DisplayItem<Province>)comboBoxProvince.SelectedItem).Item;
            if (selProvince == null)
            {
                return;
            }
            var appEntities = DbUtils.AppEntities;
            var voteByProvince = appEntities.Votes.Where(vote => vote.provinceId == selProvince.Id);

            if (voteByProvince == null)
            {
                return;
            }

            foreach (var voteGroupedByPartido in voteByProvince.GroupBy(vote => vote.idPartido))
            {
                Partido partido = appEntities.Partidos.FirstOrDefault(p => p.Id == voteGroupedByPartido.Key);

                if (partido == null)
                {
                    continue;
                }

                var totalVoteByProvince = voteGroupedByPartido.Sum(vote => vote.voteData);

                var dataPoint = new DataPoint(chartSeries)
                {
                    Name = partido.Name,
                    LegendText = partido.Name,
                    Label = partido.Name
                };

                dataPoint.SetValueY(totalVoteByProvince);
                chartSeries.Points.Add(dataPoint);
            }
            chart1.Update();

        }
    }
}
