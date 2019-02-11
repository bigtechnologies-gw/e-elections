using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//using System.Windows.Controls;

namespace EElections.Helpers
{
    public static class UIUtils
    {
        public static void UpdateListBox(ListBox lb, IEnumerable<object> items)
        {
            var listView = new ListView();
            listView.ClearAllItem();
            lb.BeginUpdate();
            // remove any pre-exitting item in listview...
            lb.Items.Clear();
            foreach (object item in items)
            {
                lb.Items.Add(item);
            }
            lb.EndUpdate();
        }

        public static void UpdateComboBox(ComboBox cb, IEnumerable<object> items)
        {
            cb.BeginUpdate();
            // make sure all the item in combobox is already removed 
            cb.Items.Clear();
            foreach (object item in items)
            {
                cb.Items.Add(item);
            }
            cb.EndUpdate();
        }

        public static void TextBoxKeyDownHandler(object sender, KeyEventArgs e)
        {
            // only allow number to be entered
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers != Keys.Shift) ||
                (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 ||
                 e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5 ||
                 e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 ||
                 e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back || (e.KeyData == (Keys.Control | Keys.A))))
            {
                // present it from be sent to child controls (would still display the char in textbox)
                e.Handled = true;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
            // Note: could be achived with marsked-textbox-control

        }

        public static void DrawBanner(Control control, PaintEventArgs e)
        {
            // draw header banner
            //e.Graphics.FillRectangle(new SolidBrush(Configurations.PartieInfo.PrimaryColor), 0, 35, control.Width, 20);

            // Note: not needed when working with groupbox directly!
            //var rectangleToScreen = control.RectangleToScreen(control.ClientRectangle);
            //var titleBarHeight = rectangleToScreen.Top - control.Top;
            int rectangleHeight = 25;

            //draw footer banner
            e.Graphics.FillRectangle(new SolidBrush(Configurations.PartieInfo.SecondaryColor),
                0,
                control.Height - rectangleHeight,
                control.Width,
                rectangleHeight);
        }

    }
}
