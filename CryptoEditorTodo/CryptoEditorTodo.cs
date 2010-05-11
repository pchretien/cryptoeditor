using System;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Todo
{
    [CryptoEditorPlugin("Todo")]
    public class CryptoEditorTodo : CryptoEditorPlugin<CryptoEditorTodoItem>
    {
        public CryptoEditorTodo()
        {
            this.View = new CryptoEditorTodoView(this);
            this.Detail = new CryptoEditorTodoDetails(this);
        }

        public override object CreateItem()
        {
            //
            // A new form must be implemented by the user to get item details ...
            //
            CryptoEditorTodoItem item = new CryptoEditorTodoItem("", 2, DateTime.Now, 0, "");
            CryptoEditorTodoForm form = new CryptoEditorTodoForm(item);
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorTodoItem item = (CryptoEditorTodoItem)itemIn;
            CryptoEditorTodoForm form = new CryptoEditorTodoForm(item);
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
