using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.Common
{
    public partial class CryptoEditorGoToWebForm : Form
    {
        public CryptoEditorGoToWebForm(string message, string caption)
        {
            InitializeComponent();

            this.Text = caption;
            this.messageTextBox.Text = message;
        }

        private void haveAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void haveAccountButton_Click(object sender, EventArgs e)
        {
#if DEBUG_SERVER
            string linkText = "http://localhost:8080/login";
#else
            string linkText = "https://cryptoeditor.appspot.com/login";
#endif

            System.Diagnostics.Process.Start(linkText);

            Close();
        }

        private void dontHaveAccountButton_Click(object sender, EventArgs e)
        {
#if DEBUG_SERVER
            string linkText = "http://localhost:8080/register";
#else
            string linkText = "https://cryptoeditor.appspot.com/register";
#endif

            System.Diagnostics.Process.Start(linkText);

            Close();
        }
    }
}