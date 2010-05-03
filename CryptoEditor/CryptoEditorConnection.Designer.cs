namespace CryptoEditor
{
    partial class CryptoEditorConnection
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.useProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.domainLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.useAuthenticationCheckBox = new System.Windows.Forms.CheckBox();
            this.proxyPortTextBox = new System.Windows.Forms.TextBox();
            this.proxyPortLabel = new System.Windows.Forms.Label();
            this.proxyAddressTextBox = new System.Windows.Forms.TextBox();
            this.proxyAddressLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(197, 347);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(116, 346);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "&Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // useProxyCheckBox
            // 
            this.useProxyCheckBox.AutoSize = true;
            this.useProxyCheckBox.Location = new System.Drawing.Point(13, 13);
            this.useProxyCheckBox.Name = "useProxyCheckBox";
            this.useProxyCheckBox.Size = new System.Drawing.Size(74, 17);
            this.useProxyCheckBox.TabIndex = 0;
            this.useProxyCheckBox.Text = "Use Proxy";
            this.useProxyCheckBox.UseVisualStyleBackColor = true;
            this.useProxyCheckBox.CheckedChanged += new System.EventHandler(this.useProxyCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.useAuthenticationCheckBox);
            this.groupBox1.Controls.Add(this.proxyPortTextBox);
            this.groupBox1.Controls.Add(this.proxyPortLabel);
            this.groupBox1.Controls.Add(this.proxyAddressTextBox);
            this.groupBox1.Controls.Add(this.proxyAddressLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 303);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.domainTextBox);
            this.groupBox2.Controls.Add(this.domainLabel);
            this.groupBox2.Controls.Add(this.passwordTextBox);
            this.groupBox2.Controls.Add(this.passwordLabel);
            this.groupBox2.Controls.Add(this.userNameTextBox);
            this.groupBox2.Controls.Add(this.userNameLabel);
            this.groupBox2.Location = new System.Drawing.Point(10, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 158);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // domainTextBox
            // 
            this.domainTextBox.Location = new System.Drawing.Point(10, 121);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(227, 20);
            this.domainTextBox.TabIndex = 2;
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(10, 105);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(74, 13);
            this.domainLabel.TabIndex = 3;
            this.domainLabel.Text = "Domain Name";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(10, 81);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(227, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(10, 64);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(10, 37);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(227, 20);
            this.userNameTextBox.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(10, 20);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(55, 13);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "Username";
            // 
            // useAuthenticationCheckBox
            // 
            this.useAuthenticationCheckBox.AutoSize = true;
            this.useAuthenticationCheckBox.Location = new System.Drawing.Point(7, 108);
            this.useAuthenticationCheckBox.Name = "useAuthenticationCheckBox";
            this.useAuthenticationCheckBox.Size = new System.Drawing.Size(116, 17);
            this.useAuthenticationCheckBox.TabIndex = 2;
            this.useAuthenticationCheckBox.Text = "Use Authentication";
            this.useAuthenticationCheckBox.UseVisualStyleBackColor = true;
            this.useAuthenticationCheckBox.CheckedChanged += new System.EventHandler(this.useAuthenticationCheckBox_CheckedChanged);
            // 
            // proxyPortTextBox
            // 
            this.proxyPortTextBox.Location = new System.Drawing.Point(7, 81);
            this.proxyPortTextBox.Name = "proxyPortTextBox";
            this.proxyPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.proxyPortTextBox.TabIndex = 1;
            // 
            // proxyPortLabel
            // 
            this.proxyPortLabel.AutoSize = true;
            this.proxyPortLabel.Location = new System.Drawing.Point(7, 64);
            this.proxyPortLabel.Name = "proxyPortLabel";
            this.proxyPortLabel.Size = new System.Drawing.Size(55, 13);
            this.proxyPortLabel.TabIndex = 1;
            this.proxyPortLabel.Text = "Proxy Port";
            // 
            // proxyAddressTextBox
            // 
            this.proxyAddressTextBox.Location = new System.Drawing.Point(7, 37);
            this.proxyAddressTextBox.Name = "proxyAddressTextBox";
            this.proxyAddressTextBox.Size = new System.Drawing.Size(246, 20);
            this.proxyAddressTextBox.TabIndex = 0;
            // 
            // proxyAddressLabel
            // 
            this.proxyAddressLabel.AutoSize = true;
            this.proxyAddressLabel.Location = new System.Drawing.Point(7, 20);
            this.proxyAddressLabel.Name = "proxyAddressLabel";
            this.proxyAddressLabel.Size = new System.Drawing.Size(74, 13);
            this.proxyAddressLabel.TabIndex = 0;
            this.proxyAddressLabel.Text = "Proxy Address";
            // 
            // CryptoEditorConnection
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(284, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.useProxyCheckBox);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorConnection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.CryptoEditorConnection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label proxyPortLabel;
        private System.Windows.Forms.Label proxyAddressLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.CheckBox useProxyCheckBox;
        private System.Windows.Forms.TextBox proxyPortTextBox;
        private System.Windows.Forms.TextBox proxyAddressTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.CheckBox useAuthenticationCheckBox;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Label domainLabel;
    }
}