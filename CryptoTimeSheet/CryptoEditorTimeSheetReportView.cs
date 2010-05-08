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
        public CryptoEditorTimeSheetReportView(string textIn, char separator)
        {
            InitializeComponent();

            text = textIn;
            StringReader sr = new StringReader(textIn);
            List<string[]> report = new List<string[]>();
            
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] tokens = line.Split(new char[]{separator});
                report.Add(tokens);

                line = sr.ReadLine();
            }

            DisplayInListView(report);
        }

        private void DisplayInListView(List<string[]> report)
        {
            reportListView.Clear();

            ColumnHeader col;
            col = reportListView.Columns.Add("Group");
            col.Width = 100;
            col = reportListView.Columns.Add("Date");
            col.Width = 75;
            col = reportListView.Columns.Add("Hours");
            col.Width = 50;
            col = reportListView.Columns.Add("Task");
            col.Width = 200;
            col = reportListView.Columns.Add("Notes");
            col.Width = 200;
            
            foreach (string[] line in report)
            {
                ListViewItem item = reportListView.Items.Add(line[0]);
                for (int i = 1; i < line.Length; i++)
                {
                    item.SubItems.Add(line[i]);
                }
            }
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

        private void ok_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
