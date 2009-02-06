using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoEditorService
{
    public interface ICryptoEditorServiceDaoInterface
    {
        int LicenseExist(string email, string license);
        int ProfileExist(string email);
        int GetStatus(string email, ref int status, ref string license, ref DateTime expiration);
        int GetEncryptedLicense(string email, ref string encryptedLicense);
        int UpdateEncryptedKey(string email, string license, string encryptedLicense);
        int Confirm(string email, string license, string encryptedLicense, ref string fullname, ref string profile);
        int Register(string email, string profile, string fullName, ref string license);
        int Save(string email, string license, string plugin, string xml);
        int Load(string email, string license, string plugin, ref string data);
    }
}
