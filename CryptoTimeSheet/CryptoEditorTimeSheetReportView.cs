using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CryptoTimeSheet
{
    public partial class CryptoEditorTimeSheetReportView : Form
    {
        private string text = "";
        public CryptoEditorTimeSheetReportView(string textIn)
        {
            InitializeComponent();
            text = textIn;
            reportText.Text = textIn;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter outFile = new StreamWriter(saveFileDialog.FileName);
                outFile.Write(text);
                outFile.Close();
            }
        }
    }
}
