using System;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoEditor
{
    public partial class CryptoEditorConnection : Form
    {
        private readonly CryptoEditorProfile profile;

        public CryptoEditorConnection(CryptoEditorProfile profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public CryptoEditorProfile Profile
        {
            get { return profile; }
        }

        private void CryptoEditorConnection_Load(object sender, EventArgs e)
        {
            // Get proxy stuff from the profile ...
            useProxyCheckBox.Checked = Profile.UseProxy;
            proxyAddressTextBox.Text = Profile.ProxyAddress;
            proxyPortTextBox.Text = Profile.ProxyPort.ToString();

            useAuthenticationCheckBox.Checked = Profile.UseAuthentication;
            userNameTextBox.Text = Profile.ProxyUser;
            domainTextBox.Text = profile.ProxyDomain;

            passwordTextBox.Text = Profile.ProxyPassword;

            UpdateEnabled();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            // Save proxy stuff in the profile ...
            profile.UseProxy = useProxyCheckBox.Checked;
            profile.ProxyAddress = proxyAddressTextBox.Text;
            profile.ProxyPort = int.Parse(proxyPortTextBox.Text);
            
            profile.UseAuthentication = useAuthenticationCheckBox.Checked;
            profile.ProxyUser = userNameTextBox.Text;
            profile.ProxyDomain = domainTextBox.Text;

            profile.ProxyPassword = passwordTextBox.Text;
        }

        private void UpdateEnabled()
        {
            if (useProxyCheckBox.Checked)
            {
                proxyAddressTextBox.Enabled = true;
                proxyPortTextBox.Enabled = true;

                useAuthenticationCheckBox.Enabled = true;
                userNameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                domainTextBox.Enabled = true;

                if (useAuthenticationCheckBox.Checked)
                {
                    userNameTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                    domainTextBox.Enabled = true;
                }
                else
                {
                    userNameTextBox.Enabled = false;
                    passwordTextBox.Enabled = false;
                    domainTextBox.Enabled = false;
                }
            }
            else
            {
                proxyAddressTextBox.Enabled = false;
                proxyPortTextBox.Enabled = false;

                useAuthenticationCheckBox.Enabled = false;
                userNameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                domainTextBox.Enabled = false;
            }
        }

        private void useProxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void useAuthenticationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }
    }
}
