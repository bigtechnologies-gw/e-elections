using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSampleBuilder
{
    internal class RegionLocal
    {
        public string Name { get; set; }

        public string Area { get; set; }

        public Province Province { get; set; }

        public int TotalSector { get; set; }

        public IList<Sector> Sectors { get; set; }
    }

    internal enum ProvinceLocal
    {
        North, // norte
        South, // Sul
        East, // Lest
        SAB,
    }

    internal class Program
    {
        private static readonly VoteAppModel DbContext = new VoteAppModel();

        private static void Main(string[] args)
        {
            ClearDataBase();

            var provinces = new List<Province>()
            {
                new Province {Name = "North"},
                new Province {Name = "South"},
                new Province {Name = "East"},
                new Province {Name = "SAB"},
            };


            // provinces
            foreach (var pro in provinces)
            {
                DbContext.Provinces.Add(pro);
            }

            DbContext.SaveChanges();

            int idNorth = DbContext.Provinces.First(p => p.Name.Equals("north", StringComparison.OrdinalIgnoreCase)).Id;
            int idSouth = DbContext.Provinces.First(p => p.Name.Equals("south", StringComparison.OrdinalIgnoreCase)).Id;
            int idEast = DbContext.Provinces.First(p => p.Name.Equals("east", StringComparison.OrdinalIgnoreCase)).Id;
            int idSAB = DbContext.Provinces.First(p => p.Name.Equals("sab", StringComparison.OrdinalIgnoreCase)).Id;

            var regions = new List<Region>
            {
                new Region {Name = "Biombo", idProvince = idNorth},
                new Region {Name = "Cacheu", idProvince = idNorth},
                new Region {Name = "Oio", idProvince = idNorth},

                new Region {Name = "Bolama", idProvince = idSouth},
                new Region {Name = "Quinara", idProvince = idSouth},
                new Region {Name = "Tombali", idProvince = idSouth},

                new Region {Name = "Bafatá", idProvince = idEast},
                new Region {Name = "Gabu", idProvince = idEast},

                new Region {Name = "Bissau", idProvince = idSAB }
            };

            foreach (var region in regions)
            {
                switch (region.Name)
                {
                    case "Bafatá":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Bafata"},
                            new Sector {Name = "Bambadinca"},
                            new Sector {Name = "Contuboel"},
                            new Sector {Name = "Galomaro"},
                            new Sector {Name = "Gamamundo"},
                            new Sector {Name = "Xitole"},
                        };
                        break;
                    case "Gabu":

                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Boe"},
                            new Sector {Name = "Gabú"},
                            new Sector {Name = "Piche"},
                            new Sector {Name = "Pirada"},
                            new Sector {Name = "Gamamundo"},
                            new Sector {Name = "Sonaco"},
                        };
                        break;
                    case "Biombo":

                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Prabis"},
                            new Sector {Name = "Quinhamel"},
                            new Sector {Name = "Safim"},
                        };
                        break;

                    case "Cacheu":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Bigene"},
                            new Sector {Name = "Bula"},
                            new Sector {Name = "Cacheu"},
                            new Sector {Name = "Caio"},
                            new Sector {Name = "Canghungo"},
                            new Sector {Name = "São Domingos"},
                        };
                        break;

                    case "Oio":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Bissorã"},
                            new Sector {Name = "Farim"},
                            new Sector {Name = "Mansaba"},
                            new Sector {Name = "Mansôa"},
                            new Sector {Name = "Nhacra"},
                        };
                        break;

                    case "Bolama":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Bolama"},
                            new Sector {Name = "Bubaque"},
                            new Sector {Name = "Caravela"},
                            new Sector {Name = "Uno"},
                        };
                        break;

                    case "Quinara":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Buba"},
                            new Sector {Name = "Empada"},
                            new Sector {Name = "Fulacunda"},
                            new Sector {Name = "Tite"},
                        };
                        break;

                    case "Tombali":
                        region.Sectors = new List<Sector>
                        {
                            new Sector {Name = "Bedanda"},
                            new Sector {Name = "Cacine"},
                            new Sector {Name = "Catió"},
                            new Sector {Name = "Quebo"},
                            new Sector {Name = "Komo"},
                        };
                        break;
                    default:
                        region.Sectors = new List<Sector> { new Sector { Name = "SAB" } };
                        // bissau?
                        break;
                }
            }

            foreach (var region in regions)
            {
                DbContext.Regions.Add(region);
            }

            // flush into db
            DbContext.SaveChanges();
            PopulateCE();
            PopulateVoteTable();
            PopulatePartido();
            PopulateVote();
            DbContext.SaveChanges();

            // provinces -> regions -> sectors

            // build xml

            //var xdoc = new XDocument(new XElement("provinces"));

            //foreach (var provinceName in Enum.GetNames(typeof(Province)))
            //{
            //    xdoc.Root.Add(new XElement(provinceName));
            //}

            //foreach (var kv in regions.GroupBy(r => r.Province))
            //{
            //    // key = province
            //    var elProvince = new XElement(kv.Key.ToString());
            //    foreach (RegionLocal region in kv)
            //    {
            //        var elRegion = new XElement("region")
            //    }
            //}
        }

        private static void PopulateCE()
        {
            int totalSectors = DbContext.Sectors.Count() * 5;
            int i = 1;
            foreach (var region in DbContext.Regions)
            {
                foreach (var sector in region.Sectors)
                {
                    for (; i <= totalSectors; i++)
                    {
                        //var ce = DbContext.CEs.Create();
                        var ce = new CE()
                        {
                            Name = $"CE-{i:00}",
                        };
                        sector.CEs.Add(ce);

                        if (i % 5 == 0)
                        {
                            i++;
                            break;
                        }
                    }
                }
            }

            DbContext.SaveChanges();
        }

        private static void PopulateVoteTable()
        {
            int totalSectors = DbContext.CEs.Count() * 3;
            int i = 1;
            foreach (var ce in DbContext.CEs)
            {
                for (; i <= totalSectors; i++)
                {
                    //var ce = DbContext.CEs.Create();
                    var voteTable = new VoteTable()
                    {
                        Name = $"VT-{i:00}",
                    };
                    ce.VoteTables.Add(voteTable);

                    if (i % 3 == 0)
                    {
                        i++;
                        break;
                    }
                }
            }

            DbContext.SaveChanges();
        }

        private static void PopulatePartido()
        {
            var partidos = new List<string>
            {
                "PAIGC", "PRS", "PUSD","LIPE", "PDS", "FDS", "UM/PDP",
                "RGB-MB", "PUN", "APU", "UNDP", "PT", "PMP", "PSGB", "MDGB", "FCG/SD", "PPG", "PND", "PCD", "PRID", "PSD"
            };

            foreach (var partido in partidos)
            {
                var partie = DbContext.Partidos.Create();
                partie.Name = partido;
                partie.Enabled = true;
                DbContext.Partidos.Add(partie);
            }

            DbContext.SaveChanges();
        }

        private static void PopulateVote()
        {

        }

        private static void ClearDataBase()
        {
            foreach (var vote in DbContext.Votes)
            {
                DbContext.Votes.Remove(vote);
            }
            foreach (var item in DbContext.Partidos)
            {
                DbContext.Partidos.Remove(item);
            }

            // contains relatioships
            foreach (var item in DbContext.VoteTables)
            {
                DbContext.VoteTables.Remove(item);
            }
            foreach (var item in DbContext.CEs)
            {
                DbContext.CEs.Remove(item);
            }
            foreach (var item in DbContext.Sectors)
            {
                DbContext.Sectors.Remove(item);
            }
            foreach (var item in DbContext.Regions)
            {
                DbContext.Regions.Remove(item);
            }
            foreach (var item in DbContext.Provinces)
            {
                DbContext.Provinces.Remove(item);
            }

            DbContext.SaveChanges();
        }

        private static void BuildProvinces()
        {

        }


    }
}
