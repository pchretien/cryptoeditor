using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Journal
{
    public partial class CryptoEditorJournalDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorJournalItem item;

        public CryptoEditorJournalDetails(ICryptoEditor plugin)
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
            item = (CryptoEditorJournalItem)itemIn;

            date.Value = DateTime.Now;
            title.Clear();
            text.Clear();

            BringToFront();

            if (item == null)
            {
                this.Enabled = false;
                return;
            }

            this.Enabled = true;

            // Fill in fields ...
            date.Value = item.Date;
            title.Text = item.Title;
            text.Text = item.Text;
        }

        private void text_Validated(object sender, EventArgs e)
        {
            if (!item.Text.Equals(text.Text))
            {
                item.Text = text.Text;
                item.Update();
                plugin.SetChanged();
            }
        }
    }
}
