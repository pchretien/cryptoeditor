using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoNotes
{
    public partial class CryptoEditorNotesForm : Form
    {
        private CryptoEditorNotesItem item;

        public CryptoEditorNotesForm(CryptoEditorNotesItem item)
        {
            InitializeComponent();
            this.item = item;

            title.Text = item.Title;
            note.Text = item.Note;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            item.Title = title.Text;
            item.Note = note.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
