using System;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoTimeSheet
{
    public partial class CryptoEditorTimeSheetReportForm : Form
    {
        private char delimiterChar = '\t';
        private CryptoEditorDoc<CryptoEditorTimeSheetItem> Doc;

        public CryptoEditorTimeSheetReportForm(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn)
        {
            InitializeComponent();
            Doc = docIn;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            delimiterChar = (delimiter.Text.Equals("[tab]")) ? '\t' : delimiter.Text[0];

            double totalHours = 0.0;
            StringBuilder sbHours = new StringBuilder();
            StringBuilder sbDetails = new StringBuilder();
            AddHours(Doc, (Doc.Name.ToLower().Equals("timesheet")?"":Doc.Name), ref totalHours, ref sbDetails, ref sbHours);
            sbHours.AppendLine("Total" + delimiterChar + " " + delimiterChar + string.Format("{0:00.00}", totalHours));
            sbDetails.AppendLine(sbHours.ToString());

            CryptoEditorTimeSheetReportView form = new CryptoEditorTimeSheetReportView(sbDetails.ToString(), delimiterChar);
            form.ShowDialog();
        }

        public static int CompareCryptoEditorTimeSheetItem(CryptoEditorTimeSheetItem i1, CryptoEditorTimeSheetItem i2)
        {
            return i1.Time.CompareTo(i2.Time);
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
                    string newBreadCrumbs = breadCrumbs + "/" + doc.Name;
                    AddHours(doc, newBreadCrumbs, ref total, ref sbDetails, ref sbHours);
                    if(totalsCheck.Checked)
                        sbHours.AppendLine(newBreadCrumbs + delimiterChar + " " + delimiterChar + string.Format("{0:00.00}", total - oldTotal));
                }
            }

            docIn.Items.Sort(CompareCryptoEditorTimeSheetItem);

            double oldTotal2 = total;
            double dayTotal = 0.0;
            DateTime lastDay = DateTime.MinValue;
            StringBuilder sbDayDetails = new StringBuilder();

            foreach (CryptoEditorTimeSheetItem item in docIn.Items)
            {
                if (item.Active)
                {
                    if (item.Time >= fromDate.Value.Date && item.Time < toDate.Value.Date.AddDays(1))
                    {
                        if( item.Time.Date.CompareTo(lastDay.Date) != 0 && 
                            sbDayDetails.Length > 0)
                        {
                            sbDetails.Append(sbDayDetails.ToString());
                            if (totalByDay.Checked)
                                sbDetails.AppendLine(string.Format("{0}{4}{1:0000}/{2:00}/{3:00}{4}{5:00.00}", breadCrumbs, lastDay.Year, lastDay.Month, lastDay.Day, delimiterChar, dayTotal));

                            dayTotal = 0.0;
                            sbDayDetails.Remove(0, sbDayDetails.Length);
                        }

                        lastDay = item.Time.Date;

                        total += item.Hours;
                        dayTotal += item.Hours;

                        sbDayDetails.AppendLine(breadCrumbs + delimiterChar + 
                                      string.Format("{0:0000}/{1:00}/{2:00}", item.Time.Year, item.Time.Month, item.Time.Day) + delimiterChar +
                                      string.Format("{0:00.00}", item.Hours) + delimiterChar +
                                      item.Name.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Replace(delimiterChar, ' ') + delimiterChar +
                                      item.Notes.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Replace(delimiterChar, ' '));
                    }
                }
            }

            if (sbDayDetails.Length > 0)
            {
                sbDetails.Append(sbDayDetails.ToString());
                if (totalByDay.Checked)
                    sbDetails.AppendLine(string.Format("{0}{4}{1:0000}/{2:00}/{3:00}{4}{5:00.00}", breadCrumbs, lastDay.Year, lastDay.Month, lastDay.Day, delimiterChar, dayTotal));
            }


            if (docIn.Items.Count > 0 && folderCheck.Checked)
            {
                sbDetails.AppendLine(breadCrumbs + delimiterChar + " " + delimiterChar + string.Format("{0:00.00}", total - oldTotal2));
            }

            sbDetails.AppendLine();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
