using System;
using System.Windows.Forms;
using VoteManager.Helpers;

namespace VoteManager.Forms
{
    public partial class EditPartidos : Form
    {
        public EditPartidos()
        {
            InitializeComponent();

            UpdateUI();
        }

        private void UpdateUI()
        {
            checkedListBoxPartidos.BeginUpdate();
            checkedListBoxPartidos.Items.Clear();
            foreach (var partie in DbUtils.AppEntities.Partidos)
            {
                checkedListBoxPartidos.Items.Add(new DisplayItem<Partido>(partie));
                // UNDONE: HANDLE THE CHECK ITEM
                checkedListBoxPartidos.SetItemChecked(checkedListBoxPartidos.Items.Count - 1, partie.Enabled);
            }
            checkedListBoxPartidos.EndUpdate();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                // filter extensions
                //ofd.AddExtension
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPartidoLogo.ImageLocation = ofd.FileName;
                }
            }

        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            // TODO: Should the changes be applied only when user click okay
            DbUtils.AppEntities.SaveChanges();
        }

        private void CheckedListBoxPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var partie = ((DisplayItem<Partido>)checkedListBoxPartidos.SelectedItem).Item;
            textBoxName.Text = partie.Name;
        }

        private void CheckedListBoxPartidos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var displayItem = (DisplayItem<Partido>)checkedListBoxPartidos.Items[e.Index];
            var partido = displayItem.Item;
            partido.Enabled = e.NewValue == CheckState.Checked;
            //linkLabelPoweredByBigTech.Text = $"currentvalue {e.CurrentValue} - newvalue: {e.NewValue} - partido-enabled: {partido.Enabled}";
        }
    }
}
