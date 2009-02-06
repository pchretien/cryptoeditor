using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CryptoEditor.Password
{
    [Serializable]
    public class CryptoPasswordProperties
    {
        private bool showPasswords = false;
        private string fileName = "";

        public bool ShowPasswords
        {
            get { return showPasswords; }
            set { showPasswords = value; }
        }

        public void Load(string filename)
        {
            this.fileName = filename;

            try
            {
                System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof (CryptoPasswordProperties));
                CryptoPasswordProperties properties = (CryptoPasswordProperties) serializer.Deserialize(stream);
                stream.Close();

                showPasswords = properties.ShowPasswords;
            }
            catch(Exception)
            {
            }
        }

        public void Save()
        {
            System.IO.FileStream stream = new System.IO.FileStream(this.fileName, System.IO.FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(CryptoPasswordProperties));
            serializer.Serialize(stream, this);
            stream.Close();
        }
    }
}
