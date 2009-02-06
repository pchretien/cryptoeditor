using CryptoEditor.Common;
using CryptoEditor.Framework;

namespace CryptoEditor.Template
{
    [CryptoEditorPlugin("Template")]
    public class CryptoTemplate : CryptoEditorPlugin<CryptoEditorTemplateItem>
    {
        public CryptoTemplate()
        {
            //this.Detail = new CryptoEditorTemplateDetail(this);
        }

        /// <summary>
        /// You must override this method to create a new item for your plugin
        /// otherwise the base class will throw a NoImplementation exception
        /// </summary>
        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorTemplateItem item = new CryptoEditorTemplateItem("name - " + System.Guid.NewGuid(),
                "value - " + System.Guid.NewGuid());

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorTemplateItem item = (CryptoEditorTemplateItem) itemIn;
            item.Email += "<*>";

            base.UpdateItem(item);
            return item;
        }
    }
}
