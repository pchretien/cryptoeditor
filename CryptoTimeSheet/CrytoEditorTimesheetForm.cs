using System;
using System.Windows.Forms;

namespace CryptoTimeSheet
{
    public partial class CrytoEditorTimesheetForm : Form
    {
        private CryptoEditorTimeSheetItem item;

        public CrytoEditorTimesheetForm(CryptoEditorTimeSheetItem item)
        {
            InitializeComponent();
            this.item = item;

            time.Value = item.Time;
            name.Text = item.Name;
            hours.Text = string.Format("{0:00.00}", item.Hours);
            notes.Text = item.Notes;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                double.Parse(hours.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid format for Hours!", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            item.Time = time.Value;
            item.Name = name.Text;
            item.Hours = double.Parse(hours.Text);
            item.Notes = notes.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void hours_Validated(object sender, EventArgs e)
        {
            double hoursIn;

            try
            {
                hoursIn = double.Parse(hours.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Hours format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hours.Text = string.Format("{0:00.00}", item.Hours);
                return;
            }

            hours.Text = string.Format("{0:00.00}", hoursIn);
        }
    }
}
