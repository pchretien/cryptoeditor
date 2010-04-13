using CryptoEditor.CmdFramework;
using CryptoEditor.Common;

namespace CryptoEditor.Template
{
    [CryptoEditorPlugin("Template")]
    public class CryptoTemplate : CryptoEditorCmdPlugin<CryptoEditorTemplateItem>
    {
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
            CryptoEditorTemplateItem item = (CryptoEditorTemplateItem)itemIn;
            item.Email += "<*>";

            base.UpdateItem(item);
            return item;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
