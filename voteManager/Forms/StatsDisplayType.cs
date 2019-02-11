using System.Drawing;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class StatsDisplayType : Form
    {
        public StatsDisplayType()
        {
            InitializeComponent();

            Paint += StatsDisplayType_Paint;
        }

        private void StatsDisplayType_Paint(object sender, PaintEventArgs e)
        {
            var primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
            var secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

            e.Graphics.FillRectangle(primaryBrush, 0, 0, Width, 25);
            e.Graphics.FillRectangle(secondaryBrush, 0, ClientRectangle.Y - 25, Width, 25);
        }
    }
}
