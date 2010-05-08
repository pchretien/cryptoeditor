using System;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Journal
{
    [CryptoEditorPlugin("Journal")]
    class CryptoEditorJournal : CryptoEditorPlugin<CryptoEditorJournalItem>
    {
        public CryptoEditorJournal()
        {
            this.Detail = new CryptoEditorPluginDetailList<CryptoEditorJournalItem>(this);
        }

        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorJournalItem item = new CryptoEditorJournalItem(DateTime.Now, "Title " + System.Guid.NewGuid(),
                "Text " + System.Guid.NewGuid());

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorJournalItem item = (CryptoEditorJournalItem)itemIn;
            item.Title += "<*>";

            base.UpdateItem(item);
            return item;
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
