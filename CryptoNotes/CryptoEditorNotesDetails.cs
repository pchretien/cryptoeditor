using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoNotes
{
    public partial class CryptoEditorNotesDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorNotesItem item = null;

        public CryptoEditorNotesDetails(ICryptoEditor plugin)
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
            item = (CryptoEditorNotesItem)itemIn;

            // Clear fields
            title.Clear();
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
            note.Text = item.Note;
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
