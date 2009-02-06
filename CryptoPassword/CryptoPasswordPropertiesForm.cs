using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoEditor.Password
{
    public partial class CryptoPasswordPropertiesForm : Form
    {
        private CryptoPasswordProperties properties = null;

        public CryptoPasswordPropertiesForm(CryptoPasswordProperties properties)
        {
            InitializeComponent();

            this.properties = properties;
            showPasswordCheckBox.Checked = properties.ShowPasswords;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            properties.ShowPasswords = showPasswordCheckBox.Checked;
        }
    }
}