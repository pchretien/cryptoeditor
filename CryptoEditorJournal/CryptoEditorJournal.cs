using System;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Journal
{
    [CryptoEditorPlugin("Journal")]
    class CryptoEditorJournal : CryptoEditorPlugin<CryptoEditorJournalItem>
    {
        public CryptoEditorJournal()
        {
            //this.Detail = new CryptoEditorPluginDetailList<CryptoEditorJournalItem>(this);
            this.Detail = new CryptoEditorJournalDetails(this);
        }

        public override object CreateItem()
        {
            CryptoEditorJournalItem item = new CryptoEditorJournalItem(DateTime.Now, "", "");
            CryptoEditorJournalForm form = new CryptoEditorJournalForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorJournalItem item = (CryptoEditorJournalItem)itemIn;
            CryptoEditorJournalForm form = new CryptoEditorJournalForm(item);
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
