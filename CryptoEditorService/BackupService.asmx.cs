using System;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Services;
using System.Data.SqlClient;

namespace CryptoEditorService
{
    public enum CryptoEditorServiceCodes
    {
        SUCCESS = 0,
        USER_EXIST = 1,
        USER_DOES_NOT_EXIST = 2,
        USER_DISABLED = 3,
        USER_EXPIRED = 4,
        INVALID_LICENSE = 5,
        SYSTEM_ERROR = 100
    };

    /// <summary>
    /// Summary description for BackupService
    /// </summary>
    [WebService(Namespace = "http://cryptoeditor.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class BackupService : WebService
    {
        [WebMethod]
        public CryptoEditorServiceCodes IsLicenseValid(string email, string userLicense)
        {
            int status = 0;
            string localLicense = "";
            DateTime expiration = DateTime.MinValue;
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();

            if (dao.GetStatus(email, ref status, ref localLicense, ref expiration) > 0)
            {
                if (!localLicense.Equals(userLicense))
                    return CryptoEditorServiceCodes.INVALID_LICENSE;

                if (expiration.CompareTo(DateTime.Now) < 0)
                    return CryptoEditorServiceCodes.USER_EXPIRED;

                if (status == 0)
                    return CryptoEditorServiceCodes.USER_DISABLED;

                return CryptoEditorServiceCodes.SUCCESS;
            }

            return CryptoEditorServiceCodes.USER_DOES_NOT_EXIST;
        }

        [WebMethod]
        public string GetEncryptedLicense(string email)
        {
            string encryptedLicense = "";
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();
            dao.GetEncryptedLicense(email, ref encryptedLicense);
            return encryptedLicense;
        }

        [WebMethod]
        public CryptoEditorServiceCodes UpdateKey(string email, string license, string encryptedLicense)
        {
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();
            if (dao.LicenseExist(email, license) == 0)
                return CryptoEditorServiceCodes.USER_DOES_NOT_EXIST;
            
            if( dao.UpdateEncryptedKey(email, license, encryptedLicense) > 0 )
                return CryptoEditorServiceCodes.SUCCESS;

            return CryptoEditorServiceCodes.SYSTEM_ERROR;
        }

        [WebMethod]
        public CryptoEditorServiceCodes Confirm(string email, string license, string encryptedLicense)
        {
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();

            if (dao.LicenseExist(email, license) == 0)
                return CryptoEditorServiceCodes.USER_DOES_NOT_EXIST;

            string fullName = "";
            string profile = "";
            if(dao.Confirm(email, license, encryptedLicense, ref fullName, ref profile) == 0)
                return CryptoEditorServiceCodes.SYSTEM_ERROR;

            
            // Send a confirmation email to the user ...
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = false;
            msg.From = new MailAddress(ConfigurationManager.AppSettings["SmtpSenderAddress"], "CryptoEditor Registration");
            msg.To.Add(email);
            msg.Bcc.Add(ConfigurationManager.AppSettings["SmtpBcc"]);
            msg.Subject = "CryptoEditor Subscription Confirmation";

            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Hi " + fullName + ",\n\nWelcome to the CryptoEditor community!";
            msg.Body += "\n\nYour email: " + email;
            msg.Body += "\nYour CryptoEditor profile: " + profile;
            msg.Body += "\n\nBest regards,\n\nCryptoEditor Team\nsupport@cryptoeditor.com\nhttp://www.cryptoeditor.com\n";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
            smtp.Send(msg);

            return CryptoEditorServiceCodes.SUCCESS;
        }

        [WebMethod]
        public CryptoEditorServiceCodes Register(string email, string profile, string fullName)
        {
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();

            if(dao.ProfileExist(email) > 0)
                return CryptoEditorServiceCodes.USER_EXIST;

            string license = "";
            if (dao.Register(email, profile, fullName, ref license) == 0)
                return CryptoEditorServiceCodes.SYSTEM_ERROR;
            
            // Send an email to the user ...
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = false;
            msg.From = new MailAddress(ConfigurationManager.AppSettings["SmtpSenderAddress"], "CryptoEditor Registration");
            msg.To.Add(email);
            msg.Bcc.Add(ConfigurationManager.AppSettings["SmtpBcc"]);
            msg.Subject = "CryptoEditor Subscription";

            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Hi " + fullName + ",";
            msg.Body += "\n\nYour email: " + email;
            msg.Body += "\nYour CryptoEditor profile: " + profile;
            msg.Body += "\n\nThis is your personnal CryptoEditor license key: " + license;
            msg.Body += "\nCopy this license key into the registration form of the CryptoEditor program to activate the web Synchronization.";
            msg.Body += "\n\nBest regards,\n\nCryptoEditor Team\nsupport@cryptoeditor.com\nhttp://www.cryptoeditor.com\n";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
            smtp.Send(msg);

            return CryptoEditorServiceCodes.SUCCESS;
        }
        
        [WebMethod]
        public CryptoEditorServiceCodes Save(string email, string license, string plugin, string xml)
        {
            int status = 0;
            string localLicense = "";
            DateTime expiration = DateTime.MinValue;
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();

            if (dao.GetStatus(email, ref status, ref localLicense, ref expiration) == 0)
                return CryptoEditorServiceCodes.USER_DOES_NOT_EXIST;
            if (!localLicense.Equals(license))
                return CryptoEditorServiceCodes.INVALID_LICENSE;

            if (expiration.CompareTo(DateTime.Now) < 0)
                return CryptoEditorServiceCodes.USER_EXPIRED;

            if (status == 0)
                return CryptoEditorServiceCodes.USER_DISABLED;

            if (dao.Save(email, license, plugin, xml) == 0)
                return CryptoEditorServiceCodes.SYSTEM_ERROR;

            return CryptoEditorServiceCodes.SUCCESS;
        }

        [WebMethod]
        public string Load(string email, string license, string plugin)
        {
            ICryptoEditorServiceDaoInterface dao = CryptoEditorServiceDaoFactory.GetDao();
            if(dao.LicenseExist(email, license) == 0)
                return "";

            string data = "";
            dao.Load(email, license, plugin, ref data);

            return data;
        }
    }
}