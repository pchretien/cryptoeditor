using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Todo
{
    public partial class CryptoEditorTodoDetails : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorTodoItem item = null;

        public CryptoEditorTodoDetails(ICryptoEditor plugin)
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
            item = (CryptoEditorTodoItem)itemIn;

            // Clear fields
            title.Clear();
            date.Value = DateTime.Now;
            status.SelectedIndex = -1;
            priority.SelectedIndex = -1;
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
            date.Value = item.Date;
            priority.SelectedIndex = item.Priority;
            status.SelectedIndex = item.Status;
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
