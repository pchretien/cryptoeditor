namespace CryptoEditor
{
    partial class CryptoEditorPasswordSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CryptoEditorPasswordSelection));
            this.okButton = new System.Windows.Forms.Button();
            this.oldRadioButton = new System.Windows.Forms.RadioButton();
            this.newRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(143, 214);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // oldRadioButton
            // 
            this.oldRadioButton.AutoSize = true;
            this.oldRadioButton.Checked = true;
            this.oldRadioButton.Location = new System.Drawing.Point(6, 19);
            this.oldRadioButton.Name = "oldRadioButton";
            this.oldRadioButton.Size = new System.Drawing.Size(241, 30);
            this.oldRadioButton.TabIndex = 0;
            this.oldRadioButton.TabStop = true;
            this.oldRadioButton.Text = "This password is my OLD password. Replace \r\nthe server password with the local pa" +
                "ssword.";
            this.oldRadioButton.UseVisualStyleBackColor = true;
            // 
            // newRadioButton
            // 
            this.newRadioButton.AutoSize = true;
            this.newRadioButton.Location = new System.Drawing.Point(6, 55);
            this.newRadioButton.Name = "newRadioButton";
            this.newRadioButton.Size = new System.Drawing.Size(245, 30);
            this.newRadioButton.TabIndex = 1;
            this.newRadioButton.Text = "This password is my NEW password. Replace \r\nthe local password with the server pa" +
                "ssword.";
            this.newRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.newRadioButton);
            this.groupBox1.Controls.Add(this.oldRadioButton);
            this.helpProvider.SetHelpString(this.groupBox1, resources.GetString("groupBox1.HelpString"));
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.helpProvider.SetShowHelp(this.groupBox1, true);
            this.groupBox1.Size = new System.Drawing.Size(290, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Selection";
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(290, 51);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "The password on the server is not the same as your current password. Please enter" +
                " the password used the last time you synchronized your data.";
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider.SetHelpString(this.Password, "Enter the password you used the last time you synchronize your data. This passwor" +
                    "d will be used to decrypt the data from the server.");
            this.Password.Location = new System.Drawing.Point(12, 69);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.helpProvider.SetShowHelp(this.Password, true);
            this.Password.Size = new System.Drawing.Size(290, 20);
            this.Password.TabIndex = 0;
            this.toolTip.SetToolTip(this.Password, "Enter the password you used the last time you synchronize \r\nyour data. This passw" +
                    "ord will be used to decrypt the data \r\nfrom the server.");
            this.Password.UseSystemPasswordChar = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(227, 214);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 20;
            // 
            // CryptoEditorPasswordSelection
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(314, 249);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorPasswordSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your password has changed";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button cancel;
        public System.Windows.Forms.RadioButton oldRadioButton;
        public System.Windows.Forms.RadioButton newRadioButton;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolTip toolTip;
    }
}