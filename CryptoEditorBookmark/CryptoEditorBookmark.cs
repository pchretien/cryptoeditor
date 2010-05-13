using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditorBookmark
{
    [CryptoEditorPlugin("Bookmarks")]
    public class CryptoEditorBookmark : CryptoEditorPlugin<CryptoEditorBookmarkItem>
    {
        public CryptoEditorBookmark()
        {
            this.Detail = new CryptoEditorBookmarkDetails(this);
        }

        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorBookmarkItem item = new CryptoEditorBookmarkItem();
            CryptoEditorBookmarkForm form = new CryptoEditorBookmarkForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorBookmarkItem item = (CryptoEditorBookmarkItem)itemIn;
            CryptoEditorBookmarkForm form = new CryptoEditorBookmarkForm(item);
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
