using System;
using System.Collections.Generic;
using System.Text;
using com.CryptoTools;

namespace CryptoEditor.Common
{
    public class CryptoEditorEncryption
    {
        public static string Encrypt(string data, string password)
        {
            CryptoTripleDES tdes = new CryptoTripleDES();
            tdes.DeriveKeyFromPassword(password, null, 1000);
            tdes.EncryptTextU(data);

            CryptoBase64 b64 = new CryptoBase64();
            string encryptedData = b64.Encrypt(tdes.Result);

            return encryptedData;
        }

        public static string Decrypt(string data, string password)
        {
            CryptoBase64 b64 = new CryptoBase64();
            b64.Decrypt(data);

            CryptoTripleDES tdes = new CryptoTripleDES();
            tdes.DeriveKeyFromPassword(password, null, 1000);
            string originalData = tdes.DecryptTextU(b64.Result);

            return originalData;
        }

        public static string Hash(string data)
        {
            CryptoMD5 md5 = new CryptoMD5();
            string hash = md5.EncryptTextU(data);

            return hash;
        }
    }
}
