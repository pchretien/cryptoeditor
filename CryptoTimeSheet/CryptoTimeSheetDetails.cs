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
            CryptoEditorTimeSheetItem item = (CryptoEditorTimeSheetItem)itemIn;

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
    }
}
