using System.Windows.Forms;

//using System.Windows.Controls;

namespace EElections.Helpers
{
    public static class ExtensionMethods
    {
        public static void ClearAllItem(this ListView listview)
        {
            // nothing to be clear..
            if (listview == null)
            {
                return; 
            }
            listview.BeginUpdate();
            listview.Items.Clear();
            listview.EndUpdate();
        }

        public static void SetMAxSize(this Form form)
        {
            form.MaximumSize = form.Size;
        }
    }
}
