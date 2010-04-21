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

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorTimeSheetItem item = (CryptoEditorTimeSheetItem)itemIn;
            CrytoEditorTimesheetForm form = new CrytoEditorTimesheetForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return item;

            base.UpdateItem(item);
            return item;
        }
    }
}
