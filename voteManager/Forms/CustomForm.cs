using System;
using System.Windows.Forms;
using VoteManager.Helpers;

namespace VoteManager.Forms
{
    public partial class CustomForm : Form
    {
        /// <summary>
        /// Contains the information of the partido that bought this application
        /// </summary>
        public PartidoInfo PartidoInfo { get; set; }

        public CustomForm()
        {
            InitializeComponent();

            // init ui
            comboBoxPartidoName.BeginUpdate();
            comboBoxPartidoName.Items.Clear();
            foreach (var partido in DbUtils.AppEntities.Partidos)
            {
                // init with predefined partidos
                comboBoxPartidoName.Items.Add(new DisplayItem<Partido>(partido));
            }
            comboBoxPartidoName.EndUpdate();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                if (of.ShowDialog(this) == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = of.FileName;
                }
            }
        }

        private void ButtonChoosePrimaryColor_Click(object sender, EventArgs e)
        {
            SetColor(labelPrimaryColor);
        }

        private void ButtonChooseSecondaryColor_Click(object sender, EventArgs e)
        {
            SetColor(labelSecondaryColor);
        }

        private void SetColor(Label labelColor)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelColor.BackColor = colorDialog1.Color;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // validation

            PartidoInfo = new PartidoInfo
            {
                Name = comboBoxPartidoName.Text,
                Website = string.IsNullOrEmpty(textBox2.Text) ? string.Empty : textBox2.Text,
                LogoFile = pictureBox1.ImageLocation,
                PrimcaryColor = labelPrimaryColor.BackColor,
                SEcondaryColor = labelSecondaryColor.BackColor,
            };

            DialogResult = DialogResult.OK;
        }
    }
}
