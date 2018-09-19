using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoteManager.Forms;
using VoteManager.Helpers;

namespace VoteManager.Bases
{
    public abstract class BaseEditEntity
    {
        protected void InitUI(ComboBox cb)
        {
            cb.BeginUpdate();
            foreach (var sector in DbUtils.AppEntities.Sectors.OrderBy(sector => sector.Name))
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
            var selSector = ((DisplayItem<Sector>)cb.SelectedItem).Item;
            foreach (var ce in selSector.CEs)
            {
                lb.Items.Add(ce.Name);
            }
            lb.EndUpdate();
        }

    }
}
