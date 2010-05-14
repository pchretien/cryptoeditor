using System;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;
using CryptoNotes;

namespace CryptoTimeSheet
{
    [CryptoEditorPlugin("Timesheet")]
    public class CryptoEditorTimeSheet : CryptoEditorPlugin<CryptoEditorTimeSheetItem>
    {
        public CryptoEditorTimeSheet()
        {
            this.Detail = new CryptoEditorPluginDetailList<CryptoEditorTimeSheetItem>(this);
            this.View = new CryptoTimeSheetView(this);
            this.Detail = new CryptoTimeSheetDetails(this);
        }

        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorTimeSheetItem item = new CryptoEditorTimeSheetItem(DateTime.Now, "", 0.0, "");
            CrytoEditorTimesheetForm form = new CrytoEditorTimesheetForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object CreateItem(string dragDropText)
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorTimeSheetItem item = new CryptoEditorTimeSheetItem(DateTime.Now, "", 0.0, dragDropText);
            CrytoEditorTimesheetForm form = new CrytoEditorTimesheetForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorTimeSheetItem item = (CryptoEditorTimeSheetItem)itemIn;
            CrytoEditorTimesheetForm form = new CrytoEditorTimesheetForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return item;

            base.UpdateItem(item);
            return item;
        }

        public override bool HasProperties()
        {
            return true;
        }

        public override void LoadProperties(string filename)
        {
        }

        public override void UpdateProperties(object docIn)
        {
            CryptoEditorTimeSheetReportForm form = new CryptoEditorTimeSheetReportForm((CryptoEditorDoc<CryptoEditorTimeSheetItem>)docIn);
            form.ShowDialog();
        }

        private void AddHours(CryptoEditorDoc<CryptoEditorTimeSheetItem> docIn, ref double total)
        {
            foreach (CryptoEditorDoc<CryptoEditorTimeSheetItem> doc in docIn.Folders)
            {
                if(doc.Active)
                    AddHours(doc, ref total);
            }

            foreach (CryptoEditorTimeSheetItem item in docIn.Items)
            {
                if(item.Active)
                    total += item.Hours;
            }
        }

        public override void SaveProperties()
        {
            throw new NotImplementedException("CryptoEditorTimeSheet.SaveProperties not yet implemented");
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
