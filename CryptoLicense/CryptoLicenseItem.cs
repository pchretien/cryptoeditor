using System;
using CryptoEditor.Framework;

namespace CryptoEditor.License
{
    [Serializable]
    public class CryptoLicenseItem : CryptoEditorPluginItem
    {
        private string company="";
        private string productName = "";
        private string productWebsite = "";
        private string licenseKeyEmail = "";
        private string licenseKeyUser = "";
        private string licenseKeyUser2 = "";
        private string licenseKey = "";
        private string notes = "";

        [CryptoEditorPluginItem(1, Header = "Company", Width = 150, Searchable = true)]
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        [CryptoEditorPluginItem(0, Header = "Product Name", Width = 150, Searchable = true)]
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string ProductWebsite
        {
            get { return productWebsite; }
            set { productWebsite = value; }
        }

        [CryptoEditorPluginItem(2, Header = "Email", Width = 150, Searchable = true)]
        public string LicenseKeyEmail
        {
            get { return licenseKeyEmail; }
            set { licenseKeyEmail = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string LicenseKeyUser
        {
            get { return licenseKeyUser; }
            set { licenseKeyUser = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string LicenseKeyUser2
        {
            get { return licenseKeyUser2; }
            set { licenseKeyUser2 = value; }
        }

        [CryptoEditorPluginItem(3, Header = "License Key", Width = 200)]
        public string LicenseKey
        {
            get { return licenseKey; }
            set { licenseKey = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string Notes
        {
            get
            {
                if (!Sarializing)
                    return notes;

                // Note: This could be a function in the framework
                string ret = notes.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Sarializing)
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
