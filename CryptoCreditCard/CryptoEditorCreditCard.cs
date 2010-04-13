using System;
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
                "Master Card",
                "Philippe Chretien",
                "9151-0784 Québec Inc.",
                "1234 5678 9012 3456",
                new Random(DateTime.Now.Millisecond).Next(999).ToString(),
                "01",
                "2011");

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoEditorCreditCardItem item = (CryptoEditorCreditCardItem)itemIn;
            item.Security = new Random(DateTime.Now.Millisecond).Next(999).ToString();

            base.UpdateItem(item);
            return item;
        }
    }
}
