using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Forms
{
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();

            // init ui
            comboBoxPartidoName.BeginUpdate();
            comboBoxPartidoName.Items.Clear();
            foreach (Partido partido in DbUtils.AppEntities.Partidos)
            {
                // init with predefined partidos
                comboBoxPartidoName.Items.Add(new DisplayItem<Partido>(partido));
            }

            comboBoxPartidoName.EndUpdate();

            // load configs
            comboBoxPartidoName.Text = Configurations.PartieInfo.Name;
            textBoxWebsite.Text = Configurations.PartieInfo.Website;
            pictureBox1.ImageLocation = Configurations.PartieInfo.LogoFile;

            // labels
            labelPrimaryColor.BackColor = Configurations.PartieInfo.PrimaryColor;
            labelSecondaryColor.BackColor = Configurations.PartieInfo.SecondaryColor;

            Paint += CustomForm_Paint;

            //FormBorderStyle = FormBorderStyle.None;
            //var timer = new Timer { Interval = 1000 * 5 };
            //timer.Tick += (sender, args) =>
            //{
            //    FormBorderStyle = FormBorderStyle != FormBorderStyle.None ? FormBorderStyle.None : FormBorderStyle.FixedToolWindow;
            //};
            //timer.Enabled = true;
            //GC.KeepAlive(timer);
        }

        private void CustomForm_Paint(object sender, PaintEventArgs e)
        {
            int rectangleHeight = 25;
            // draw top banner
            e.Graphics.FillRectangle(new SolidBrush(Configurations.PartieInfo.PrimaryColor), 0, 0, Width, rectangleHeight);

            // draw bottom banner
            //var rect = RectangleToScreen(ClientRectangle);
            SolidBrush seconaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);
            //int titleBar = rect.Top - Top;

            // note: the titlebar won't be accurete there will 8 pixel* missing to add it manually
            // maybe it's due to form border (when border is removed the rectnagle matches correctly)
            e.Graphics.FillRectangle(seconaryBrush, 0, ClientRectangle.Height - rectangleHeight, Width, rectangleHeight);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                pictureBox1.ImageLocation = of.FileName;
            }
        }

        private void ButtonChoosePrimaryColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelPrimaryColor.BackColor = colorDialog1.Color;
                Invalidate();
                Update();
            }
        }

        private void ButtonChooseSecondaryColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelSecondaryColor.BackColor = colorDialog1.Color;
                Invalidate();
                Update();
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Configurations.PartieInfo.Name = comboBoxPartidoName.Text;
            Configurations.PartieInfo.Website = textBoxWebsite.Text;
            Configurations.PartieInfo.LogoFile = pictureBox1.ImageLocation;
            Configurations.PartieInfo.PrimaryColor = labelPrimaryColor.BackColor;
            Configurations.PartieInfo.SecondaryColor = labelSecondaryColor.BackColor;
            Configurations.Save();

            MovieLogoFile();

            // save config to xml file.
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Copy logo file to base directory
        /// </summary>
        private void MovieLogoFile()
        {
            string logoFile = pictureBox1.ImageLocation;

            if (string.IsNullOrEmpty(logoFile) || File.Exists(logoFile) == false)
            {
                return;
            }

            try
            {
                string destSource = Path.Combine(FileUtils.LogoDir,
                    string.Concat(comboBoxPartidoName.Text, Path.GetExtension(logoFile)));
                File.Copy(logoFile, destSource, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
