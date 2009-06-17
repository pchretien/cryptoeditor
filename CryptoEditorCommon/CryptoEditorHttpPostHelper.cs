using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace CryptoEditor.Common
{
    /// <summary>
    /// This class wraps the code required to call web pages with the POST method. 
    /// </summary>
    public class HttpPostParameter
    {
        private string name;
        private string value;

        public HttpPostParameter(string name, string value)
        {
            this.name = HttpUtility.UrlEncode(name);
            this.value = HttpUtility.UrlEncode(value);
        }

        public string Name
        {
            get { return name; }
            set { name = HttpUtility.UrlEncode(value); }
        }

        public string Value
        {
            get { return value; }
            set { this.value = HttpUtility.UrlEncode(value); }
        }
    }
    public class CryptoEditorHttpPostHelper
    {
    	private string url = "http://cryptoeditor.appspot.com";
        private string contentType = "";
        private ArrayList parameters = new ArrayList();

        public CryptoEditorHttpPostHelper(string url, string contentType)
        {
            this.url = url;
            this.contentType = contentType;
        }
        
        public void AddParameter(string name, string value)
        {
            HttpPostParameter parameter = new HttpPostParameter(name, value);
            parameters.Add(parameter);
        }

        public string Send()
        {
            string queryString = "";
            for(int i=0; i<parameters.Count; i++)
            {
                string name = ((HttpPostParameter) parameters[i]).Name;
                string value = ((HttpPostParameter) parameters[i]).Value;
                queryString += (i > 0) ? "&" : "";
                queryString += name;
                queryString += "=";
                queryString += value;
            }

            WebRequest request = WebRequest.Create(url);
            request.ContentType = contentType;
            request.Method = "POST";

            Stream os = null;
            byte[] bytes = Encoding.ASCII.GetBytes(queryString);
            
            try
            {
                request.ContentLength = bytes.Length;
                os = request.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
            }
            catch (WebException ex)
            {
                throw;
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { 
                WebResponse webResponse = request.GetResponse();
                if (webResponse == null)
                    return "";

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                return response;
            }
            catch (WebException ex)
            {
                throw;
            }
        }
    }

    public class HttpServiceClient
    {
#if DEBUG
        private static string serviceAddress = "http://localhost:8080/";
#else
        private static string serviceAddress = "http://cryptoeditor.appspot.com/";
#endif

        public static bool GetProfile(string email, ref int status, ref DateTime expiration, ref string encrypted_license)
        {
            try
            {
                CryptoEditor.Common.CryptoEditorHttpPostHelper post =
                    new CryptoEditorHttpPostHelper(serviceAddress+"getprofile",
                                                   "application/x-www-form-urlencoded");
                post.AddParameter("email", email);
                string profileXml = post.Send();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(profileXml);

                XmlNodeList nodes = xml.GetElementsByTagName("error");
                if (nodes != null && nodes.Count > 0)
                {
                    // USER_DOES_NOT_EXIST
                    string error = nodes[0].InnerText;
                    if (error.Equals("USER_DOES_NOT_EXIST"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("This installation of CryptoEditor is not registered. Visit our website to get your FREE registration key", "Installation not registered");
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show("Unknown error (GetProfile)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                nodes = xml.GetElementsByTagName("status");
                status = (nodes[0].InnerText != null && nodes[0].InnerText.Length>0)?Convert.ToInt32(nodes[0].InnerText):0;

                nodes = xml.GetElementsByTagName("expiration");
                expiration = (nodes[0].InnerText != null && nodes[0].InnerText.Length>0)?DateTime.Parse(nodes[0].InnerText):new DateTime(1970,1,1);

                nodes = xml.GetElementsByTagName("encrypted_license");
                encrypted_license = (nodes[0].InnerText != null && nodes[0].InnerText.Length>0)?nodes[0].InnerText:"";

                return true;
            }
            catch(WebException)
            {
                MessageBox.Show("An error occured while contacting the server", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Server error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public static bool PutLicense(string email, string license, string encrypted_license, bool sendmail)
        {
            try
            {
                CryptoEditor.Common.CryptoEditorHttpPostHelper post =
                    new CryptoEditorHttpPostHelper(serviceAddress + "putlicense",
                                                   "application/x-www-form-urlencoded");
                post.AddParameter("email", email);
                post.AddParameter("license", license);
                post.AddParameter("encrypted_license", encrypted_license);
                post.AddParameter("sendmail", (sendmail)?"yes":"no");

                string profileXml = post.Send();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(profileXml);

                XmlNodeList nodes = xml.GetElementsByTagName("error");
                if (nodes != null && nodes.Count > 0)
                {
                    // USER_DOES_NOT_EXIST
                    string error = nodes[0].InnerText;
                    if (error.Equals("USER_DOES_NOT_EXIST"))
                        MessageBox.Show("Invalid email or registration key", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (error.Equals("INVALID_PASSWORD"))
                        MessageBox.Show("This account already exist and the password does not match your current password.\n\rGo to 'Users/Change Password' to set the correct password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("Unknown error (PutLicense)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                return true;
            }
            catch (WebException)
            {
                MessageBox.Show("An error occured while contacting the server", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Server error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public static bool Load(string email, string license, string plugin, ref string webData)
        {
            try
            {
                webData = "";
                CryptoEditor.Common.CryptoEditorHttpPostHelper post =
                    new CryptoEditorHttpPostHelper(serviceAddress + "load",
                                                   "application/x-www-form-urlencoded");
                post.AddParameter("email", email);
                post.AddParameter("license", license);
                post.AddParameter("plugin", plugin);

                webData = post.Send();
                if (webData == null || webData.Length == 0)
                    return true;

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(webData);

                XmlNodeList nodes = xml.GetElementsByTagName("error");
                if (nodes != null && nodes.Count > 0)
                {
                    // USER_DOES_NOT_EXIST
                    // USER_NOT_ACTIVATED
                    // USER_EXPIRED
                    string error = nodes[0].InnerText;
                    if (error.Equals("USER_DOES_NOT_EXIST"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("This installation of CryptoEditor is not registered. Visit our website to get your FREE registration key", "Installation not registered");
                        form.ShowDialog();
                    }
                    if (error.Equals("USER_NOT_ACTIVATED"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your account is not activated. Visit our website to get your FREE registration key", "Account not activated");
                        form.ShowDialog();
                    }
                    if (error.Equals("USER_EXPIRED"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your registration has expired. Visit our website to add more time to your subscription", "Account expired");
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show("Unknown error (PutLicense)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                return true;
            }
            catch (WebException)
            {
                MessageBox.Show("An error occured while contacting the server", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Server error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public static bool Save(string email, string license, string plugin, string data)
        {
            try
            {
                CryptoEditor.Common.CryptoEditorHttpPostHelper post =
                    new CryptoEditorHttpPostHelper(serviceAddress + "save",
                                                   "application/x-www-form-urlencoded");
                post.AddParameter("email", email);
                post.AddParameter("license", license);
                post.AddParameter("plugin", plugin);
                post.AddParameter("data", data);

                string profileXml = post.Send();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(profileXml);

                XmlNodeList nodes = xml.GetElementsByTagName("error");
                if (nodes != null && nodes.Count > 0)
                {
                    // USER_DOES_NOT_EXIST
                    // USER_NOT_ACTIVATED
                    // USER_EXPIRED
                    string error = nodes[0].InnerText;
                    if (error.Equals("USER_DOES_NOT_EXIST"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("This installation of CryptoEditor is not registered. Visit our website to get your FREE registration key", "Installation not registered");
                        form.ShowDialog();
                    }
                    if (error.Equals("USER_NOT_ACTIVATED"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your account is not activated. Visit our website to get your FREE registration key", "Account not activated");
                        form.ShowDialog();
                    }
                    if (error.Equals("USER_EXPIRED"))
                    {
                        CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your registration has expired. Visit our website to add more time to your subscription", "Account expired");
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show("Unknown error (PutLicense)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                return true;
            }
            catch (WebException)
            {
                MessageBox.Show("An error occured while contacting the server", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Server error!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
