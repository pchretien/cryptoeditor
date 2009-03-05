using System;
using System.IO;
using System.Windows.Forms;
using CryptoEditor.Common;

namespace CryptoEditor
{
    public partial class CryptoEditorProfileManagerForm : Form
    {
        private string selectedProfile = null;
        private string selectedProfileFile = null;

        public CryptoEditorProfileManagerForm()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            CryptoEditorProfileForm form = new CryptoEditorProfileForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CryptoEditorProfile newProfile = new CryptoEditorProfile(
                    form.ProfileName,
                    form.EmailAddress,
                    form.Password );

                newProfile.Save();

                LoadProfiles();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (profilesListView.SelectedItems.Count == 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete the profile " + profilesListView.SelectedItems[0].Text + " and all the data is contains?", "Delete Profile", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete the profile from the list ...
                if (profilesListView.SelectedItems.Count > 0)
                {
                    CryptoEditorProfile tmpProfile = new CryptoEditorProfile();
                    tmpProfile.Load(SelectedProfileFile);
                    tmpProfile.PasswordValidated = false;

                    CryptoEditorPasswordForm formPassword = new CryptoEditorPasswordForm();
                    while (formPassword.ShowDialog() == DialogResult.OK)
                    {
                        string tmpPassword = CryptoEditorEncryption.Hash(formPassword.Password);
                        if (tmpPassword.Equals(tmpProfile.EncryptedPassword))
                        {
                            string toDelete = tmpProfile.Id + "*.*";
                            string[] filesToDelete = Directory.GetFiles(Directory.GetCurrentDirectory(), toDelete);
                            foreach(string file in filesToDelete)
                            {
                                System.IO.File.Delete(file);
                            }
                            LoadProfiles();

                            break;
                        }

                        MessageBox.Show("The password is incorrect! Please retype your password.", "Incorrect password",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        formPassword.Password = "";
                    }
                }
            }

            profilesListView.Select();
        }

        private void open_Click(object sender, EventArgs e)
        {
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CryptoEditorProfileManagerForm_Load(object sender, EventArgs e)
        {
            LoadProfiles();

            if (profilesListView.SelectedItems.Count > 0)
                profilesListView.Items[0].Selected = true;
        }

        private void LoadProfiles()
        {
            profilesListView.Items.Clear();

            string[] files = System.IO.Directory.GetFiles(".", "*.profile");
            foreach (string file in files)
            {
                CryptoEditorProfile profile = new CryptoEditorProfile();
                profile.Load(file);

                ListViewItem item = profilesListView.Items.Add(profile.Name);
                item.Tag = file;

                item.SubItems.Add(profile.Email);
            }

            open.Enabled = false;
            delete.Enabled = false;
        }

        public string SelectedProfile
        {
            get
            {
                return selectedProfile;
            }
        }

        public string SelectedProfileFile
        {
            get
            {
                return selectedProfileFile;
            }
        }

        private void profilesListView_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void profilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(profilesListView.SelectedItems.Count > 0 )
            {
                open.Enabled = true;
                delete.Enabled = true;

                selectedProfile = profilesListView.SelectedItems[0].Text;
                selectedProfileFile = Convert.ToString(profilesListView.SelectedItems[0].Tag);
            }
            else
            {
                open.Enabled = false;
                delete.Enabled = false;
            }
        }
    }
}