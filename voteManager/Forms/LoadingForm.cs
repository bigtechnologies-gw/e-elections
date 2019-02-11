using System.Diagnostics;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class LoadingForm : Form
    {
        //private readonly Timer _timer = new Timer();

        public LoadingForm()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;

            /*_timer.Tick += (o, args) =>
            {
                Debug.WriteLine("ivandro ismaelg omes jao!");
            };*/
        }
        
    }
}
