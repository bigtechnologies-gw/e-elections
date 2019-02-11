using EElections.Forms.Statistics;
using EElections.Helpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class Main : Form
    {
        private readonly voteAppEntities DbContext;
        private readonly User _loginUser;

        public Main(User loginUser)
        {
            InitializeComponent();

            FormClosed += Main_FormClosed;

            textBoxInvalidVote.KeyDown += UIUtils.TextBoxKeyDownHandler;
            textBoxRegistered.KeyDown += UIUtils.TextBoxKeyDownHandler;
            textBoxVote.KeyDown += UIUtils.TextBoxKeyDownHandler;

            DbContext = DbUtils.AppEntities;
            _loginUser = loginUser;
#if !DEBUG
            groupBoxAddVote.Enabled = loginUser.Type == TypeUser.Admin;
#endif

            InitUI();

            //this.listViewVotes.rectangle
            //buttonAddVote.Paint += (o, args) => ButtonAddVote_Paint(o, args);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        public void InitUI()
        {
            // placeholder
            textBoxVote.MouseHover += delegate
            {
                if (textBoxVote.ForeColor == Color.Silver)
                {
                    textBoxVote.Text = string.Empty;
                    textBoxVote.ForeColor = Color.Black;
                }
            };

            //textBoxVote.MouseEnter += delegate
            //{
            //    if (textBoxVote.Text.Equals("Enter vote", StringComparison.OrdinalIgnoreCase))
            //    {
            //        textBoxVote.Text = string.Empty;
            //        textBoxVote.ForeColor = Color.Black;
            //    }
            //};

            textBoxVote.MouseLeave += delegate
            {
                if (textBoxVote.Text.Length > 0 /*|| textBoxVote.Focused*/)
                {
                    return;
                }
                textBoxVote.Text = "Enter vote";
                textBoxVote.ForeColor = Color.Silver;
                textBoxVote.SelectionStart = textBoxVote.Text.Length;
            };

            LoadPartieLogo();

            // set banner partie custom color
            //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            bool isSuperAdmin = _loginUser.Type == TypeUser.SuperAdmin;
            if (!isSuperAdmin)
            {
                // add Partie to combobox
                comboBoxPartidos.BeginUpdate();
                foreach (Partido partido in DbUtils.AppEntities.Partidos.OrderBy(p => p.Name))
                {
                    comboBoxPartidos.Items.Add(new DisplayItem<Partido>(partido));
                }
                if (comboBoxPartidos.Items.Count > 0)
                {
                    comboBoxPartidos.SelectedIndex = 0;
                }
                comboBoxPartidos.EndUpdate();

                IOrderedQueryable<Region> userRegions = null;
                switch (_loginUser.Type)
                {
                    case TypeUser.Admin:
                        userRegions = DbContext.Regions.Where(region => region.idProvince == _loginUser.ProvinceId).OrderBy(region => region.Name);
                        break;
                    case TypeUser.SuperAdmin:
                        userRegions = DbContext.Regions;
                        break;
                }
                comboBoxRegions.BeginUpdate();
                comboBoxRegions.Items.Clear();
                foreach (Region region in userRegions)
                {
                    comboBoxRegions.Items.Add(new DisplayItem<Region>(region));

                }
                if (comboBoxRegions.Items.Count > 0)
                {
                    comboBoxRegions.SelectedIndex = 0;
                }
                // if there is only one region, select it and display radion-button region
                comboBoxRegions.EndUpdate();
                //UpdateListViewVotes(userRegions);
                statisticsToolStripMenuItem.Enabled = true;
                statisticsToolStripMenuItem.Visible = true;

                /*
                Task.Run(() =>
                {
                    switch (_loginUser.Type)
                    {
                        case TypeUser.Admin:
                            userRegions = DbContext.Regions.Where(region => region.idProvince == _loginUser.ProvinceId).OrderBy(region => region.Name);
                            break;
                        case TypeUser.SuperAdmin:
                            userRegions = DbContext.Regions;
                            break;
                    }
                }).ContinueWith(t =>
                {
                    comboBoxRegions.BeginUpdate();
                    comboBoxRegions.Items.Clear();
                    foreach (Region region in userRegions)
                    {
                        comboBoxRegions.Items.Add(new DisplayItem<Region>(region));

                    }
                    if (comboBoxRegions.Items.Count > 0)
                    {
                        comboBoxRegions.SelectedIndex = 0;
                    }
                    // if there is only one region, select it and display radion-button region
                    comboBoxRegions.EndUpdate();
                    //UpdateListViewVotes(userRegions);
                    statisticsToolStripMenuItem.Enabled = true;
                    statisticsToolStripMenuItem.Visible = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
                */
            }

            optionsToolStripMenuItem.Enabled = isSuperAdmin;
            optionsToolStripMenuItem.Visible = isSuperAdmin;

            // disable if not superadmin
            groupBoxAddVote.Enabled = !isSuperAdmin;
        }

        private void LoadPartieLogo()
        {
            // load partie logo
            //if (File.Exists(Configurations.PartieInfo.LogoFile))
            //{
            //    pictureBoxLogoPartie.ImageLocation = Configurations.PartieInfo.LogoFile;
            //    pictureBoxLogoPartie.SizeMode = PictureBoxSizeMode.StretchImage;
            //    //pictureBoxAppLogo.ImageLocation = Configurations.PartieInfo.LogoFile;
            //    //pictureBoxAppLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            //}
            //else
            //{
            //    pictureBoxLogoPartie.Image = null;
            //}

            // make sure the are if update / refreshed
            pictureBoxLogoPartie.Invalidate();
            pictureBoxLogoPartie.Update();
        }

        private void ButtonAddVote_Click(object sender, EventArgs e)
        {
#if GENERATE
            Debug.WriteLine("Vote generation started!");
            DbUtils.GenerateVote();
            Debug.WriteLine("All done!");
            return;
#endif
            int votes;
            string voteData = textBoxVote.Text; // .TrimStart('0'); // TODO: Uncomment
            if (!int.TryParse(voteData, out votes))
            {
                // invalid data entered
                MessageBox.Show("Invalid data!");
                return;
            }

            int idPartido = ((DisplayItem<Partido>)comboBoxPartidos.SelectedItem).Item.Id;
            int idRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item.Id;
            int idSector = ((DisplayItem<Sector>)comboBoxSectors.SelectedItem).Item.Id;
            int idCE = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item.Id;
            int idTable = ((DisplayItem<VoteTable>)comboBoxVotingTable.SelectedItem).Item.Id;
            int provinceId = _loginUser.ProvinceId;

            // check if vote isn't already inserted
            bool isInDatabase = DbContext.Votes.Any(v => v.idPartido == idPartido
            && v.idRegion == idRegion && v.idSector == idSector
            && v.idCE == idCE && v.idVoteTable == idTable);

            if (isInDatabase)
            {
                MessageBox.Show("Vote already in data base", "Vote already in DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // refresh listview
                return;
            }

            Vote vote = new Vote
            {
                idPartido = idPartido,
                idRegion = idRegion,
                idSector = idSector,
                idCE = idCE,
                idVoteTable = idTable,
                voteData = votes,
                provinceId = provinceId
            };

            DbContext.Votes.Add(vote);
            DbContext.SaveChanges();
            //UpdateListViewVotes();
            MessageBox.Show("Vote added!", "Vote added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxVote.Text = string.Empty;
        }

        private void ComboBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSectors.BeginUpdate();
            comboBoxSectors.Items.Clear();

            Region selRegion = ((DisplayItem<Region>)comboBoxRegions.SelectedItem).Item;
            if (selRegion == null)
            {
                return;
            }
            foreach (Sector sector in selRegion.sectors)
            {
                comboBoxSectors.Items.Add(new DisplayItem<Sector>(sector));
            }
            if (comboBoxSectors.Items.Count > 0)
            {
                comboBoxSectors.SelectedIndex = 0;
            }

            comboBoxSectors.EndUpdate();
        }

        private void ComboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCE.BeginUpdate();
            comboBoxCE.Items.Clear();
            Sector sector = ((DisplayItem<Sector>)comboBoxSectors.SelectedItem).Item;
            // todo: remove this check.
            if (sector == null)
            {
                return;
            }
            foreach (CE ce in sector.CEs)
            {
                comboBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            if (comboBoxCE.Items.Count > 0)
            {
                comboBoxCE.SelectedIndex = 0;
            }
            comboBoxCE.EndUpdate();
        }

        private void ComboBoxCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVotingTable.BeginUpdate();
            comboBoxVotingTable.Items.Clear();
            CE ce = ((DisplayItem<CE>)comboBoxCE.SelectedItem).Item;
            foreach (VoteTable table in ce.voteTables)
            {
                comboBoxVotingTable.Items.Add(new DisplayItem<VoteTable>(table));
            }
            if (comboBoxVotingTable.Items.Count > 0)
            {
                comboBoxVotingTable.SelectedIndex = 0;
            }
            comboBoxVotingTable.EndUpdate();
            // add data to vote-table
        }


        public void UpdateListViewVotes(IQueryable<Region> userRegions = null)
        {
            //listViewVotes.BeginUpdate();
            //listViewVotes.Items.Clear();

            // UNDONE: _voteEntities.votes.GroupBy(v => v.idPartido).OrderBy(v => v.Key);

            foreach (Vote vote in DbContext.Votes.OrderBy(v => v.idSector))
            {
                if (vote == null)
                {
                    continue;
                }

                Partido partido = DbContext.Partidos.FirstOrDefault(p => p.Id == vote.idPartido);
                Sector sector = DbContext.Sectors.FirstOrDefault(p => p.Id == vote.idSector);
                CE ce = DbContext.CEs.FirstOrDefault(p => p.Id == vote.idCE);
                VoteTable voteTable = DbContext.VoteTables.FirstOrDefault(p => p.Id == vote.idVoteTable);

                if (partido == null || sector == null || ce == null || voteTable == null)
                {
                    continue;
                }

                ListViewItem lvi = new ListViewItem(partido.Name)
                {
                    SubItems = { sector.Name, ce.Name, voteTable.Name, vote.voteData.ToString() },
                    Tag = vote
                };


                //foreach (ListViewGroup lvg in listViewVotes.Groups)
                //{
                //    if (!(lvg.Tag is Region))
                //    {
                //        continue;
                //    }

                //    if (((Region)lvg.Tag).Id == sector.RegionId)
                //    {
                //        lvi.Group = lvg;
                //        break;
                //    }

                //}
                //listViewVotes.Items.Add(lvi);
            }

            //listViewVotes.EndUpdate();
        }

        private void EditPartidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditPartidos editPartido = new EditPartidos())
            {
                editPartido.ShowDialog(this);
            }
        }

        private void EditCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditCE editCE = new EditCE(_loginUser))
            {
                editCE.ShowDialog(this);
            }
        }

        private void EditVotingTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditVotingTable editVotingTable = new EditVotingTable(_loginUser))
            {
                editVotingTable.ShowDialog(this);
            }
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Statistics.Statistics formStats = new Statistics.Statistics(_loginUser))
            {
                formStats.ShowDialog(this);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (About about = new About())
            {
                about.StartPosition = FormStartPosition.CenterParent;
                about.ShowDialog(this);
            }
        }

        private void CustomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CustomForm customizeForm = new CustomForm())
            {
                if (customizeForm.ShowDialog(this) == DialogResult.OK)
                {
                    //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
                    //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

                    // to make groupbox2 redraw the banners with new  color
                    groupBox2.Invalidate();
                    groupBox2.Refresh();

                    LoadPartieLogo();

                }
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditPartiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditPartidos editPartie = new EditPartidos())
            {
                editPartie.ShowDialog(this);
            }
        }

        private void EditCEsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditCE editCEs = new EditCE(_loginUser))
            {
                editCEs.ShowDialog(this);
            }
        }

        private void EditVotingTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditVotingTable editVotingTable = new EditVotingTable(_loginUser))
            {
                editVotingTable.ShowDialog(this);
            }
        }

        private void ManageUsersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // NOTE: ONLY SUPERADMIN HAS THE RIGHT TO INVOKE THIS METHOD
