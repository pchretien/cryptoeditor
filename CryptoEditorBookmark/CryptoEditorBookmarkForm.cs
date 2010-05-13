using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditorBookmark
{
    public partial class CryptoEditorBookmarkForm : Form
    {
        private CryptoEditorBookmarkItem item;

        public CryptoEditorBookmarkForm(CryptoEditorBookmarkItem item)
        {
            InitializeComponent();
            this.item = item;

            title.Text = item.Title;
            note.Text = item.Note;
            url.Text = item.Url;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            item.Title = title.Text;
            item.Note = note.Text;
            item.Url = url.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
