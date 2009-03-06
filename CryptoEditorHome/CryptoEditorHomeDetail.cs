using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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
        private readonly string landing = "http://www.cryptoeditor.com";

        public CryptoEditorHomeDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;
            InitializeComponent();

#if !MONO_MWF
            string location = Assembly.GetCallingAssembly().CodeBase;
            loading = location.ToLower().Replace("cryptoeditorhome.dll", "loader.htm");
            offline = location.ToLower().Replace("cryptoeditorhome.dll", "offline.htm");

            webConnectTimer.Enabled = true;
#endif
        }

        private void TestConnection()
        {
            System.Net.WebResponse ret = null;
            string ping = "http://www.cryptoeditor.com/ping.html";
            System.Net.WebRequest request = System.Net.WebRequest.Create(ping);

            try
            {
                if(!connected)
                    webBrowser.Navigate(loading);
                
                ret = request.GetResponse();
                ret.Close();
                
                if(!connected)
                {
                    connected = true;
                    webBrowser.Navigate(landing);
                }

            }
            catch(Exception)
            {
                if (ret != null)
                    ret.Close();

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
    }
}
