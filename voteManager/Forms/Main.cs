using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace voteManager
{
    public partial class Main : Form
    {
        private readonly voteAppEntities _voteModel;
        private readonly User loginUser;

        public Main(voteAppEntities voteModel, User loginUser)
        {
            InitializeComponent();

            FormClosed += Main_FormClosed;
            _voteModel = voteModel;
            this.loginUser = loginUser;


            // load async
            UpdateListPartidos();

            BuildPreDefinedDataBase();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner?.Show();
        }

        private void buttonAddPartidos_Click(object sender, EventArgs e)
        {
            // validate partidos
            string partido = textBoxPartidos.Text.Trim();

            // check if partido with that name doesn't already exit

            if (_voteModel.partidos.Any(p => p.name.Equals(partido, StringComparison.OrdinalIgnoreCase)))
            {
                // partido already exists
                MessageBox.Show("partido* already exists", "Duplicated partido*", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // send to db
            _voteModel.partidos.Add(new partido() { name = partido });

            // todo: save changes async
            _voteModel.SaveChanges();

            // update listview
            UpdateListPartidos();
        }

        private void UpdateListPartidos()
        {
            listBoxPartidos.BeginUpdate();
            comboBoxPeritidos.BeginUpdate();

            // remove all pre-existing items from controls
            listBoxPartidos.Items.Clear();
            comboBoxPeritidos.Items.Clear();

            foreach (var part in _voteModel.partidos.OrderBy(p => p.name))
            {
                listBoxPartidos.Items.Add(part);
                comboBoxPeritidos.Items.Add(part);
            }

            comboBoxPeritidos.EndUpdate();
            listBoxPartidos.EndUpdate();
        }

        private void buttonRemovePartido_Click(object sender, EventArgs e)
        {
            var partido = listBoxPartidos.SelectedItem as partido;

            if (partido == null)
            {
                MessageBox.Show("Select a partido*", "No partido selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (partido != null)
            {
                // remove from listview
                listBoxPartidos.Items.RemoveAt(listBoxPartidos.SelectedIndex);
                // remove from database (warm user that all the data linked with the *partido will be delete aswell.
                _voteModel.partidos.Remove(partido);
                //_voteModel.SaveChanges();
            }

            // remove partido from combobox partiso
            for (int i = comboBoxPeritidos.Items.Count - 1; i >= 0; i--)
            {
                var it = comboBoxPeritidos.Items[i] as partido;
                if (it?.name.Equals(partido.name, StringComparison.Ordinal) == true)
                {
                    comboBoxPeritidos.Items.RemoveAt(i);
                    break;
                }
            }
            _voteModel.SaveChanges();

            // TODO: Make sure all the date from the partido is also removed from the database?
            // NOTE: vote-table doesn't have any relatioship with other table with means the data
            // would still be stored even after the we remove *partido.
        }

        private void BuildPreDefinedDataBase()
        {
            // only an admin or a system has right to creaet/delete/modify db directly
            if (!(loginUser.Type == TypeUser.Admin || loginUser.Type == TypeUser.Sytem))
            {
                MessageBox.Show("No access right!", "No access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var listCardinalDirections = new List<string>
            {
                "North", "East", "South", "West", "N/A"
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
                ["SA/Bissau:N/A"] = new List<string> { "Bissau" }, // -
                ["Gabu:E"] = new List<string> { "Boe", "Gabu", "Piche", "Pirada", "Sonaco" }, // Est
                ["Cacheu:N"] = new List<string> { "Bigene", "Bula", "Caio", "Canchungo", "Sao Domingos" } //North
            };

            // no cardinal direction in db yet!
            if (_voteModel.Provinces.Any() == false)
            {
                _voteModel.Provinces.AddRange(listCardinalDirections.Select(cd => new Province { Name = cd }).ToList());
                _voteModel.SaveChanges();
            }
            //_voteModel.SaveChanges();

            // insert all regions if not already in db

            var listCe = new List<string>
            {
                "CE-01", "CE-02", "CE-03", "CE-04"
            };

            var voteTableTemp = new List<string>
            {
                "VT-01","VT-02","VT-03","VT-04","VT-05",
            };

            if (!_voteModel.regions.Any())
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

                    //System.Diagnostics.Debugger.Break();

                    switch (province)
                    {
                        // TODO: optimze
                        case "N":
                            foreach (Province prov in _voteModel.Provinces)
                            {
                                if (prov.Name.StartsWith("N", StringComparison.Ordinal))
                                {
                                    prov.region = region;
                                    break;
                                }
                            }
                            break;
                        case "S":
                            //_voteModel.Provinces.First(p => p.Name.StartsWith("S", StringComparison.Ordinal));
                            foreach (Province prov in _voteModel.Provinces)
                            {
                                if (prov.Name.StartsWith("S", StringComparison.Ordinal))
                                {
                                    prov.region = region;
                                    break;
                                }
                            }
                            break;
                        case "W":
                            foreach (Province prov in _voteModel.Provinces)
                            {
                                if (prov.Name.StartsWith("W", StringComparison.Ordinal))
                                {
                                    prov.region = region;
                                    break;
                                }
                            }
                            break;
                        case "E":
                            foreach (Province prov in _voteModel.Provinces)
                            {
                                if (prov.Name.StartsWith("E", StringComparison.Ordinal))
                                {
                                    prov.region = region;
                                    break;
                                }
                            }
                            break;
                        case "N/A":
                            //var regionBissau = _voteModel.regions.Where(reg => reg.name.Equals("SA/Bissau", StringComparison.OrdinalIgnoreCase)).First();
                            foreach (var prov in _voteModel.Provinces)
                            {
                                if (prov.Name.Equals("n/a", StringComparison.OrdinalIgnoreCase))
                                {
                                    prov.region = region;
                                    break;
                                }
                            }
                            break;
                            //_voteModel.Provinces.First(p => p.Name.StartsWith("B", StringComparison.Ordinal) || p.Name.StartsWith("S", StringComparison.Ordinal)); //.region = region;
                    }

                    //foreach (var item in _voteModel.Provinces)
                    //{
                    //    if(item.region == null)
                    //    {
                    //        System.Diagnostics.Debugger.Break();
                    //    }
                    //}

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

                    _voteModel.regions.Add(region);
                }
            }

            // push changed to db
            //_voteModel.SaveChanges();

            var listPartidos = new List<string>
            {
                "PRS", "PAIGC", "PSP", "PPP", "PPA"
            };

            if (!_voteModel.partidos.Any())
            {
                foreach (var partido in listPartidos)
                {
                    var partidoModel = new partido()
                    {
                        name = partido,
                    };
                    _voteModel.partidos.Add(partidoModel);
                }
            }

            _voteModel.SaveChanges();
            // System.ComponentModel.
            // _voteModel.votes.ThenBy()
            // _voteModel.regions.Aggregate()
            // _voteModel.regions
            //var result = _voteModel.votes.Join(_voteModel.regions, v => v.Id, m => m.Id, (v, r) => new { voteData = v, regionData = r });
            //var result2 = from v in _voteModel.votes
            //              join r in _voteModel.regions
            //              on v.Id equals r.Id
            //              select new { voteD = v, regionD = r };
            //foreach (var item in result)
            //{
            //    item.regionData.
            //}
            //var cresult = _voteModel.regions.OrderBy(r => r.name).ToList();
            UpdateGui();
            //bool changes = false;
            //if (changes)
            //{
            //    _voteModel.SaveChanges();
            //}
        }

        public void UpdateGui()
        {
            listView1.BeginUpdate();
            listView1.Groups.Clear();

            comboBoxRegions.BeginUpdate();
            //comboBoxSectors.BeginUpdate();
            //comboBoxCE.BeginUpdate();
            //comboBoxTable.BeginUpdate();

            foreach (var region in _voteModel.regions.OrderBy(r => r.name))
            {
                comboBoxRegions.Items.Add(region);
            }
            comboBoxRegions.EndUpdate();

            foreach (var region in _voteModel.regions.OrderBy(r => r.name))
            {
                var lvg = new ListViewGroup($"group{region.name}", region.name);
                lvg.Tag = region;
                listView1.Groups.Add(lvg);
            }
            listView1.EndUpdate();

            //var jResult = _voteModel.votes.Join(_voteModel.regions, _vote => _vote.Id, _region => _region.Id,
            //     (cVote, cRegion) => new { Vote = cVote, Region = cRegion });


            foreach (vote vote in _voteModel.votes)
            {
                var partido = _voteModel.partidos.First(p => p.Id == vote.idPartido);
                var sector = _voteModel.sectors.First(p => p.Id == vote.idSector);
                var ce = _voteModel.CEs.First(p => p.Id == vote.idCE);
                var voteTable = _voteModel.voteTables.First(p => p.Id == vote.idVoteTable);

                var lvi = new ListViewItem(partido.name)
                {
                    SubItems = { sector.name, ce.Id.ToString(), voteTable.ToString(), vote.voteData.ToString() }
                };

                foreach (ListViewGroup lvg in listView1.Groups)
                {
                    if (((region)lvg.Tag).Id == sector.regionId)
                    {
                        lvi.Group = lvg;
                        break;
                    }
                }

                listView1.Items.Add(lvi);
            }

            //foreach (var item in jResult)
            //{
            //    //item.v
            //    foreach (ListViewGroup lvg in listView1.Groups)
            //    {
            //        if (((region)lvg.Tag).Id == item.Region.Id)
            //        {
            //            // todo: map partido to avoid 
            //            // partido -> sector -> ce -> table -> vote
            //            var p = _voteModel.partidos.First(part => part.Id == item.Vote.idPartido);
            //            var sector = _voteModel.sectors.First(s => s.Id == item.Vote.idSector);
            //            //var ce = _voteModel.CEs.First(s => s.Id == item.Vote.idCE);
            //            //var vt = _voteModel.voteTables.First(s => s.Id == item.Vote.idVoteTable);
            //            var lvi = new ListViewItem(p.name)
            //            {
            //                SubItems = { sector.name, "" /*ce.ToString()*/, "", 232.ToString()/*vt.ToString() */}
            //            };
            //            lvi.Group = lvg;
            //            listView1.Items.Add(lvi);
            //            break;
            //        }
            //    }
            //}
        }

        private void buttonAddVote_Click(object sender, EventArgs e)
        {
            // TODO: Only allow number input in textbox vote

            int votes;

            string voteData = textBoxVote.Text; // .TrimStart('0'); // TODO: Uncomment

            if (!int.TryParse(voteData, out votes))
            {
                // invalid data entered
                MessageBox.Show("Invalid data!");
                return;
            }

            // validate vote

            // send data to db

            int idPartido = ((partido)comboBoxPeritidos.SelectedItem).Id;
            int idRegion = ((region)comboBoxRegions.SelectedItem).Id;
            int idSector = ((sector)comboBoxSectors.SelectedItem).Id;
            int idCE = ((CE)comboBoxCE.SelectedItem).Id;
            int idTable = ((voteTable)comboBoxTable.SelectedItem).Id;

            // check if vote isn't already inserted

            bool isInDatabase = _voteModel.votes.Any(v => v.idPartido == idPartido
            && v.idRegion == idRegion && v.idSector == idSector
            && v.idCE == idCE && v.idVoteTable == idTable);

            if (isInDatabase)
            {
                MessageBox.Show("Vote already in data base", "Vote already in DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // refresh listview
                return;
            }

            var vote = new vote
            {
                idPartido = idPartido,
                idRegion = idRegion,
                idSector = idSector,
                idCE = idCE,
                idVoteTable = idTable,
                voteData = votes
            };

            _voteModel.votes.Add(vote);
            _voteModel.SaveChanges();

            MessageBox.Show("Vote added!", "Vote added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxVote.Text = string.Empty;
        }

        private void comboBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSectors.BeginUpdate();
            // comboBoxTable.BeginUpdate();

            comboBoxSectors.Items.Clear();
            comboBoxCE.Items.Clear();

            var region = comboBoxRegions.SelectedItem as region;

            foreach (var sector in region.sectors)
            {
                comboBoxSectors.Items.Add(sector);
            }
            if (comboBoxSectors.Items.Count > 0)
            {
                comboBoxSectors.SelectedIndex = 0;
            }
            comboBoxSectors.EndUpdate();
        }

        private void comboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxCE.Enabled = true;

            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            var sector = comboBoxSectors.SelectedItem as sector;
            // todo: remove this check.
            if (sector == null)
            {
                return;
            }
            foreach (var ce in sector.CEs)
            {
                comboBoxCE.Items.Add(ce);
            }

            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }

            comboBoxCE.EndUpdate();
            // add data to ce
        }

        private void comboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTable.BeginUpdate();
            comboBoxTable.Items.Clear();
            var ce = comboBoxCE.SelectedItem as CE;

            foreach (var table in ce.voteTables)
            {
                comboBoxTable.Items.Add(table);
            }

            if (comboBoxTable.Items.Count > 0)
            {
                comboBoxTable.SelectedIndex = 0;
            }

            comboBoxTable.EndUpdate();
            // add data to vote-table
        }

        private void textBoxVote_KeyDown(object sender, KeyEventArgs e)
        {
            // only allow number to be entered
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers != Keys.Shift) ||
                (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 ||
                 e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5 ||
                 e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 ||
                 e.KeyCode == Keys.NumPad9))
            {
                // present it from be sent to child controls (would still display the char in textbox)
                e.Handled = true;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void tabControlMenu_Selected(object sender, TabControlEventArgs e)
        {
            if (listBoxUsers.Items.Count == 0)
            {
                listBoxUsers.BeginUpdate();
                foreach (var login in _voteModel.Users.OrderBy(user => user.Name))
                {
                    listBoxUsers.Items.Add(login);
                }
                listBoxUsers.EndUpdate();
            }
        }


        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.Items.Count == 0)
            {
                return;
            }

            if (listBoxUsers.SelectedItem == null)
            {
                return;
            }

            User user = listBoxUsers.SelectedItem as User;

            if (user == null)
            {
                // notify
                return;
            }

            _voteModel.Users.Remove(user);
            listBoxUsers.Items.RemoveAt(listBoxUsers.SelectedIndex);
            _voteModel.SaveChanges();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            // check if user with same user-name doesn's already exits in db

            // validate/confirm password

            // TODO: Handle admin

            // push to loginTable in db

            string userName = textBoxUserName.Text.Trim();
            string name = textBoxName.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();


            if (!DataValidator.IsValidPassword(password))
            {
                // notify error
                return;
            }

            if (!DataValidator.IsValidUserName(userName))
            {
                // notify error
                return;
            }

            if (!DataValidator.IsValidName(name))
            {
                // notify error
                return;
            }

            if (!password.Equals(confirmPassword, StringComparison.Ordinal))
            {
                // message user password doesn't match
                return;
            }

            var user = new User
            {
                Name = name,
                FullName = userName,
                Password = password,
                DateCreation = DateTime.Now
            };

            _voteModel.Users.Add(user);
            _voteModel.SaveChanges();

            MessageBox.Show("User added");

            // update listbox users
        }

        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }
    }
}
