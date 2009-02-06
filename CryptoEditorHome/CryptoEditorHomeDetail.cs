using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorHome
{
    public partial class CryptoEditorHomeDetail : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private readonly string landing = "http://cryptoeditor.com.dnnmax.com/Default.aspx?tabid=131";

        private string loading = "";
        private string offline = "";

        public CryptoEditorHomeDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;
            InitializeComponent();

#if !MONO_MWF
            string location = Assembly.GetCallingAssembly().CodeBase;
            loading = location.ToLower().Replace("cryptoeditorhome.dll", "loader.htm");
            offline = location.ToLower().Replace("cryptoeditorhome.dll", "offline.htm");
            webBrowser.Url = new Uri(loading);
            webBrowserBuffer.Url = new Uri(landing);
#endif

        }

        #region ICryptoEditorDetail Members

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayItem(object item)
        {
            BringToFront();
        }

        #endregion

        private void webBrowserBuffer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
#if !MONO_MWF
            if(webBrowserBuffer.DocumentTitle.ToLower().IndexOf("canceled") == -1)
                webBrowser.Url = new Uri(landing);
            else
                webBrowser.Url = new Uri(offline);
#endif
        }
    }
}
