using System;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoEditor
{
    public partial class CryptoEditorPasswordValidation : Form
    {
        

        public CryptoEditorPasswordValidation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = CryptoEditorUtils.ValidatePassword(NewPassword1.Text);
            NewPassword2.ReadOnly = !(NewPassword1.Text.Length > 0);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void CryptoEditorPasswordValidation_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
        }

        private void password2_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = NewPassword1.Text.Equals(NewPassword2.Text);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}