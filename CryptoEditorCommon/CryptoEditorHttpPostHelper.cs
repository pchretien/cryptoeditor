using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

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
    	private int iii = 0;
        private string url = "http://www.cryptoeditor.com";
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
}
