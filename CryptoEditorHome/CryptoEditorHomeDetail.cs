using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorHome
{
    public partial class CryptoEditorHomeDetail : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;

        private bool connected = false;
        private string loading = "";
        private string offline = "";

        private readonly string landing = "http://sites.google.com/a/cryptoeditor.com/news/";

        public CryptoEditorHomeDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;

            InitializeComponent();

#if DEBUG_SERVER
            landing = "http://localhost:8080/news?base=2";
#endif

#if !MONO_MWF
            string location = Assembly.GetCallingAssembly().CodeBase;
            loading = location.ToLower().Replace("cryptoeditorhome.dll", "loader.htm");
            offline = location.ToLower().Replace("cryptoeditorhome.dll", "offline.htm");

            webConnectTimer.Enabled = true;
#endif
        }

        private void TestConnection()
        {
            try
            {
                if(!connected)
                    webBrowser.Navigate(loading);
                
                if(!connected)
                {
                    connected = true;
                    webBrowser.Navigate(landing);
                }

            }
            catch(Exception)
            {
                connected = false;
                webBrowser.Navigate(offline);
            }
        }

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayItem(object item)
        {
            BringToFront();
        }

        private void webConnectTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                webConnectTimer.Stop();
                TestConnection();
            }
            finally
            {
                webConnectTimer.Interval = 60000;
                webConnectTimer.Start();
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.Url.Host.ToLower().Equals("cryptoeditor.appspot.com"))
            {
                if (!webBrowser.DocumentTitle.ToLower().Contains("cryptoeditor"))
                {
                    connected = false;
                    webBrowser.Navigate(offline);
                }
            }
        }
    }
}
