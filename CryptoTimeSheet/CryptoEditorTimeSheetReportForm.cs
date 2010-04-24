using System;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoTimeSheet
{
    public partial class CryptoEditorTimeSheetReportForm : Form
    {
        private CryptoEditorDoc<CryptoEditorTimeSheetItem> Doc;

        public CryptoEditorTimeSheetReportForm(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn)
        {
            InitializeComponent();
            Doc = docIn;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            double totalHours = 0.0;
            StringBuilder sb = new StringBuilder();
            AddHours(Doc, Doc.Name, ref totalHours, ref sb);

            sb.AppendLine(" \t \tTotal:\t" + totalHours);
            Console.Write(sb.ToString());

            CryptoEditorTimeSheetReportView form = new CryptoEditorTimeSheetReportView(sb.ToString());
            form.ShowDialog();
        }

        private void AddHours(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn, 
            string breadCrumbs,
            ref double total, 
            ref StringBuilder sb)
        {
            foreach (CryptoEditorDoc<CryptoEditorTimeSheetItem> doc in docIn.Folders)
            {
                if (doc.Active)
                {
                    AddHours(doc, breadCrumbs + "/" + doc.Name, ref total, ref sb);
                }
            }

            foreach (CryptoEditorTimeSheetItem item in docIn.Items)
            {
                if (item.Active)
                {
                    if (item.Time >= fromDate.Value.Date && item.Time < toDate.Value.Date.AddDays(1))
                    {
                        total += item.Hours;
                        sb.AppendLine(item.Time.ToShortDateString() + "\t" +
                                      breadCrumbs + "\t" +
                                      item.Name + "\t" +
                                      item.Hours + "\t" +
                                      item.Notes.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "));
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
