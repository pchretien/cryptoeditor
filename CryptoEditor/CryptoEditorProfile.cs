using System;
using System.Xml.Serialization;
using com.CryptoTools;
using CryptoEditor.Common;

namespace CryptoEditor
{
    [Serializable]
    public class CryptoEditorProfile
    {       
        private string name = "";
        private string email = "";
        private string password = "";
        private string encryptedPassword = "";
        private bool passwordValidated = false;
        private string key = "";
        private string encryptedKey = "";
        private string id = "";

        private int verticalSplitter = 134;
        private int horizontalSplitter = 190;
        private int width = 600;
        private int height = 450;
        private int idleTimeout = 1;

        public CryptoEditorProfile()
        {
        }

        public CryptoEditorProfile( string name, string email, string password )
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.id = Guid.NewGuid().ToString();
        }

        public void Save()
        {
            // This is only for backward compatibility with previous versions ...
            if (id == null || id.Length == 0)
                id = Guid.NewGuid().ToString();

            encryptedPassword = CryptoEditorEncryption.Hash(password);
            encryptedKey = CryptoEditorEncryption.Encrypt(key, password);

            System.IO.FileStream stream = new System.IO.FileStream(id+".profile", System.IO.FileMode.Create);
            XmlSerializer serializer = new XmlSerializer( typeof(CryptoEditorProfile) );
            serializer.Serialize( stream, this );
            stream.Close();
        }

        public void Load( string fileName )
        {
            System.IO.FileStream stream = new System.IO.FileStream(fileName , System.IO.FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CryptoEditorProfile));
            CryptoEditorProfile profile = (CryptoEditorProfile)serializer.Deserialize(stream);
            stream.Close();

            name = profile.Name;
            email = profile.Email;
            encryptedPassword = profile.EncryptedPassword;
            encryptedKey = profile.EncryptedKey;

            key = CryptoEditorEncryption.Decrypt(encryptedKey, password);

            verticalSplitter = profile.VerticalSplitter;
            horizontalSplitter = profile.HorizontalSplitter;
            width = profile.Width;
            height = profile.Height;
            id = profile.Id;

            idleTimeout = profile.IdleTimeout;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [XmlIgnore]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string EncryptedPassword
        {
            get { return encryptedPassword; }
            set { encryptedPassword = value; }
        }

        [XmlIgnore]
        public bool PasswordValidated
        {
            get { return passwordValidated; }
            set { passwordValidated = value; }
        }

        public int VerticalSplitter
        {
            get { return verticalSplitter; }
            set { verticalSplitter = value; }
        }

        public int HorizontalSplitter
        {
            get { return horizontalSplitter; }
            set { horizontalSplitter = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int IdleTimeout
        {
            get { return idleTimeout; }
            set { idleTimeout = value; }
        }

        [XmlIgnore]
        public string Key
        {
            get
            {
                return key;
            }

            set 
            { 
                key = value;
            }
        }

        public string EncryptedKey
        {
            get { return encryptedKey; }
            set { encryptedKey = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}