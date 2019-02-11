using System.Linq;
using System.Windows.Forms;
using EElections.Helpers;

namespace EElections.Bases
{
    public abstract class BaseEditEntity
    {
        protected void InitUI(ComboBox cb)
        {
            cb.BeginUpdate();
            foreach (Sector sector in DbUtils.AppEntities.Sectors.OrderBy(sector => sector.Name))
            {
                cb.Items.Add(new DisplayItem<Sector>(sector));
            }
            cb.EndUpdate();
        }


        private void UpdateListView(ComboBox cb, ListBox lb)
        {
            if (cb.SelectedItem == null)
            {
                return;
            }
            lb.BeginUpdate();
            lb.Items.Clear();
            Sector selSector = ((DisplayItem<Sector>)cb.SelectedItem).Item;
            foreach (CE ce in selSector.CEs)
            {
                lb.Items.Add(ce.Name);
            }
            lb.EndUpdate();
        }

    }
}
