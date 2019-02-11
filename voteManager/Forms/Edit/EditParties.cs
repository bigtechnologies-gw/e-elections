using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Forms
{
    public partial class EditPartidos : Form
    {
        private static readonly HashSet<char> InvalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

        public EditPartidos()
        {
            InitializeComponent();

            Paint += EditPartidos_Paint;
            // prevent maximizing when title-bar is doiuble clicked
            // see: https://stackoverflow.com/questions/14701191/disable-maximize-minimize-on-forms-double-click
            MaximizeBox = false;
            UpdateUI();
        }

        private void EditPartidos_Paint(object sender, PaintEventArgs e)
        {
            // draw top banner
            SolidBrush primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
            SolidBrush secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

            // draw bottom banner
            e.Graphics.FillRectangle(primaryBrush, 0, 0, Width, 25);
            e.Graphics.FillRectangle(secondaryBrush, 0, ClientRectangle.Height - 25, Width, 25);

        }

        private void UpdateUI()
        {
            //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            checkedListBoxPartidos.BeginUpdate();
            checkedListBoxPartidos.Items.Clear();
            foreach (Partido partie in DbUtils.AppEntities.Partidos)
            {
                checkedListBoxPartidos.Items.Add(new DisplayItem<Partido>(partie));
                // UNDONE: HANDLE THE CHECK ITEM
                checkedListBoxPartidos.SetItemChecked(checkedListBoxPartidos.Items.Count - 1, partie.Enabled);
            }
            checkedListBoxPartidos.EndUpdate();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // filter extensions
                //ofd.AddExtension
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //pictureBoxPartidoLogo.ImageLocation = ofd.FileName;
                    pictureBoxPartidoLogo.Image = Image.FromFile(ofd.FileName);
                    Partido partie = ((DisplayItem<Partido>)checkedListBoxPartidos.SelectedItem).Item;

                    // TODO: using stream from picture box?

                    // copy using image location?
                    //var bmp = new Bitmap(pictureBoxPartidoLogo.Image);

                    //var bm = new Bitmap(null, )
                    // normalize fileName (since partie may contain '/' as part of its name)
                    string fileName = partie.Name + Path.GetExtension(ofd.FileName);
                    string destFile = Path.Combine(FileUtils.LogoDir, fileName);

                    // TODO: NOT SAVING
                    pictureBoxPartidoLogo.Image.Save(destFile);
                }
            }

        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // TODO: Should the changes be applied only when user click okay
            DbUtils.AppEntities.SaveChanges();
        }

        private void CheckedListBoxPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!groupBox2.Enabled)
            {
                groupBox2.Enabled = true;
            }

            Partido partie = ((DisplayItem<Partido>)checkedListBoxPartidos.SelectedItem).Item;
            textBoxName.Text = partie.Name;

            // update partie logo

            string logo = Directory.GetFiles(Path.Combine(FileUtils.BaseDir, "logo"), NormalizeName(partie.Name) + "*").FirstOrDefault();

            // logo not found!
            if (File.Exists(logo) == false)
            {
                pictureBoxPartidoLogo.Image = null;
                pictureBoxPartidoLogo.Refresh();
                return;
            }
            //pictureBoxPartidoLogo.ImageLocation = logo;
            pictureBoxPartidoLogo.Image = Image.FromFile(logo);
        }

        private void CheckedListBoxPartidos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DisplayItem<Partido> displayItem = (DisplayItem<Partido>)checkedListBoxPartidos.Items[e.Index];
            Partido partido = displayItem.Item;
            partido.Enabled = e.NewValue == CheckState.Checked;
            //linkLabelPoweredByBigTech.Text = $"currentvalue {e.CurrentValue} - newvalue: {e.NewValue} - partido-enabled: {partido.Enabled}";
        }

        private static string NormalizeName(string partieName)
        {
            for (int i = partieName.Length - 1; i >= 0; i--)
            {
                char ch = partieName[i];
                if (InvalidFileNameChars.Contains(ch))
                {
                    partieName = partieName.Remove(i, 1);
                    partieName = partieName.Insert(i, "-");
                }
            }
            return partieName;
        }

        private void PictureBoxPartidoLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
