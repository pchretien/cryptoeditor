using System;
using System.Xml.Serialization;
using CryptoEditor.Framework;

namespace CryptoEditor.Password
{
    [Serializable]
    public class CryptoPasswordItem : CryptoEditorPluginItem
    {
        private string name = "";
        private string username = "";
        private string password = "";
        private string email = "";
        private string url = "";
        private string notes = "";

        public CryptoPasswordItem()
        {
        }

        public CryptoPasswordItem( string nameIn,
            string usernameIn,
            string passwordIn,
            string emailIn,
            string urlIn,
            string notesIn )
        {
            Name = nameIn;
            Username = usernameIn;
            Password = passwordIn;
            Email = emailIn;
            Url = urlIn;
            Notes = notesIn;
        }

        [CryptoEditorPluginItem(0, Width=150, Searchable=true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [CryptoEditorPluginItem(1, Header = "User Name", Width = 150, Searchable = true)]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [CryptoEditorPluginItem(2, Header = "Password", Width = 150, Searchable = true)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [CryptoEditorPluginItem(Searchable=true)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        [CryptoEditorPluginItem(3, Width = 200, Searchable = true)]
        public string Notes
        {
            get
            {
                if(!Sarializing)
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
