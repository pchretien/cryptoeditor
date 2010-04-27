using System;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoTimeSheet
{
    public partial class CryptoEditorTimeSheetReportForm : Form
    {
        private string delimiterChar = " ";
        private CryptoEditorDoc<CryptoEditorTimeSheetItem> Doc;

        public CryptoEditorTimeSheetReportForm(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn)
        {
            InitializeComponent();
            Doc = docIn;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            double totalHours = 0.0;
            StringBuilder sbHours = new StringBuilder();
            StringBuilder sbDetails = new StringBuilder();
            AddHours(Doc, Doc.Name, ref totalHours, ref sbDetails, ref sbHours);
            sbHours.AppendLine("Total: " + totalHours);
            
            sbDetails.AppendLine("");
            sbDetails.AppendLine(sbHours.ToString());

            CryptoEditorTimeSheetReportView form = new CryptoEditorTimeSheetReportView(sbDetails.ToString());
            form.ShowDialog();
        }

        private void AddHours(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn, 
            string breadCrumbs,
            ref double total, 
            ref StringBuilder sbDetails,
            ref StringBuilder sbHours)
        {
            foreach (CryptoEditorDoc<CryptoEditorTimeSheetItem> doc in docIn.Folders)
            {
                if (doc.Active)
                {
                    double oldTotal = total;
                    AddHours(doc, breadCrumbs + "/" + doc.Name, ref total, ref sbDetails, ref sbHours);
                    if(totalsCheck.Checked)
                        sbHours.AppendLine(breadCrumbs + "/" + doc.Name + ": " + Convert.ToString(total - oldTotal));
                }
            }

            double oldTotal2 = total;
            foreach (CryptoEditorTimeSheetItem item in docIn.Items)
            {
                if (item.Active)
                {
                    if (item.Time >= fromDate.Value.Date && item.Time < toDate.Value.Date.AddDays(1))
                    {
                        total += item.Hours;
                        delimiterChar = (delimiter.Text.Equals("[tab]")) ? "\t" : delimiter.Text;

                        sbDetails.AppendLine(item.Time.ToShortDateString() + delimiterChar +
                                      breadCrumbs + delimiterChar +
                                      item.Name + delimiterChar +
                                      item.Hours + delimiterChar +
                                      item.Notes.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "));
                    }
                }
            }
            if (docIn.Items.Count > 0 && folderCheck.Checked)
            {
                sbDetails.AppendLine(breadCrumbs + ": " + Convert.ToString(total - oldTotal2));
                sbDetails.AppendLine();
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
