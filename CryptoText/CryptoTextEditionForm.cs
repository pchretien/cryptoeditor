using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.Text
{
    public partial class CryptoTextEditionForm : Form
    {
        public CryptoTextEditionForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            notesTextBox.WordWrap = checkBox1.Checked;
        }
    }
}