using System;
using System.Windows.Forms;

namespace CryptoEditor
{
    public partial class CryptoEditorPasswordForm : Form
    {
        public CryptoEditorPasswordForm()
        {
            InitializeComponent();
        }

        public string Password
        {
            get { return password.Text; }
            set { password.Text = value; }
        }

        private void CryptoEditorPasswordForm_Load(object sender, EventArgs e)
        {
        }
    }
}