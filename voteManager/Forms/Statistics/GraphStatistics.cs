using EElections.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//using System.Web.UI.DataVisualization.Charting;

namespace EElections.Forms.Statistics
{
    public partial class Statistics : Form
    {
        private readonly voteAppEntities DbContext;

        // legends partido
        private readonly List<LegendItem> _legends;

        public Statistics(User user)
        {
            InitializeComponent();

            // init banners
            panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            // init combobox provinces
            /*
            comboBoxProvince.BeginUpdate();
            comboBoxProvince.Items.Clear(); // just in case :P

            groupBoxOptions.Enabled = user.Type == TypeUser.SuperAdmin;

            int selcIdx = 0;
            DbContext = DbUtils.AppEntities;
            foreach (Province province in DbUtils.AppEntities.Provinces.OrderBy(p => p.Name))
            {
                if (province.Id == user.ProvinceId)
                {
                    selcIdx = comboBoxProvince.Items.Count;
                }
                comboBoxProvince.Items.Add(new DisplayItem<Province>(province));
            }

            comboBoxProvince.EndUpdate();
            comboBoxProvince.SelectedIndex = selcIdx;
            */

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

            DbContext = DbUtils.AppEntities;
            UpdateColumnChart();
        }

        private void ComboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UpdatePIEChart();
            //UpdateColumnChart();
        }

        /*
        private void UpdatePIEChart()
        {
            // remove all the date in chart if any
            // will contain partido info
            //chartSeries.Points.Add
            // compute new data
            // legendas = partidos (cant be constant)
            // insert into chart
            Series chartSeries = chart1.Series.FirstOrDefault();
            chartSeries?.Points.Clear();
            Province selProvince = ((DisplayItem<Province>)comboBoxProvince.SelectedItem).Item;
            if (selProvince == null)
            {
                return;
            }
            var appEntities = DbUtils.AppEntities;
            IQueryable<Vote> voteByProvince = appEntities.Votes.Where(vote => vote.provinceId == selProvince.Id);

            if (voteByProvince == null)
            {
                return;
            }

            long sum = 0;
            foreach (Vote item in voteByProvince)
            {
                sum += item.voteData;
            }
            if (sum == 0)
            {
                return;
            }
            int? provinceVoteTotal = voteByProvince.Where(v => v != null).Sum(vote => vote.voteData);

            if (provinceVoteTotal.HasValue == false)
            {
                return;
            }

            foreach (IGrouping<int, Vote> voteGroupedByPartido in voteByProvince.GroupBy(vote => vote.idPartido))
            {
                Partido partido = appEntities.Partidos.FirstOrDefault(p => p.Id == voteGroupedByPartido.Key);

                if (partido == null)
                {
                    continue;
                }

                double totalVoteByProvince = voteGroupedByPartido.Sum(vote => vote.voteData);
                var percent = totalVoteByProvince / provinceVoteTotal * 100;

                var dataPoint = new DataPoint(chartSeries)
                {
                    Name = partido.Name,
                    LegendText = $"{partido.Name} - {percent:0.00}%",
                    Label = $"{partido.Name} - {percent:0.00}%",
                };

                dataPoint.SetValueY(totalVoteByProvince);
                chartSeries.Points.Add(dataPoint);
            }

            chart1.Update();
        }
        */

