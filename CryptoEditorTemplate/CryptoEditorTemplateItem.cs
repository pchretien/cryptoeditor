using System;
using System.Xml.Serialization;
using CryptoEditor.Common;
using CryptoEditor.Framework;

namespace CryptoEditor.Template
{
    [Serializable]
    public class CryptoEditorTemplateItem : CryptoEditorPluginItem
    {
        public CryptoEditorTemplateItem()
        {
        }

        public CryptoEditorTemplateItem(string name, string email)
        {
            Name = name;
            Email = email;
        }

        private string name = "";
        [CryptoEditorPluginItem(0)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email = "";
        [CryptoEditorPluginItem(1, Header="Email address", Width=400)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
