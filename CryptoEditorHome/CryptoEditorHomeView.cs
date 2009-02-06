using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;
using System.Reflection;

namespace CryptoEditorHome
{
    public partial class CryptoEditorHomeView : UserControl, ICryptoEditorView
    {
        private ICryptoEditor plugin = null;

        public CryptoEditorHomeView(ICryptoEditor plugin)
        {
            this.plugin = plugin;
            InitializeComponent();
        }

        #region ICryptoEditorView Members

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayView(object doc)
        {
            BringToFront();
            Plugin.Detail.DisplayItem(null);
        }

        public void ClearCut(bool isCut)
        {
        }

        #endregion
    }
}