        private void UpdateColumnChart()
        {
            // partido = series

            mainChart.BeginInit();
            mainChart.Series.Clear();

            // select top five partie with their votes
            var topPartiesWithMoreVotes = DbContext.Votes
                .GroupBy(v => v.idPartido)
                //.Select(g => new { Id = g.Key, TotalVote = g.Sum(v => v.voteData)/*, Votes = g.ToList()*/ })
                .Select(g => new { PartidoKD = g.Key, TotalVote= g.Sum(v => v.voteData) })
                .OrderByDescending(v => v.TotalVote).Take(5);
            //.ToLookup( v=> v)

            var hashSet = new HashSet<int>(topPartiesWithMoreVotes.Select(t => t.PartidoKD));

            var result = DbContext.Votes.Where(v => hashSet.Contains(v.idPartido));
            var result2 = result.GroupBy(v => v.provinceId);
            int countOffset = 0;

            foreach (IGrouping<int, Vote> provinceVote in result2)
            {
                countOffset += 1;
                foreach (var partieVote in provinceVote.GroupBy(v => v.idPartido))
                {
                    Partido partie = DbContext.Partidos.FirstOrDefault(p => p.Id == partieVote.Key);
                    if (partie == null)
                    {
                        continue;
                    }
                    int totalVoteInProvince = partieVote.Sum(v => v.voteData);
                    Series chartSeries = mainChart.Series.FirstOrDefault(s => s.Name.Equals(partie.Name, StringComparison.OrdinalIgnoreCase));
                    bool serieExits = true;
                    if (chartSeries == null)
                    {
                        serieExits = false;
                        chartSeries = chartSeries ?? new Series(partie.Name)
                        {
                            Label = partie.Name,
                        };
                    }
                    DataPoint dataPoint = new DataPoint()
                    {
                        IsEmpty = false,
                    };
                    dataPoint.SetValueXY(countOffset, totalVoteInProvince);
                    chartSeries.Points.Add(dataPoint);
                    if (serieExits == false)
                    {
                        mainChart.Series.Add(chartSeries);
                    }
                }
            }


            //int countOffset = 0;
            //foreach (var topPartieVote in topPartiesWithMoreVotes)
            //{
            //    countOffset++;
            //    Partido partie = DbContext.Partidos.FirstOrDefault(p => p.Id == topPartieVote.Id);
            //    if (partie == null)
            //    {
            //        continue;
            //    }
            //    int totalVoteInProvince = topPartieVote.TotalVote;
            //    Series chartSeries = mainChart.Series.FirstOrDefault(s => s.Name.Equals(partie.Name, StringComparison.OrdinalIgnoreCase));
            //    bool serieExits = true;
            //    if (chartSeries == null)
            //    {
            //        serieExits = false;
            //        chartSeries = chartSeries ?? new Series(partie.Name)
            //        {
            //            Label = partie.Name,
            //        };
            //    }
            //    DataPoint dataPoint = new DataPoint()
            //    {
            //        IsEmpty = false,
            //    };
            //    dataPoint.SetValueXY(countOffset, totalVoteInProvince);
            //    chartSeries.Points.Add(dataPoint);
            //    if (serieExits == false)
            //    {
            //        mainChart.Series.Add(chartSeries);
            //    }
            //}

            /*

            int countOfSet = 0;
            var voteByProvince = DbContext.Votes.GroupBy(v => v.provinceId);
            foreach (IGrouping<int, Vote> provinceVote in voteByProvince)
            {
                //var results = from pv in provinceVote
                //              group pv by pv.idPartido into g
                //              select new { }

                var gpVotePartie = provinceVote.GroupBy(v => v.idPartido)
                    .Select(gvt => new { ProvinceId = provinceVote.Key, IdPartie = gvt.Key, TotalVote = gvt.Sum(v => v.voteData) });

                var topFivePartie = gpVotePartie.OrderByDescending(s => s.TotalVote).Take(5).ToList();
                countOfSet += 1;
                foreach (var topPartieVote in topFivePartie)
                {
                    Partido partie = DbContext.Partidos.FirstOrDefault(p => p.Id == topPartieVote.IdPartie);
                    if (partie == null)
                    {
                        continue;
                    }

                    int totalVoteInProvince = topPartieVote.TotalVote;
                    Series chartSeries = mainChart.Series.FirstOrDefault(s => s.Name.Equals(partie.Name, StringComparison.OrdinalIgnoreCase));

                    bool serieExits = true;
                    if (chartSeries == null)
                    {
                        serieExits = false;
                        chartSeries = chartSeries ?? new Series(partie.Name)
                        {
                            Label = partie.Name,
                            //XValueType = ChartValueType.String,
                        };
                        //chartSeries.AxisLabel = provinceName;
                    }

                    // https://stackoverflow.com/questions/12525997/how-to-set-chart-bars-width
                    //chartSeries["PixelPointWidth"] = "20";
                    //chartSeries.SetCustomProperty("PixelPointWidth", "250");

                    // totalVoteInRegion
                    DataPoint dataPoint = new DataPoint()
                    {
                        //IsValueShownAsLabel = true,
                        IsEmpty = false,
                        //AxisLabel = provinceName,
                        //MarkerSize = 10
                    };

                    //dataPoint.SetValueXY(ToolBarAppearance, totalVoteInRegion);
                    //dataPoint.SetValueY(totalVoteInProvince);
                    dataPoint.SetValueXY(countOfSet, totalVoteInProvince);

                    //chartSeries.AxisLabel = provinceName;
                    //dataPoint.SetValueXY(provinceName, totalVoteInRegion);
                    //chartSeries.Points.Add(dataPoint);

                    chartSeries.Points.Add(dataPoint);
                    //chartSeries.BorderWidth = 50;
                    if (serieExits == false)
                    {
                        mainChart.Series.Add(chartSeries);
                    }
                }
            }

            */

            /*
            foreach (Province province in DbContext.Provinces)
            {
                string provinceName = DbContext.Provinces.First(p => p.Id == province.Id).Name;

                // sel all vote from current province, then group them by partie
                IQueryable<IGrouping<int, Vote>> groupedVoteByPartie = DbContext.Votes.Where(v => v.provinceId == province.Id).GroupBy(v => v.idPartido);

                // sort all sel votes in desc order and sel top five partie with more vote
                IQueryable<IGrouping<int, Vote>> topFivePartie = groupedVoteByPartie.OrderBy(gv => gv.Sum(v => v.voteData));

                foreach (IGrouping<int, Vote> partieVote in topFivePartie)
                {
                    Partido partie = DbContext.Partidos.FirstOrDefault(p => p.Id == partieVote.Key);
                    if (partie == null)
                    {
                        continue;
                    }
                    
                    int totalVoteInProvince = partieVote.Sum(v => v.voteData);
                    Series chartSeries = mainChart.Series.FirstOrDefault(s => s.Name.Equals(partie.Name, StringComparison.OrdinalIgnoreCase));

                    bool serieExits = true;
                    if (chartSeries == null)
                    {
                        serieExits = false;
                        chartSeries = chartSeries ?? new Series(partie.Name)
                        {
                            Label = partie.Name,
                            //XValueType = ChartValueType.String,
                        };
                        //chartSeries.AxisLabel = provinceName;
                    }

                    // totalVoteInRegion
                    DataPoint dataPoint = new DataPoint()
                    {
                        //IsValueShownAsLabel = true,
                        IsEmpty = false,
                        //AxisLabel = provinceName,
                    };

                    //dataPoint.SetValueXY(ToolBarAppearance, totalVoteInRegion);
                    dataPoint.SetValueY(totalVoteInProvince);

                    //chartSeries.AxisLabel = provinceName;
                    //dataPoint.SetValueXY(provinceName, totalVoteInRegion);
                    chartSeries.Points.Add(dataPoint);

                    if (serieExits == false)
                    {
                        mainChart.Series.Add(chartSeries);
                    }
                }
            }

            */

            mainChart.EndInit();

            mainChart.Invalidate();
            mainChart.Update();

        }

        private void UpdateMainChar()
        {
            mainChart.EndInit();

            // force redraw
            mainChart.Invalidate();
            mainChart.Update();
        }
    }
}
