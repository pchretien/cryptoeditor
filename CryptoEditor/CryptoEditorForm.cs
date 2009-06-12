using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;
//using CryptoEditorWeb.CryptoEditorServiceBackup;

namespace CryptoEditor
{
    public partial class CryptoEditorForm : Form
    {
        // TreeView
        private Color previousBackColor = Color.White;

        // Plugins
        private ArrayList plugins = new ArrayList();

        // Profiles
        private CryptoEditorProfile currentProfile = new CryptoEditorProfile();

        // Persistance and encryption engine
        private CryptoEditorPersist persistor = null;

        // Lock counters
        private bool isLocked = false;
        private bool isIdle = false;
        private int timeIdle = 0;
        private int idlesSinceCheckpoint = 0;
        private int lastIdleSinceTimer = 0;
        private int idleSensibility = 2;

        private bool isHome = true;

        public CryptoEditorForm()
        {
            Application.Idle += new EventHandler(Application_Idle);

            InitializeComponent();

            // Create an instance of each plugin by calling the default constructor
            CryptoEditor.Common.CryptoEditorUtils.LoadPlugins(plugins);

            // Ask for the profile to use and call the Load( string data ) 
            // method for each plugin
            ChangeProfile();

            Size = new Size(currentProfile.Width, currentProfile.Height);
            splitContainer1.SplitterDistance = currentProfile.VerticalSplitter;
            splitContainer2.SplitterDistance = currentProfile.HorizontalSplitter;
            
            if (!currentProfile.PasswordValidated)
                return;

            // Populate the treeview by calling the "RootNode" property of each plugin
            LoadTreeView();

            // Populate the plugin views by calling the "View" property
            InitializePluginViews();

            treeView.Select();
        }

        public static bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            foreach( string type in (string[])criteriaObj )
            {
                if (typeObj.ToString().Equals( type ) )
                    return true;
            }
            
            return false;
        }

        private void LoadTreeView()
        {
            treeView.Nodes.Clear();

            for( int i=0; i<plugins.Count; i++ )
            {
                ICryptoEditor plugin = (ICryptoEditor)plugins[i];
                TreeNode node = (TreeNode)plugin.RootNode;
                treeView.Nodes.Add( node );
            }
        }

        private void InitializePluginViews()
        {
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel2.Controls.Clear();

            foreach (ICryptoEditor plugin in plugins)
            {
                UserControl view = (UserControl)plugin.View;
                view.Dock = DockStyle.Fill;
                view.Location = new Point(0,0);                
                view.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                view.TabStop = false;
                splitContainer2.Panel1.Controls.Add(view);

                UserControl detail = (UserControl)plugin.Detail;
                detail.Dock = DockStyle.Fill;
                detail.Location = new Point(0, 0);
                detail.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                detail.TabStop = false;
                splitContainer2.Panel2.Controls.Add(detail);
            }
        }

        private void ChangeProfile()
        {
            if( persistor != null )
                persistor.SaveData(false);

            CryptoEditorProfile oldProfile = currentProfile;

            CryptoEditorProfileManagerForm form = new CryptoEditorProfileManagerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.SelectedProfile != null)
                {
                    currentProfile = new CryptoEditorProfile();
                    currentProfile.Load(form.SelectedProfileFile);
                    currentProfile.PasswordValidated = false;

                    CryptoEditorPasswordForm formPassword = new CryptoEditorPasswordForm();
                    while (formPassword.ShowDialog() == DialogResult.OK)
                    {
                        string tmpPassword = CryptoEditorEncryption.Hash(formPassword.Password);
                        if (tmpPassword.Equals(currentProfile.EncryptedPassword))
                        {
                            currentProfile.PasswordValidated = true;
                            currentProfile.Password = formPassword.Password;
                            currentProfile.DecryptLicense();
                            this.Text = "CryptoEditor - " + currentProfile.Name + "/" + currentProfile.Email;

                            break;
                        }

                        MessageBox.Show("The password is incorrect! Please retype your password.", "Incorrect password",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        formPassword.Password = "";
                    }
                }
            }
            else
            {
                if(oldProfile.PasswordValidated)
                {
                    currentProfile = oldProfile;
                    return;
                }
            }

            if (!currentProfile.PasswordValidated && oldProfile.PasswordValidated)
            {
                currentProfile = oldProfile;
                return;
            }

            persistor = new CryptoEditorPersist(plugins, currentProfile);
            persistor.LoadData();

