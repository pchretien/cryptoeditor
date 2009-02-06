using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoEditor
{
    public partial class CryptoEditorProfileForm : Form
    {
        public CryptoEditorProfileForm()
        {
            InitializeComponent();
        }

        public string ProfileName
        {
            get { return profileName.Text; }
            set { profileName.Text = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress.Text; }
            set { emailAddress.Text = value; }
        }

        public string Password
        {
            get { return password1.Text; }
        }

        private void password1_TextChanged(object sender, System.EventArgs e)
        {
            progressBar1.Value = CryptoEditorUtils.ValidatePassword(password1.Text);
            password2.Enabled = password1.Text.Length > 0;
        }

        private void password2_TextChanged(object sender, System.EventArgs e)
        {
            ok.Enabled = password1.Text.Equals(password2.Text);
        }

        private void CryptoEditorProfileForm_Load(object sender, System.EventArgs e)
        {
            progressBar1.Value = 0;
        }
    }
}
