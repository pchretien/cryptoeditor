using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoNotes
{
    [CryptoEditorPlugin("Notes")]
    public class CryptoEditorNotes : CryptoEditorPlugin<CryptoEditorNotesItem>
    {
        public CryptoEditorNotes()
        {
            this.Detail = new CryptoEditorPluginDetailList<CryptoEditorNotesItem>(this);
        }

        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorNotesItem item = new CryptoEditorNotesItem("name - " + System.Guid.NewGuid(),
                "value - " + System.Guid.NewGuid());

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorNotesItem item = (CryptoEditorNotesItem)itemIn;
            item.Note += "<*>";

            base.UpdateItem(item);
            return item;
        }
    }
}
