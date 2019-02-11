using System;
using System.Collections.Generic;
using System.Linq;

namespace EElections.Helpers
{
    public static class DbUtils
    {
        // entity model
        //public static Model { get; set; }

        public static voteAppEntities AppEntities { get; set; }

        static DbUtils()
        {
            AppEntities = new voteAppEntities();
            BuildPreDefinedDataBase();
        }

        private static void BuildPreDefinedDataBase()
        {
            // only an admin or a system has right to creaet/delete/modify db directly
            //if (!(loginUser.Type == TypeUser.Admin || loginUser.Type == TypeUser.Sytem))
            //{
            //    throw new Exception("No access right!");
            //}

            List<string> listCardinalDirections = new List<string>
            {
                "North", "East", "South", "SAB",
            };

            // geo data
            Dictionary<string, List<string>> datas = new Dictionary<string, List<string>>
            {
                // source: https://en.wikipedia.org/wiki/Sectors_of_Guinea-Bissau
                ["Quinara:S"] = new List<string> { "Tite", "Buba", "Empada", "Fulacunda" }, // south
                ["Oio:N"] = new List<string> { "Bissora", "Farim", "Mansaba", "Mansoa", "Nhacra" }, // north
                ["Biombo:N"] = new List<string> { "Prabis", "Quinhamel", "Safim" }, // North
                ["Bolama/Bijagos:S"] = new List<string> { "Bolama", "Bubaque", "Caravela", "Uno" }, // South
                ["Bafata:E"] = new List<string> { "Bafata", "Bambadinca", "Contuboel", "Galomaro", "Gamamundo", "Xitole" }, // Est (lest)
                ["Tombali:S"] = new List<string> { "Bedanda", "Cacine", "Catio", "Quebo", "Komo" }, // south
                ["SA/Bissau:N/A"] = new List<string> { "Bissau" }, // -
                ["Gabu:E"] = new List<string> { "Boe", "Gabu", "Piche", "Pirada", "Sonaco" }, // Est
                ["Cacheu:N"] = new List<string> { "Bigene", "Bula", "Caio", "Canchungo", "Sao Domingos" } //North
            };

            // no cardinal direction in db yet!
            if (AppEntities.Provinces.Any() == false)
            {
                AppEntities.Provinces.AddRange(listCardinalDirections.Select(cd => new Province { Name = cd }).ToList());
                AppEntities.SaveChanges();
            }

            // insert all Regions if not already in db

            List<string> listCe = new List<string>
            {
                "CE-01", "CE-02", "CE-03", "CE-04"
            };

            List<string> voteTableTemp = new List<string>
            {
                "VT-01","VT-02","VT-03","VT-04","VT-05",
            };

            // local function
            bool CheckFunction(string p, string pattern) => p.StartsWith(pattern, StringComparison.OrdinalIgnoreCase);

            //var tempRegion = new Region
            //{
            //    idProvince = 1,
            //    Name = "",
            //    sectors = {new sector
            //    {
            //        name = "ivandro",
            //        CEs = { new CE
            //        {
            //            voteTables  = {new voteTable
            //            {
            //            }
            //            }
            //        } }
            //       }
            //    }
            //};

            //_voteModel.Regions.Add(tempRegion);

            AppEntities.SaveChanges();

            if (!AppEntities.Regions.Any())
            {
                // Regions -> sectors -> ce -> table
                foreach (KeyValuePair<string, List<string>> data in datas)
                {
                    string[] regionProvince = data.Key.Split(':');
                    string regionName = regionProvince[0];
                    string province = regionProvince.Length > 1 ? regionProvince[1] : string.Empty;

                    Region region = new Region()
                    {
                        Name = regionName
                    };

                    //System.Diagnostics.Debugger.Break();

                    switch (province)
                    {
                        // UNDONE: optimze
                        case "N":
                            foreach (Province item in AppEntities.Provinces)
                            {
                                if (CheckFunction(item.Name, "n"))
                                {
                                    region.idProvince = item.Id;
                                }
                            }
                            break;

                        case "S":
                            //_voteModel.Provinces.First(p => p.Name.StartsWith("S", StringComparison.Ordinal));
                            foreach (Province item in AppEntities.Provinces)
                            {
                                if (CheckFunction(item.Name, "s"))
                                {
                                    region.idProvince = item.Id;
                                }
                            }
                            break;

                        case "W":
                            foreach (Province item in AppEntities.Provinces)
                            {
                                if (CheckFunction(item.Name, "w"))
                                {
                                    region.idProvince = item.Id;
                                }
                            }
                            break;

                        case "E":
                            foreach (Province item in AppEntities.Provinces)
                            {
                                if (CheckFunction(item.Name, "e"))
                                {
                                    region.idProvince = item.Id;
                                }
                            }
                            break;
                            //_voteModel.Provinces.First(p => p.Name.StartsWith("B", StringComparison.Ordinal) || p.Name.StartsWith("S", StringComparison.Ordinal)); //.Region = Region;
                    }

                    foreach (string sector in data.Value)
                    {
                        Sector sec = new Sector
                        {
                            Name = sector,
                        };
                        sec.CEs.Add(new CE
                        {
                            Name = string.Empty,
                            voteTables = { new VoteTable() {
                                Name = string.Empty,
                            }}
                        });
                        region.sectors.Add(sec);
                    }

                    AppEntities.Regions.Add(region);
                }
            }

            //var listRegions = _voteModel.Regions.Local.Count;
            //var list = new List<IGrouping<int?, Region>>(_voteModel.Regions.Local.GroupBy(p => p.idProvince));
            AppEntities.SaveChanges();

            // push changed to db
            //_voteModel.SaveChanges();

            List<string> defaultPartidos = new List<string>
            {
                "PRS", "PAIGC", "PSP", "PPP", "PPA"
            };

            if (!AppEntities.Partidos.Any())
            {
                foreach (string partido in defaultPartidos)
                {
                    Partido partidoModel = new Partido()
                    {
                        Name = partido,
                    };
                    AppEntities.Partidos.Add(partidoModel);
                }
            }

            // ADD GUEST USER
            // add guest user (note: guest user will only be able to view and print the data.
            //if (!AppEntities.Users.Any(user => user.Type == TypeUser.Guest))
            //{
            //    // add usr guest
            //    AppEntities.Users.Add(new User
            //    {
            //        FullName = "Guest User",
            //        DateCreation = DateTime.Now,
            //        Enabled = true,
            //        Name = "guest",
            //        Password = "guest", // constant (no admin can change this password)
            //        ProvinceId = 0,
            //        Type = TypeUser.Guest,
            //        OwnerId = 0,
            //        Salt = string.Empty,
            //    });
            //}

            AppEntities.SaveChanges();
            // System.ComponentModel.
            // _voteModel.votes.ThenBy()
            // _voteModel.Regions.Aggregate()
            // _voteModel.Regions
            //var result = _voteModel.votes.Join(_voteModel.Regions, v => v.Id, m => m.Id, (v, r) => new { voteData = v, regionData = r });
            //var result2 = from v in _voteModel.votes
            //              join r in _voteModel.Regions
            //              on v.Id equals r.Id
            //              select new { voteD = v, regionD = r };
            //foreach (var item in result)
            //{
            //    item.regionData.
            //}
            //var cresult = _voteModel.Regions.OrderBy(r => r.name).ToList();

            //bool changes = false;
            //if (changes)
            //{
            //    _voteModel.SaveChanges();
            //}
        }

