using System;
using System.Collections.Generic;
using System.Linq;

namespace voteManager.Helpers
{
    public static class DbUtils
    {
        private static void BuildPreDefinedDataBase(voteAppEntities voteModel)
        {
            var listCardinalDirections = new List<string>
            {
                "North", "East", "South", "West"
            };

            // geo data
            var datas = new Dictionary<string, List<string>>
            {
                // source: https://en.wikipedia.org/wiki/Sectors_of_Guinea-Bissau
                ["Quinara:S"] = new List<string> { "Tite", "Buba", "Empada", "Fulacunda" }, // south
                ["Oio:N"] = new List<string> { "Bissora", "Farim", "Mansaba", "Mansoa", "Nhacra" }, // north
                ["Biombo:N"] = new List<string> { "Prabis", "Quinhamel", "Safim" }, // North
                ["Bolama/Bijagos:S"] = new List<string> { "Bolama", "Bubaque", "Caravela", "Uno" }, // South
                ["Bafata:E"] = new List<string> { "Bafata", "Bambadinca", "Contuboel", "Galomaro", "Gamamundo", "Xitole" }, // Est (lest)
                ["Tombali:S"] = new List<string> { "Bedanda", "Cacine", "Catio", "Quebo", "Komo" }, // south
                ["SA-Bissau"] = new List<string> { "Bissau" }, // -
                ["Gabu:E"] = new List<string> { "Boe", "Gabu", "Piche", "Pirada", "Sonaco" }, // Est
                ["Cacheu:N"] = new List<string> { "Bigene", "Bula", "Caio", "Canchungo", "Sao Domingos" } //North
            };

            // no cardinal direction in db yet!
            if (voteModel.Provinces.Any() == false)
            {
                voteModel.Provinces.AddRange(listCardinalDirections.Select(cd => new Province { Name = cd }));
            }
            //voteModel.SaveChanges();

            // insert all regions if not already in db

            var listCe = new List<string>
            {
                "CE-01", "CE-02", "CE-03", "CE-04"
            };

            var voteTableTemp = new List<string>
            {
                "VT-01","VT-02","VT-03","VT-04","VT-05",
            };

            if (!voteModel.regions.Any())
            {
                // regions -> sectors -> ce -> table
                foreach (var data in datas)
                {
                    string[] regionProvince = data.Key.Split(':');
                    string regionName = regionProvince[0];
                    string province = regionProvince.Length > 1 ? regionProvince[1] : string.Empty;

                    var region = new region()
                    {
                        name = regionName
                    };

                    int count = voteModel.Provinces.Count();

                    System.Diagnostics.Debugger.Break();

                    switch (province)
                    {
                        // TODO: optimze
                        case "N":
                            voteModel.Provinces.First(p => p.Name.StartsWith("N", StringComparison.Ordinal));
                            break;
                        case "S":
                            voteModel.Provinces.First(p => p.Name.StartsWith("S", StringComparison.Ordinal));
                            break;
                        case "W":
                            voteModel.Provinces.First(p => p.Name.StartsWith("W", StringComparison.Ordinal));
                            break;
                        case "E":
                            voteModel.Provinces.First(p => p.Name.StartsWith("E", StringComparison.Ordinal));
                            break;
                        default: // bissau
                            voteModel.Provinces.First(p => p.Name.StartsWith("B", StringComparison.Ordinal) || p.Name.StartsWith("S", StringComparison.Ordinal)); //.region = region;
                            break;
                    }

                    foreach (var sector in data.Value)
                    {
                        var sec = new sector
                        {
                            name = sector,
                        };

                        //_voteMode.
                        sec.CEs.Add(new CE
                        {
                            voteTables = { new voteTable() }
                        });
                        region.sectors.Add(sec);
                    }
                    voteModel.regions.Add(region);
                }
            }

            // push changed to db
            voteModel.SaveChanges();

            var listPartidos = new List<string>
            {
                "PRS", "PAIGC", "PSP", "PPP", "PPA"
            };

            if (!voteModel.partidos.Any())
            {
                foreach (var partido in listPartidos)
                {
                    var partidoModel = new partido()
                    {
                        name = partido,
                    };
                    voteModel.partidos.Add(partidoModel);
                }
            }
            voteModel.SaveChanges();
            // System.ComponentModel.
            // voteModel.votes.ThenBy()
            // voteModel.regions.Aggregate()
            // voteModel.regions

            var result = voteModel.votes.Join(voteModel.regions, v => v.Id, m => m.Id, (v, r) => new { voteData = v, regionData = r });

            // 
            //var result2 = from v in voteModel.votes
            //              join r in voteModel.regions
            //              on v.Id equals r.Id
            //              select new { voteD = v, regionD = r };

            //foreach (var item in result)
            //{
            //    item.regionData.
            //}

            //var cresult = voteModel.regions.OrderBy(r => r.name).ToList();

            //UpdateGui();

            //bool changes = false;
            //if (changes)
            //{
            //    voteModel.SaveChanges();
            //}
        }
    }
}
