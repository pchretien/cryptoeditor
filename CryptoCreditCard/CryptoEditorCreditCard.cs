using System;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.CreditCard
{
    [CryptoEditorPlugin("Credit Card")]
    public class CreditCard : CryptoEditorPlugin<CryptoEditorCreditCardItem>
    {
        public CreditCard()
        {
            //this.Detail = new CryptoEditorCreditCardDetail(this);
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
            CryptoEditorCreditCardItem item = new CryptoEditorCreditCardItem(
                "",
                "",
                "",
                "",
                "",
                DateTime.Today.Month.ToString(),
                DateTime.Today.AddYears(1).Year.ToString());

            CryptoEditorCreditCardForm form = new CryptoEditorCreditCardForm(item);
            if (form.ShowDialog() == DialogResult.Cancel)
                return null;

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorCreditCardItem item = (CryptoEditorCreditCardItem)itemIn;
            CryptoEditorCreditCardForm form = new CryptoEditorCreditCardForm(item);
            if (form.ShowDialog() == DialogResult.Cancel)
                return item;

            base.UpdateItem(item);
            return item;
        }
    }
}
