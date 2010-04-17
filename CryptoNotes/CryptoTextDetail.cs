using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Notes
{
    public partial class CryptoTextDetail : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoTextItem itemIn = null;

        public CryptoTextDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;
            InitializeComponent();
        }

        #region ICryptoEditorDetail Members

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayItem(object item)
        {
            itemIn = (CryptoTextItem)item;

            if (item == null)
            {
                this.notesTextBox.Clear();
                this.titleTextBox.Clear();
                this.subjectTextBox.Clear();
                this.authorTextBox.Clear();
                this.commentsTextBox.Clear();
                this.keywordsTextBox.Clear();

                this.Enabled = false;
            }
            else
            {
                this.notesTextBox.Text = itemIn.Notes;
                this.titleTextBox.Text = itemIn.Title;
                this.subjectTextBox.Text = itemIn.Subject;
                this.authorTextBox.Text = itemIn.Author;
                this.commentsTextBox.Text = itemIn.Comments;
                this.keywordsTextBox.Text = itemIn.Keywords;

                this.Enabled = true;
            }

            BringToFront();
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            notesTextBox.WordWrap = checkBox1.Checked;
        }

        private void notesTextBox_Validated(object sender, EventArgs e)
        {
            if (!itemIn.Notes.Equals(notesTextBox.Text))
            {
                itemIn.Notes = notesTextBox.Text;
                itemIn.Update();
                plugin.SetChanged();
            }
        }
    }
}
