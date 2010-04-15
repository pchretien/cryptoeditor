using System;
using CryptoEditor.Common;

namespace CryptoEditor.CreditCard
{
    [Serializable]
    public class CryptoEditorCreditCardItem : CryptoEditorPluginItem
    {
        public CryptoEditorCreditCardItem()
        {
        }

        public CryptoEditorCreditCardItem(string type,
            string name,
            string company,
            string number,
            string security,
            string expMonth,
            string expYear)
        {
            Type = type;
            Name = name;
            Company = company;
            Number = number;
            Security = security;
            ExpMonth = expMonth;
            ExpYear = expYear;
        }

        private string type = "";
        [CryptoEditorPluginItem(0, Width = 100, Header = "Card Type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        private string name = "";
        [CryptoEditorPluginItem(1, Width = 100, Header = "Card Holder")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string company = "";
        [CryptoEditorPluginItem(2, Width = 150, Header = "Company Name")]
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        private string number = "";
        [CryptoEditorPluginItem]
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string security = "";
        [CryptoEditorPluginItem]
        public string Security
        {
            get { return security; }
            set { security = value; }
        }

        private string expMonth = "";
        [CryptoEditorPluginItem(3, Header = "MM", Width = 50)]
        public string ExpMonth
        {
            get { return expMonth; }
            set { expMonth = value; }
        }
        
        private string expYear = "";
        [CryptoEditorPluginItem(4, Header = "YYYY", Width = 75)]
        public string ExpYear
        {
            get { return expYear; }
            set { expYear = value; }
        }

        private string notes = "";
        [CryptoEditorPluginItem(Header = "Notes", Width = 100)]
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
