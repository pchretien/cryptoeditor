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
            string expYear,
            string notes)
        {
            Type = type;
            Name = name;
            Company = company;
            Number = number;
            Security = security;
            ExpMonth = expMonth;
            ExpYear = expYear;
            Notes = notes;
        }

        private string type = "";
        [CryptoEditorPluginItem(0, Width = 100, Header = "Card")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        private string name = "";
        [CryptoEditorPluginItem(2, Width = 100, Header = "Card Holder")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string name2 = "";
        [CryptoEditorPluginItem(Width = 100, Header = "Second Card Holder")]
        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }

        private string company = "";
        [CryptoEditorPluginItem(1, Width = 100, Header = "Card Company")]
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        private string number = "";
        [CryptoEditorPluginItem(Header="Card Number")]
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string security = "";
        [CryptoEditorPluginItem(Header="Verification Number")]
        public string Security
        {
            get { return security; }
            set { security = value; }
        }

        private string expMonth = "";
        [CryptoEditorPluginItem(3, Header = "Exp. Month", Width = 75)]
        public string ExpMonth
        {
            get { return expMonth; }
            set { expMonth = value; }
        }
        
        private string expYear = "";
        [CryptoEditorPluginItem(4, Header = "Exp. Year", Width = 75)]
        public string ExpYear
        {
            get { return expYear; }
            set { expYear = value; }
        }

        private string notes = "";
        [CryptoEditorPluginItem(Header = "Notes", Width = 100)]
        public string Notes
        {
            get
            {
                if (!Serializing)
                    return notes;

                // Note: This could be a function in the framework
                string ret = notes.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Serializing)
                {
                    notes = value;
                    return;
                }

                // Note: This could be a function in the framework
                string input = value.Replace("{{N}}", "\n");
                input = input.Replace("{{R}}", "\r");

                notes = input;
            }
        }
    }
}
