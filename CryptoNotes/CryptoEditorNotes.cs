using System.Windows.Forms;
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
            CryptoEditorNotesItem item = new CryptoEditorNotesItem();
            CryptoEditorNotesForm form = new CryptoEditorNotesForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorNotesItem item = (CryptoEditorNotesItem)itemIn;
            CryptoEditorNotesForm form = new CryptoEditorNotesForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return item;

            base.UpdateItem(item);
            return item;
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
