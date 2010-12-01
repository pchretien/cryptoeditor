using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoTimeSheet
{
    public partial class CryptoTimeSheetDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorTimeSheetItem item = null;

        public CryptoTimeSheetDetails(ICryptoEditor plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayItem(object itemIn)
        {
            item = (CryptoEditorTimeSheetItem)itemIn;

            // Clear fields
            time.Clear();
            hours.Clear();
            name.Clear();
            notes.Clear();

            BringToFront();

            if (item == null)
            {
                this.Enabled = false;
                return;
            }

            this.Enabled = true;

            // Fill in fields ...
            time.Text += string.Format("{0:0000}/", item.Time.Year);
            time.Text += string.Format("{0:00}/", item.Time.Month);
            time.Text += string.Format("{0:00}", item.Time.Day);

            hours.Text = string.Format("{0:00.00}", item.Hours);

            name.Text = item.Name;
            notes.Text = item.Notes;
        }

        private void notes_Validated(object sender, EventArgs e)
        {
            if (item != null && !item.Notes.Equals(notes.Text))
            {
                item.Notes = notes.Text;
                item.Update();
                plugin.SetChanged();
            }
        }

        private void hours_Validated(object sender, EventArgs e)
        {
            if(item == null)
                return;

            double hoursIn = item.Hours;

            try
            {
                hoursIn = double.Parse(hours.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Hours format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hours.Text = string.Format("{0:00.00}", item.Hours);
                return;
            }

            if (item.Hours != hoursIn)
            {
                item.Hours = hoursIn;
                hours.Text = string.Format("{0:00.00}", item.Hours);

                item.Update();
                plugin.SetChanged();
            }
        }
    }
}
