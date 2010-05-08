using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.Journal
{
    public partial class CryptoEditorJournalForm : Form
    {
        private CryptoEditorJournalItem _item;
        public CryptoEditorJournalForm(CryptoEditorJournalItem item)
        {
            InitializeComponent();
            _item = item;

            date.Value = item.Date;
            title.Text = item.Title;
            text.Text = item.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _item.Date = date.Value;
            _item.Title = title.Text;
            _item.Text = text.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