        public static void GenerateVote()
        {
            voteAppEntities DbContext = AppEntities;
            Random rand = new Random(12343);

            // p * r * s * ce * vt
            foreach (Partido partie in DbContext.Partidos)
            {
                foreach (Region region in DbContext.Regions)
                {
                    foreach (Sector sector in region.sectors)
                    {
                        foreach (CE ce in sector.CEs)
                        {
                            foreach (VoteTable table in ce.voteTables)
                            {
                                //var vote = DbContext.Votes.Create();
                                //vote.idCE = ce.Id;
                                //vote.idPartido = partie.Id;
                                //vote.idRegion = region.Id;
                                //vote.idSector = sector.Id;
                                //vote.idVoteTable = table.Id;
                                //vote.voteData = rand.Next(240, 67992);
                                //vote.provinceId = region.idProvince;

                                int data = rand.Next(2323, 697333);
                                Vote vote = new Vote
                                {
                                    idCE = ce.Id,
                                    idPartido = partie.Id,
                                    idRegion = region.Id,
                                    idSector = sector.Id,
                                    idVoteTable = table.Id,
                                    provinceId = region.idProvince,
                                    voteData = data,
                                };

                                DbContext.Votes.Add(vote);
                            }
                        }
                    }
                }
            }

            DbContext.SaveChanges();
        }
    }
}
