using System.Collections.Generic;
using System.Windows.Forms;
//using System.Windows.Controls;

namespace VoteManager.Helpers
{
    public static class UIUtils
    {
        public static void UpdateListBox(ListBox lb, IEnumerable<object> items)
        {
            lb.BeginUpdate();
            foreach (var item in items)
            {
                lb.Items.Add(item);
            }
            lb.EndUpdate();
        }

        public static void UpdateComboBox(ComboBox cb, IEnumerable<object> items)
        {
            cb.BeginUpdate();
            foreach (var item in items)
            {
                cb.Items.Add(item);
            }
            cb.EndUpdate();
        }

    }
}
