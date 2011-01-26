using System;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Reminder
{
    [CryptoEditorPlugin("Reminder")]
    public class CryptoReminder : CryptoEditorPlugin<CryptoEditorReminderItem>
    {
        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorReminderItem item = new CryptoEditorReminderItem();

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorReminderItem item = (CryptoEditorReminderItem)itemIn;
            item.Subject += "<*>";
            item.Note += "bla bla ";

            base.UpdateItem(item);
            return item;
        }
    }
}
