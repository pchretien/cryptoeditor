using System;
using System.Xml.Serialization;
using com.CryptoTools;
using CryptoEditor.Common;

namespace CryptoEditor.Common
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

        private int verticalSplitter = 180;
        private int horizontalSplitter = 190;
        private int width = 640;
        private int height = 480;
        private int idleTimeout = 1;
        private bool skipSyncWarning = false;

        private bool useProxy = false;
        private string proxyAddress = "";
        private int proxyPort = 8080;
        private bool useAuthentication = false;
        private string proxyUser = "";
        private string proxyPassword = "";
        private string encryptedProxyPassword = "";
        private string proxyDomain = "";

        public static readonly string keyPrefix = "_ce_";

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

            CryptoEditorUtils.CheckApplicationDataFolder();

            encryptedPassword = CryptoEditorEncryption.Hash(password);
            encryptedKey = CryptoEditorEncryption.Encrypt(keyPrefix + key, password);
            encryptedProxyPassword = CryptoEditorEncryption.Encrypt(proxyPassword, password);
            
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\CryptoEditor\" + id + ".profile";
            System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            XmlSerializer serializer = new XmlSerializer( typeof(CryptoEditorProfile) );
            serializer.Serialize( stream, this );
            stream.Close();
        }

        public void Load( string fileName )
        {
            CryptoEditorUtils.CheckApplicationDataFolder();

            System.IO.FileStream stream = new System.IO.FileStream(fileName , System.IO.FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CryptoEditorProfile));
            CryptoEditorProfile profile = (CryptoEditorProfile)serializer.Deserialize(stream);
            stream.Close();

            name = profile.Name;
            email = profile.Email;
            encryptedPassword = profile.EncryptedPassword;
            encryptedKey = profile.EncryptedKey;

            verticalSplitter = profile.VerticalSplitter;
            horizontalSplitter = profile.HorizontalSplitter;
            width = profile.Width;
            height = profile.Height;
            id = profile.Id;
            skipSyncWarning = profile.SkipSyncWarning;

            idleTimeout = profile.IdleTimeout;

            useProxy = profile.UseProxy;
            proxyAddress = profile.ProxyAddress;
            proxyPort = profile.ProxyPort;
            
            useAuthentication = profile.UseAuthentication;
            proxyUser = profile.ProxyUser;
            proxyDomain = profile.ProxyDomain;

            encryptedProxyPassword = profile.EncryptedProxyPassword;
        }

        public void DecryptLicense()
        {
            if (passwordValidated)
            {
                key = CryptoEditorEncryption.Decrypt(encryptedKey, password);
                if (key.Length > keyPrefix.Length)
                    key = key.Substring(keyPrefix.Length);

                proxyPassword = CryptoEditorEncryption.Decrypt(encryptedProxyPassword, password);
            }
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

        public bool SkipSyncWarning
        {
            get { return skipSyncWarning; }
            set { skipSyncWarning = value; }
        }

        public string ProxyAddress
        {
            get { return proxyAddress; }
            set { proxyAddress = value; }
        }

        public int ProxyPort
        {
            get { return proxyPort; }
            set { proxyPort = value; }
        }

        public string ProxyUser
        {
            get { return proxyUser; }
            set { proxyUser = value; }
        }

        [XmlIgnore]
        public string ProxyPassword
        {
            get { return proxyPassword; }
            set { proxyPassword = value; }
        }

        public bool UseProxy
        {
            get { return useProxy; }
            set { useProxy = value; }
        }

        public bool UseAuthentication
        {
            get { return useAuthentication; }
            set { useAuthentication = value; }
        }

        public string ProxyDomain
        {
            get { return proxyDomain; }
            set { proxyDomain = value; }
        }

        public string EncryptedProxyPassword
        {
            get { return encryptedProxyPassword; }
            set { encryptedProxyPassword = value; }
        }
    }
}