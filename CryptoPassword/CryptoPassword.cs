using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Password
{
    [CryptoEditorPlugin("Passwords")]
    public class CryptoPassword : CryptoEditorPlugin<CryptoPasswordItem>
    {
        private CryptoPasswordProperties properties = null;

        public CryptoPassword()
        {
            rootNode = new CryptoPasswordRootNode(this, Text);
            detail = new CryptoPasswordDetail(this);
            view = new CryptoPasswordView(this);

            properties = new CryptoPasswordProperties();
        }

        public CryptoPasswordProperties Properties
        {
            get { return properties; }
        }

        public override object CreateItem()
        {
            CryptoPasswordEditionForm form = new CryptoPasswordEditionForm();
            if( form.ShowDialog() != DialogResult.OK)
                return null;

            CryptoPasswordItem item = new CryptoPasswordItem( form.nameTextBox.Text,
                form.usernameTextBox.Text,
                form.passwordTextBox.Text,
                form.emailTextBox.Text,
                form.urlTextBox.Text,
                form.notesTextBox.Text );

            base.CreateItem();
            return item;
        }

        public override object UpdateItem(object itemIn)
        {
            CryptoPasswordItem item = (CryptoPasswordItem) itemIn;
            CryptoPasswordEditionForm form = new CryptoPasswordEditionForm();

            form.nameTextBox.Text = item.Name;
            form.usernameTextBox.Text = item.Username;
            form.passwordTextBox.Text = item.Password;
            form.emailTextBox.Text = item.Email;
            form.urlTextBox.Text = item.Url;
            form.notesTextBox.Text = item.Notes;

            if (form.ShowDialog() == DialogResult.OK)
            {
                item.Name = form.nameTextBox.Text;
                item.Username = form.usernameTextBox.Text;
                item.Password = form.passwordTextBox.Text;
                item.Email = form.emailTextBox.Text;
                item.Url = form.urlTextBox.Text;
                item.Notes = form.notesTextBox.Text;
            }

            base.UpdateItem(item);
            return item;
        }

        public override bool HasProperties()
        {
            return true;
        }

        public override void LoadProperties(string filename)
        {
            Properties.Load(filename);
        }

        public override void UpdateProperties(object doc)
        {
            CryptoPasswordPropertiesForm form = new CryptoPasswordPropertiesForm(Properties);
            if(form.ShowDialog() != DialogResult.OK)
                return;

            SaveProperties();
            view.DisplayView(null);
        }

        public override void SaveProperties()
        {
            Properties.Save();
        }

        public override bool IsSearchable()
        {
            return true;
        }
    }
}