            treeView.Enabled = currentProfile.PasswordValidated;
            splitContainer1.Enabled = currentProfile.PasswordValidated;
        }

        private void ChangePassword()
        {
            CryptoEditorPasswordValidation form = new CryptoEditorPasswordValidation();
            while (form.ShowDialog() == DialogResult.OK)
            {
                string tmpPassword = CryptoEditorEncryption.Hash(form.OldPassword.Text);
                if (tmpPassword.Equals(currentProfile.EncryptedPassword))
                {
                    if (form.NewPassword1.Text.Equals(form.NewPassword2.Text))
                    {
                        currentProfile.PasswordValidated = true;
                        currentProfile.Password = form.NewPassword1.Text;
                        currentProfile.Save();
                        persistor.SaveData(true);

                        break;
                    }
                    else
                    {
                        MessageBox.Show("The password confirmation is incorrect!", "Incorrect new password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        form.NewPassword1.Text = "";
                        form.NewPassword2.Text = "";
                        continue;
                    }                    
                }

                MessageBox.Show("The old password is incorrect! Please retype your old password.", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                form.OldPassword.Text = "";
            }

            treeView.Enabled = currentProfile.PasswordValidated;
            splitContainer1.Enabled = currentProfile.PasswordValidated;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                ICryptoEditorRootNode node = (ICryptoEditorRootNode)treeView.SelectedNode;
                if (node.GetType().ToString().IndexOf("CryptoEditorHomeRootNode") > -1 )
                {
                    isHome = true;
                    splitContainer2.Panel1Collapsed = true;
                }
                else if(isHome)
                {
                    isHome = false;
                    splitContainer2.Panel1Collapsed = false;
                }

                node.OnSelect();
            }

        } 
        
        #region CryptoEditorForm Menu Events
        private void profilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeProfile();

            Size = new Size(currentProfile.Width, currentProfile.Height);
            splitContainer1.SplitterDistance = currentProfile.VerticalSplitter;
            splitContainer2.SplitterDistance = currentProfile.HorizontalSplitter;

            if (!currentProfile.PasswordValidated)
                return;

            // Populate the treeview by calling the "RootNode" property of each plugin
            LoadTreeView();

            // Populate the plugin views by calling the "View" property
            InitializePluginViews();

            treeView.Select();
            treeView.SelectedNode = treeView.Nodes[0];
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!currentProfile.PasswordValidated)
                return;

            ChangePassword();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CryptoEditorAboutBox form = new CryptoEditorAboutBox();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        #endregion

        private void CryptoEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!currentProfile.PasswordValidated)
                return;

            currentProfile.Width = Size.Width;
            currentProfile.Height = Size.Height;
            currentProfile.Save();

            persistor.SaveData(false);
        }

        private void CryptoEditorForm_Load(object sender, EventArgs e)
        {
            if(!currentProfile.PasswordValidated)
            {
                Close();
                Application.Exit();
            }

            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            persistor.SaveData(false);
            timer.Start();
        }

        public static void ShowWait()
        {
            CryptoEditorSyncProgress progressForm = new CryptoEditorSyncProgress();
            progressForm.ShowDialog();
        }

        private void newSync()
        {
            try
            {
                int status = 0;
                DateTime expiration = DateTime.Now;
                string encrypted_license = "";

                Cursor = Cursors.WaitCursor;

                bool ret = HttpServiceClient.GetProfile(currentProfile.Email,
                                             ref status,
                                             ref expiration,
                                             ref encrypted_license);

                // Message has already been displayed
                if(!ret)
                    return;

                if(status == 0)
                {
                    // Account not activated ...
                    CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your account is not activated. Visit our website to get your FREE registration key", "Account not activated");
                    form.ShowDialog();
                    return;
                }

                // Three days buffer ...
                if(expiration.AddDays(3.0) < DateTime.Now)
                {
                    // Account expired ...
                    CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your registration has expired. Visit our website to add more time to your subscription", "Account expired");
                    form.ShowDialog();
                    return;
                }

                if(encrypted_license.Length == 0)
                {
                    // Application not registered ...
                    CryptoEditorGoToWebForm form = new CryptoEditorGoToWebForm("Your account is not activated. Visit our website to get your FREE registration key", "Account not activated");
                    form.ShowDialog();
                    return;
                }

                // Make sure we have the same password as the server
                string serverPassword = this.currentProfile.Password;
                
                // Decrypt the encrypted_license
                string decryptedKey = CryptoEditorEncryption.Decrypt(encrypted_license, currentProfile.Password);
                
                // Validate the result
                if (decryptedKey.StartsWith(CryptoEditorProfile.keyPrefix))
                {
                    decryptedKey = decryptedKey.Substring(CryptoEditorProfile.keyPrefix.Length);
                }
                else
                {
                    while (true)
                    {
                        CryptoEditorPasswordSelection form = new CryptoEditorPasswordSelection();
                        if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return;

                        this.Cursor = Cursors.WaitCursor;

                        serverPassword = form.Password.Text;
                        decryptedKey = CryptoEditorEncryption.Decrypt(encrypted_license, serverPassword);

                        if (decryptedKey.StartsWith(CryptoEditorProfile.keyPrefix))
                        {
                            // Password is valid ...
                            decryptedKey = decryptedKey.Substring(CryptoEditorProfile.keyPrefix.Length);

                            if (form.newRadioButton.Checked)
                                currentProfile.Password = form.Password.Text;

                            break;
                        }

                        this.currentProfile.Password = form.Password.Text;
                        MessageBox.Show("The server password is incorrect! Please retype your password.", "Incorrect password",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    // At this point, the key has been properly decrypted. Update the local key and save the profile
                    this.currentProfile.Key = decryptedKey;
                    this.currentProfile.Save();

                    HttpServiceClient.PutLicense(currentProfile.Email, currentProfile.Key,
                                                 CryptoEditorEncryption.Encrypt(CryptoEditorProfile.keyPrefix + currentProfile.Key,
                                                                                currentProfile.Password), false);
                    
                }

                // All ok ... lets proceed.
                
                this.persistor.Synchronize(serverPassword);
                this.persistor.SaveData(true);

                return;
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Synchronization error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void synchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!currentProfile.SkipSyncWarning)
            {
                CryptoEditorMessageForm messageForm = new CryptoEditorMessageForm();
                messageForm.Text = "Internet access";
                messageForm.Size = new Size(350, 150);
                messageForm.messageTextBox.Text =
                    "CryptoEditor will access the internet to backup your encrypted data. No password is transfered over the internet because your data is encrypted on your computer before to be sent to our servers. If you dont feel safe, please visit us online to read more about our technology.";

                DialogResult ret = messageForm.ShowDialog();

                if (messageForm.showAgainCheckBox.Checked != currentProfile.SkipSyncWarning)
                {
                    currentProfile.SkipSyncWarning = messageForm.showAgainCheckBox.Checked;
                    currentProfile.Save();
                }

                if (ret != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            
            //oldSynk();
            newSync();
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            if (node != null)
            {
                
                ICryptoEditorRootNode rootNode = (ICryptoEditorRootNode) node;
                rootNode.DragOver(sender,e);
            }

            return;
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            if (node != null)
            {
                ICryptoEditorRootNode rootNode = (ICryptoEditorRootNode)node;
                rootNode.DragEnter(sender, e);
            }

            return;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));
            if (node != null)
            {
                ICryptoEditorRootNode rootNode = (ICryptoEditorRootNode)node;
                rootNode.DragDrop(sender, e);
            }

            
            treeView.SelectedNode = node;
            treeView.Select();

            return;
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ICryptoEditorRootNode rootNode = (ICryptoEditorRootNode)e.Item;
            rootNode.ItemDrag(sender, e);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            // Increment idle counter.
            idlesSinceCheckpoint++;
        }

        private void lockTimer_Tick(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine( idlesSinceCheckpoint.ToString() + " " + lastIdleSinceTimer + " " + timeIdle.ToString() );

            if (lastIdleSinceTimer >= idlesSinceCheckpoint - idleSensibility)
                timeIdle++;
            else
            {
                timeIdle = 0;
                isIdle = false;
            }

            lastIdleSinceTimer = idlesSinceCheckpoint;

            if (currentProfile.IdleTimeout > 0 &&
                timeIdle > currentProfile.IdleTimeout * 60
                && !isIdle)
            {
                // The app is idle ...
                isIdle = true;

                Lock();
            }
        }

        private void Lock()
        {
            if(!currentProfile.PasswordValidated)
                return;

            if (isLocked)
                return;

            isLocked = true;

            // Hide all controls ...
            splitContainer1.Visible = false;
            backupToolStripMenuItem.Enabled = false;
            profilesToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;
            preferencesToolStripMenuItem.Enabled = false;
            lockToolStripMenuItem.Enabled = false;
            helpToolStripMenuItem.Enabled = false;
        }

        private void Unlock()
        {
            if (!isLocked)
                return;

            CryptoEditorPasswordForm formPassword = new CryptoEditorPasswordForm();
            while (formPassword.ShowDialog() == DialogResult.OK)
            {
                string tmpPassword = CryptoEditorEncryption.Hash(formPassword.Password);
                if (tmpPassword.Equals(currentProfile.EncryptedPassword))
                {
                    isLocked = false;

                    // Show all controls ...
                    splitContainer1.Visible = true;
                    backupToolStripMenuItem.Enabled = true;
                    profilesToolStripMenuItem.Enabled = true;
                    changePasswordToolStripMenuItem.Enabled = true;
                    preferencesToolStripMenuItem.Enabled = true;
                    lockToolStripMenuItem.Enabled = true;
                    helpToolStripMenuItem.Enabled = true;

                    break;
                }

                MessageBox.Show("The password is incorrect! Please retype your password.", "Incorrect password",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                formPassword.Password = "";
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lock();
        }

        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unlock();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CryptoEditorPreferences form = new CryptoEditorPreferences();
            form.profileName.Text = currentProfile.Name;
            form.emailAddress.Text = currentProfile.Email;
            form.idleDelay.Text = currentProfile.IdleTimeout.ToString();
            if(form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            currentProfile.Name = form.profileName.Text;
            currentProfile.Email = form.emailAddress.Text;
            currentProfile.IdleTimeout = Convert.ToInt32(form.idleDelay.Text);
            currentProfile.Save();

            if(!currentProfile.Email.Equals(form.emailAddress.Text))
            {
                // Email has changed ...
                MessageBox.Show("Changing your email address ...", "NOT YET IMPLEMENTED");
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (currentProfile != null)
                currentProfile.VerticalSplitter = splitContainer1.SplitterDistance;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (currentProfile != null)
                currentProfile.HorizontalSplitter = splitContainer2.SplitterDistance;
        }

        private void synchronizeToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Save your encrypted data on the internet.";
        }

        private void synchronizeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void profilesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Create, open and delete user profiles.";
        }

        private void profilesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void changePasswordToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Change your current password.";
        }

        private void changePasswordToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void preferencesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Change the program lock delay.";
        }

        private void preferencesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void lockToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Lock the program to protect your data while you are away.";
        }

        private void lockToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void unlockToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Unlock the program to access your data.";
        }

        private void unlockToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Safely close the application.";
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void aboutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Register and check program version.";
        }

        private void aboutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void profileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Manage user profiles, passwords and preferences.";
        }

        private void profileToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void backupToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Save your encrypted data on the internet.";
        }

        private void backupToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void helpToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Program versions and registration form.";
        }

        private void helpToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private void gettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            string linkText = "http://localhost:8080";
