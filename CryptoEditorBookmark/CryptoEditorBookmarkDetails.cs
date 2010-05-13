using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorBookmark
{
    public partial class CryptoEditorBookmarkDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorBookmarkItem item = null;

        public CryptoEditorBookmarkDetails(ICryptoEditor plugin)
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
            item = (CryptoEditorBookmarkItem)itemIn;

            // Clear fields
            title.Clear();
            url.Clear();
            note.Clear();

            BringToFront();

            if (item == null)
            {
                this.Enabled = false;
                return;
            }

            this.Enabled = true;

            // Fill in fields ...
            title.Text = item.Title;
            url.Text = item.Url;
            note.Text = item.Note;

            webBrowser.Navigate(item.Url);
        }

        private void note_Validated(object sender, EventArgs e)
        {
            if (!item.Note.Equals(note.Text))
            {
                item.Note = note.Text;
                item.Update();
                plugin.SetChanged();
            }
        }
    }
}
