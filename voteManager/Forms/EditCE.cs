using System;
using System.Linq;
using System.Windows.Forms;
using VoteManager.Helpers;

namespace VoteManager.Forms
{
    public partial class EditCE : Form
    {
        public EditCE(User admin)
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            comboBoxRegion.BeginUpdate();
            foreach (var region in DbUtils.AppEntities.Regions)
            {
                comboBoxRegion.Items.Add(new DisplayItem<Region>(region));
            }
            comboBoxRegion.EndUpdate();

            if (comboBoxRegion.Items.Count > 0)
            {
                comboBoxRegion.SelectedIndex = 0;
            }

        }

        private void buttonAddModify_Click(object sender, EventArgs e)
        {
            if (comboBoxSector.SelectedItem == null)
            {
                MessageBox.Show("Please select a sector");
                comboBoxSector.Focus();
                return;
            }
            string ceName = textBoxCE.Text;

            //validate name
            if (DbUtils.AppEntities.CEs.Any(ce => ce.Name.Equals(ceName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("ALREADY ADDED!");
                return;
            }

            Sector sector = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;

            sector.CEs.Add(new CE
            {
                Name = ceName,
            });

            DbUtils.AppEntities.SaveChanges();

            UpdateView();
        }

        private void UpdateView()
        {
            if (comboBoxSector.SelectedItem == null)
            {
                return;
            }
            listBoxCE.BeginUpdate();
            listBoxCE.Items.Clear();
            var selSector = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;
            foreach (var ce in selSector.CEs)
            {
                // skip empty names
                if (string.IsNullOrWhiteSpace(ce.Name))
                {
                    continue;
                }
                listBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            listBoxCE.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCE.Items.Count == 0)
            {
                return;
            }

            if (listBoxCE.SelectedItems.Count == 0)
            {
                return;
            }

            var selItem = ((DisplayItem<CE>)listBoxCE.SelectedItem).Item;

            if (selItem == null)
            {
                return;
            }

            textBoxCE.Text = selItem.Name;
            foreach (var item in comboBoxSector.Items)
            {
                if (item.ToString().Equals(selItem.sector.Name, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxSector.SelectedItem = item;
                    break;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var region = ((DisplayItem<Region>)comboBoxRegion.SelectedItem).Item;
            comboBoxSector.BeginUpdate();
            comboBoxSector.Items.Clear();
            foreach (var sector in region.sectors)
            {
                comboBoxSector.Items.Add(new DisplayItem<Sector>(sector));
            }
            comboBoxSector.EndUpdate();
        }

        private void comboBoxSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;

            listBoxCE.BeginUpdate();
            listBoxCE.Items.Clear();
            foreach (var ce in item.CEs)
            {
                listBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            listBoxCE.EndUpdate();
        }
    }
}
