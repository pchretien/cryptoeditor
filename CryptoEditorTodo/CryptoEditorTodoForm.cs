using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.Todo
{
    public partial class CryptoEditorTodoForm : Form
    {
        private CryptoEditorTodoItem item;

        public CryptoEditorTodoForm(CryptoEditorTodoItem item)
        {
            InitializeComponent();
            this.item = item;

            title.Text = item.Title;
            date.Value = item.Date;
            priority.SelectedIndex = item.Priority;
            status.SelectedIndex = item.Status;
            note.Text = item.Note;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            item.Title = title.Text;
            item.Date = date.Value;
            item.Priority = priority.SelectedIndex;
            item.Status = status.SelectedIndex;
            item.Note = note.Text;

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
