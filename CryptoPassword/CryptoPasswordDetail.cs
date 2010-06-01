using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Password
{
    public partial class CryptoPasswordDetail : UserControl, ICryptoEditorDetail
    {
        private CryptoPasswordItem item = null;

        public CryptoPasswordDetail()
        {
            InitializeComponent();
        }

        private ICryptoEditor plugin = null;

        public CryptoPasswordDetail(ICryptoEditor plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayItem(object itemIn)
        {
            item = (CryptoPasswordItem) itemIn;

            // Clear fields
            nameTextBox.Clear();
            emailTextBox.Clear();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            urlTextBox.Clear();
            notesTextBox.Clear();

            BringToFront();

            if (item == null)
            {
                this.Enabled = false;

                return;
            }
            
            this.Enabled = true;

            // Fill in fields ...
            nameTextBox.Text = item.Name;
            emailTextBox.Text = item.Email;
            usernameTextBox.Text = item.Username;
            passwordTextBox.Text = item.Password;
            urlTextBox.Text = item.Url;
            notesTextBox.Text = item.Notes;
        }

        private void notesTextBox_Validated(object sender, EventArgs e)
        {
            if (!item.Notes.Equals(notesTextBox.Text))
            {
                item.Notes = notesTextBox.Text;
                item.Update();
                plugin.SetChanged();
            }
        }
                
        private void passwordTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);
            passwordTextBox.SelectAll();
        }

        private void usernameTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(usernameTextBox.Text);
            usernameTextBox.SelectAll();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(urlTextBox.Text);
        }
    }
}