#else
            string linkText = "http://cryptoeditor.appspot.com";
#endif

            System.Diagnostics.Process.Start(linkText);
        }

        private void treeView_Leave(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
                treeView.SelectedNode.BackColor = Color.LightGray;
        }

        private void treeView_Enter(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
                treeView.SelectedNode.BackColor = Color.Empty;
        }

        private void registerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CryptoEditorRegistration form = new CryptoEditorRegistration();
            form.emailTextBox.Text = currentProfile.Email;
            if (form.ShowDialog() != DialogResult.OK)
                return;

            if (form.keyTextBox.Text.Length == 0)
                return;

            string encryptedLicense = CryptoEditorEncryption.Encrypt(CryptoEditorProfile.keyPrefix + form.keyTextBox.Text, currentProfile.Password);

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ret = HttpServiceClient.PutLicense(form.emailTextBox.Text, form.keyTextBox.Text, encryptedLicense, true);
                if (!ret)
                {
                    return;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (form.keyTextBox.Text.Length > 0)
            {
                currentProfile.Email = form.emailTextBox.Text;
                currentProfile.Key = form.keyTextBox.Text;
                currentProfile.Save();
            }

            MessageBox.Show("Confirmation succeeded. You can now use the Synchronization service.",
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        //private void oldSynk()
        //{

        //    //System.Threading.Thread newThread = new Thread(new ThreadStart(CryptoEditorForm.ShowWait));
        //    //newThread.Start();

        //    System.Windows.Forms.Cursor old = Cursor;
        //    Cursor = Cursors.WaitCursor;
        //    try
        //    {
        //        // Get the encrypted key from the server
        //        BackupService client = new BackupService();
        //        string encryptedKey = client.GetEncryptedLicense(this.currentProfile.Email);

        //        // Decrypt the key
        //        string decryptedKey = CryptoEditorEncryption.Decrypt(encryptedKey, this.currentProfile.Password);

        //        // Validate the decrypted key with the server
        //        CryptoEditorServiceCodes isValid = client.IsLicenseValid(this.currentProfile.Email, decryptedKey);

        //        // If the user has never been registered
        //        if (isValid == CryptoEditorServiceCodes.USER_DOES_NOT_EXIST)
        //        {
        //            CryptoEditorRegistration form = new CryptoEditorRegistration();
        //            form.emailTextBox.Text = this.currentProfile.Email;
        //            DialogResult ret = form.ShowDialog();
        //            if (ret != DialogResult.OK)
        //                return;

        //            this.Cursor = Cursors.WaitCursor;

        //            if (form.emailTextBox.Text.Length == 0 || form.emailTextBox.Text.IndexOf("@") < 0)
        //            {
        //                MessageBox.Show("Enter a valid email address.", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            this.currentProfile.Email = form.emailTextBox.Text;

        //            // Register
        //            CryptoEditorServiceCodes registered = client.Register(this.currentProfile.Email, this.currentProfile.Name, this.currentProfile.Name);
        //            if (registered == CryptoEditorServiceCodes.USER_EXIST)
        //            {
        //                MessageBox.Show("A user with that email and profile name already exist!", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (registered != CryptoEditorServiceCodes.SUCCESS)
        //            {
        //                MessageBox.Show("Registration failed. Are you connected to the internet?", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            MessageBox.Show("Registration succeeded. You will receive your key by email.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        // The user has never confirmed its registration.
        //        if (encryptedKey.Length == 0)
        //        {
        //            MessageBox.Show("Your accound has not been activated. Please enter the key you received by email into the About box.",
        //                            "Account Not Activated", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            return;
        //        }

        //        // If the key has not been properly decrypted
        //        string serverPassword = this.currentProfile.Password;
        //        while (isValid == CryptoEditorServiceCodes.INVALID_LICENSE)
        //        {
        //            CryptoEditorPasswordSelection form = new CryptoEditorPasswordSelection();
        //            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
        //                return;

        //            this.Cursor = Cursors.WaitCursor;

        //            serverPassword = form.Password.Text;
        //            decryptedKey = CryptoEditorEncryption.Decrypt(encryptedKey, serverPassword);

        //            // Validate the decrypted key with the server
        //            isValid = client.IsLicenseValid(this.currentProfile.Email, decryptedKey);

        //            if (isValid != CryptoEditorServiceCodes.INVALID_LICENSE && form.newRadioButton.Checked)
        //                this.currentProfile.Password = form.Password.Text;

        //            if (isValid == CryptoEditorServiceCodes.INVALID_LICENSE)
        //                MessageBox.Show("The server password is incorrect! Please retype your password.", "Incorrect password",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        }

        //        // At this point, the key has been properly decrypted. Update the local key and save the profile
        //        this.currentProfile.Key = decryptedKey;
        //        this.currentProfile.Save();

        //        client.UpdateKey(this.currentProfile.Email, this.currentProfile.Key,
        //                         CryptoEditorEncryption.Encrypt(this.currentProfile.Key, this.currentProfile.Password));

        //        if (isValid == CryptoEditorServiceCodes.USER_DISABLED)
        //        {
        //            MessageBox.Show("Your accound has been disabled. Call the CryptoEditor support for more details.",
        //                            "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            return;
        //        }

        //        if (isValid == CryptoEditorServiceCodes.USER_EXPIRED)
        //        {
        //            MessageBox.Show("Your account access has expired. Please visit us to reactivate your account.",
        //                            "Account Expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            return;
        //        }

        //        if (isValid == CryptoEditorServiceCodes.SUCCESS)
        //        {
        //            // SYNCHRONIZE
        //            this.persistor.Synchronize(serverPassword);
        //            this.persistor.SaveData(true);
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        MessageBox.Show(ex.Message,
        //            "Connection error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor = old;
        //        //newThread.Abort();
        //    }
        //}
    }
}
