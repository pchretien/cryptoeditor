using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor
{
    public partial class CryptoEditorRegistration : Form
    {
        public CryptoEditorRegistration()
        {
            InitializeComponent();
        }

        private void linkCryptoEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void CryptoEditorRegistration_Load(object sender, EventArgs e)
        {
#if DEBUG_SERVER
            string linkText = "http://localhost:8080";
#else
            string linkText = "http://cryptoeditor.appspot.com";
#endif
            linkCryptoEditor.Links.Add(0, linkText.Length, linkText);
        }
    }
}