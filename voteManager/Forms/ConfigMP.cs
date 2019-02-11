using EElections.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class ConfigMp : Form
    {
        public int NumberOfVoteToMp => int.TryParse(textBoxMP.Text, out int value) ? value : 5000;

        public ConfigMp()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
            Paint += ConfigMP_Paint;

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;

            textBoxMP.KeyDown += UIUtils.TextBoxKeyDownHandler;
            buttonOK.DialogResult = DialogResult.OK;

            buttonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMP.Text))
            {
                MessageBox.Show("5000 will be used as default value!", "MP not set!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DialogResult = DialogResult.OK;
        }

        private void ConfigMP_Paint(object sender, PaintEventArgs e)
        {
            // rectangles
            Rectangle topRect = new Rectangle(0, 0, Width, 20);

            //int titleBar = RectangleToScreen(ClientRectangle).Top - Top;
            //Rectangle bottomRect = new Rectangle(0, Height - (titleBar + 8), Width, 20);

            var bottomRectangle = new Rectangle(0, ClientRectangle.Height - topRect.Height, Width, topRect.Height);

            // brushes 
            SolidBrush primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
            SolidBrush secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

            // draw shapes
            e.Graphics.FillRectangle(primaryBrush, topRect);
            e.Graphics.FillRectangle(secondaryBrush, bottomRectangle);
        }
    }
}
