using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Template
{
    public partial class CryptoEditorTemplateDetail : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorTemplateItem item = null;

        public CryptoEditorTemplateDetail(ICryptoEditor plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        #region ICryptoEditorDetail Members

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayItem(object o)
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            BringToFront();

            if (o == null)
            {
                nameTextBox.Enabled = false;
                emailTextBox.Enabled = false;
                editButton.Enabled = false;
                return;
            }

            nameTextBox.Enabled = true;
            emailTextBox.Enabled = true;
            editButton.Enabled = true;

            item = (CryptoEditorTemplateItem) o;
            nameTextBox.Text = item.Name;
            emailTextBox.Text = item.Email;
        }

        #endregion

        private void editButton_Click(object sender, EventArgs e)
        {
            plugin.UpdateItem(item);
            plugin.View.DisplayView(null);
            DisplayItem(item);
        }
    }
}
