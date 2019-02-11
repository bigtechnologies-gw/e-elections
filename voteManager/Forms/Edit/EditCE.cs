using EElections.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EElections.Forms
{
    public partial class EditCE : Form
    {
        public EditCE(User admin)
        {
            InitializeComponent();
            Paint += (sender, e) =>
            {
                // draw top banner
                SolidBrush primaryBrush = new SolidBrush(Configurations.PartieInfo.PrimaryColor);
                SolidBrush secondaryBrush = new SolidBrush(Configurations.PartieInfo.SecondaryColor);

                // draw bottom banner
                e.Graphics.FillRectangle(primaryBrush, 0, 0, Width, 25);
                e.Graphics.FillRectangle(secondaryBrush, 0, ClientRectangle.Height - 25, Width, 25);
            };
            InitUI();
        }

        private void InitUI()
        {
            // set banners color
            //panelBanner.BackColor = Configurations.PartieInfo.PrimaryColor;
            //statusStripBanner.BackColor = Configurations.PartieInfo.SecondaryColor;

            comboBoxRegion.BeginUpdate();
            foreach (Region region in DbUtils.AppEntities.Regions)
            {
                comboBoxRegion.Items.Add(new EElections.DisplayItem<Region>(region));
            }
            comboBoxRegion.EndUpdate();

            if (comboBoxRegion.Items.Count > 0)
            {
                comboBoxRegion.SelectedIndex = 0;
            }
        }

        private void ButtonAddModify_Click(object sender, EventArgs e)
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
            Sector selSector = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;
            foreach (CE ce in selSector.CEs)
            {
                // skip empty names
                if (string.IsNullOrWhiteSpace(ce.Name))
                {
                    continue;
                }
                listBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            listBoxCE.EndUpdate();
            if (listBoxCE.Items.Count > 0)
            {
                listBoxCE.SelectedIndex = 0;
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCE.Items.Count == 0)
            {
                return;
            }

            if (listBoxCE.SelectedItems.Count == 0)
            {
                return;
            }

            CE selItem = ((DisplayItem<CE>)listBoxCE.SelectedItem).Item;

            if (selItem == null)
            {
                return;
            }

            textBoxCE.Text = selItem.Name;
            foreach (object item in comboBoxSector.Items)
            {
                if (item.ToString().Equals(selItem.sector.Name, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxSector.SelectedItem = item;
                    break;
                }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DbUtils.AppEntities.SaveChanges();
            DialogResult = DialogResult.OK;
        }


        private void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Region region = ((DisplayItem<Region>)comboBoxRegion.SelectedItem).Item;
            comboBoxSector.BeginUpdate();
            comboBoxSector.Items.Clear();
            foreach (Sector sector in region.sectors)
            {
                comboBoxSector.Items.Add(new DisplayItem<Sector>(sector));
            }
            if (comboBoxSector.Items.Count > 0)
            {
                comboBoxSector.SelectedIndex = 0;
            }
            comboBoxSector.EndUpdate();
        }

        private void ComboBoxSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sector item = ((DisplayItem<Sector>)comboBoxSector.SelectedItem).Item;

            listBoxCE.BeginUpdate();
            listBoxCE.Items.Clear();
            foreach (CE ce in item.CEs)
            {
                listBoxCE.Items.Add(new DisplayItem<CE>(ce));
            }
            listBoxCE.EndUpdate();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            CE selCE = ((DisplayItem<CE>)listBoxCE.SelectedItem).Item;

            if (selCE == null)
            {
                return;
            }

            // only name can be modified?

            // DataValidator.IsValidName(selCE); // only for person name

            string newCEName = textBoxCE.Text.Trim();

            if (string.IsNullOrEmpty(newCEName))
            {
                MessageBox.Show("Invalid name!");
                return;
            }

            selCE.Name = newCEName;
        }
    }
}