#if !DEBUG
            if (_loginUser.Type != TypeUser.SuperAdmin)
            {
                return;
            } 
#endif

            // TODO: this should be precomputed
            var userContext = new LoginUserContext
            {
                ID = _loginUser.Id,
                Name = _loginUser.Name,
                MachineName = Environment.MachineName,
                LoginTime = DateTime.Now, // Incorrect!
                VoteDbContext = DbUtils.AppEntities
            };

            using (EditUserSettings formEditUsers = new EditUserSettings(userContext))
            {
                if (formEditUsers.ShowDialog(this) == DialogResult.OK)
                {
                }
            }
        }

        private void ListViewVotes_DoubleClick(object sender, EventArgs e)
        {
            //if (listViewVotes.SelectedItems.Count == 0)
            //{
            //    return;
            //}

            //var selItem = listViewVotes.SelectedItems[0];
        }

        private void ListViewVotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ListViewItem item = listViewVotes.GetItemAt(e.X, e.Y);

            //if (item == null)
            //{
            //    return;
            //}

            //Vote vote = item.Tag as Vote;

            //using (var editVote = new EditVote(vote, _loginUser))
            //{
            //    if (editVote.ShowDialog(this) == DialogResult.OK)
            //    {
            //        // todo: update only row that is changed in listview 
            //        UpdateListViewVotes();
            //    }
            //}
        }

        private void ListViewVotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GlobalStats globalStatsForm = new GlobalStats(_loginUser))
            {
                globalStatsForm.ShowDialog(this);
            }
        }

        private void GraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Statistics.Statistics graphForm = new Statistics.Statistics(_loginUser))
            {
                graphForm.ShowDialog(this);
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog(this);

            // TODO: PRINT DOCUMENT
            using (PrintDocument printDoc = new PrintDocument())
            {
                //printDoc.PrintController
            }

            printDialog1.Reset();
        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CNEStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CNEVoteStats cneStats = new CNEVoteStats())
            {
                cneStats.ShowDialog(this);
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            // NOTE: ALL THE PAININT IS DONE IN GROUPBOX (SINCE THE MAIN IS FILLED WITH GROUPBOX)

            //e.Graphics.TextRenderingHint = Text.TextRenderingHint.
            // e.ClipRectangle rectangle which will be repainted...
            // this.ClientRectangle: client area of the rectangle
            //if(e.ClipRectangle == this.ClientRectangle) // NOTE: won't be same :P
            //{
            //    Debug.WriteLine("e.ClipRectangle == ClientRectangle");
            //}

            //this.ClientRectangle
            return;

            GraphicsPath gfxPath = new GraphicsPath();

            Point[] points = new Point[]
            {
                new Point(354, 343),

                new Point(457, 450),
                new Point(767, 367),
                new Point(454, 757),
            };

            gfxPath.AddPolygon(points);

            //var region = new Region(gfxPath);
            //e.Graphics.SetClip(region, CombineMode.Replace);

            if (Region == null)
            {
                //e.Graphics.FillRegion()
            }

            //e.Graphics.FillRegion(Brushes.Red, Region);

            //Rectangle thisRectangle = this.ClientRectangle;

            e.Graphics.FillRectangle(Brushes.Blue, ClientRectangle);

            //e.Graphics.FillRegion();
            //e.Graphics.DrawPath(Pens.Red, gfxPath);

            //Note: going to cause stackoverflow exception "base.OnPaint(e)";
        }

        private void GroupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox2.BackColor);
            Graphics gfx = e.Graphics;
            // clear out the transformation matrix
            gfx.ResetTransform();

            // set the new origin
            // ReSharper disable once PossibleLossOfFraction
            gfx.TranslateTransform(Width, Height / 2);
            //gfx.RotateTransform(0, MatrixOrder.Prepend);
            Debug.WriteLine(gfx.RenderingOrigin.ToString());

            PointF[] trianglePoints =
            {
                new PointF(0, gfx.RenderingOrigin.Y - 75),
                new PointF(0, gfx.RenderingOrigin.Y + groupBox2.Height /* *.40f*/),
                new PointF(0 - 713, groupBox2.Height /*gfx.RenderingOrigin.Y / 2 + trackBar1.Value*/)
            };

            // draw rectangle from new origin poin
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            //gfx.InterpolationMode = InterpolationMode.
            gfx.FillPolygon(new SolidBrush(Configurations.PartieInfo.SecondaryColor), trianglePoints);

            // reset the transformation matrix to the new drawing will be placed in expected locations
            gfx.ResetTransform();

            // brushes
            // using (var primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor))
            // using (var secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor))
            // {
            //     var topRectangle = new Rectangle(0, 0, Width, 20);
            // }
            // todo: control+enter not working!

            int rectangleHeight = 25;

            gfx.FillRectangle(new SolidBrush(Configurations.PartieInfo.PrimaryColor), 0, 0, Width, rectangleHeight);

            // note: it is okay to use cliprectangle in this context
            // since we are invalidating the entire groupbox control
            // otherwise cliprectangle would contains only the rectangle of the
            // area that should be painted!
            UIUtils.DrawBanner((Control)sender, e);
        }

        private void GeneralStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // default value is 5k
            int numberOfVoteToMp = 5000;
            using (ConfigMp mp = new ConfigMp())
            {
                if (mp.ShowDialog(this) == DialogResult.OK)
                {
                    numberOfVoteToMp = mp.NumberOfVoteToMp;
                }
            }
            using (GeneralStats generalStats = new GeneralStats(numberOfVoteToMp))
            {
                generalStats.ShowDialog(this);
            }
        }

        private void ButtonUpdateTable_Click(object sender, EventArgs e)
        {
            if (comboBoxVotingTable.Items.Count == 0 || comboBoxVotingTable.SelectedItem == null)
            {
                return;
            }

            // validate datas
            int invalidVotes = Convert.ToInt32(textBoxInvalidVote.Text);
            int registeredVotes = Convert.ToInt32(textBoxRegistered.Text);

            VoteTable vt = ((DisplayItem<VoteTable>)comboBoxVotingTable.SelectedItem).Item;
            vt.InvalidVotes = invalidVotes;
            vt.TotalRegisted = registeredVotes;
            DbContext.SaveChanges();

            MessageBox.Show("Voteing table updated", "Voting table updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ComboBoxVotingTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            VoteTable vt = ((DisplayItem<VoteTable>)comboBoxVotingTable.SelectedItem).Item;
            textBoxInvalidVote.Text = vt.InvalidVotes.ToString();
            textBoxRegistered.Text = vt.TotalRegisted.ToString();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void groupBoxAddVote_Enter(object sender, EventArgs e)
        {

        }
    }
}

// if user is admin of region east he/she can only see sectros/ce/voting-table from east-region