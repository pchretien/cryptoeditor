namespace CryptoEditor
{
    partial class CryptoEditorProfileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.profileName = new System.Windows.Forms.TextBox();
            this.password1 = new System.Windows.Forms.TextBox();
            this.password2 = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password Confirmation";
            // 
            // profileName
            // 
            this.helpProvider.SetHelpString(this.profileName, "CryptoEditor can be used by multiple users. Enter your full name or an alias to c" +
                    "reate your profile.");
            this.profileName.Location = new System.Drawing.Point(12, 26);
            this.profileName.Name = "profileName";
            this.helpProvider.SetShowHelp(this.profileName, true);
            this.profileName.Size = new System.Drawing.Size(270, 20);
            this.profileName.TabIndex = 0;
            this.toolTip.SetToolTip(this.profileName, "CryptoEditor can be used by multiple users. Enter \r\nyour full name or an alias to" +
                    " create your profile.");
            // 
            // password1
            // 
            this.helpProvider.SetHelpString(this.password1, "You need a strong password to protect your sensitive data. This password will be " +
                    "used to encrypt your sensitive data on your computer.");
            this.password1.Location = new System.Drawing.Point(12, 71);
            this.password1.Name = "password1";
            this.password1.PasswordChar = '*';
            this.helpProvider.SetShowHelp(this.password1, true);
            this.password1.Size = new System.Drawing.Size(270, 20);
            this.password1.TabIndex = 2;
            this.toolTip.SetToolTip(this.password1, "You need a strong password to protect your sensitive data. \r\nThis password will b" +
                    "e used to encrypt your sensitive data on \r\nyour computer.");
            this.password1.TextChanged += new System.EventHandler(this.password1_TextChanged);
            // 
            // password2
            // 
            this.helpProvider.SetHelpString(this.password2, "Type your password again to make sure you entered it correctly on the first time");
            this.password2.Location = new System.Drawing.Point(12, 120);
            this.password2.Name = "password2";
            this.password2.PasswordChar = '*';
            this.helpProvider.SetShowHelp(this.password2, true);
            this.password2.Size = new System.Drawing.Size(270, 20);
            this.password2.TabIndex = 3;
            this.toolTip.SetToolTip(this.password2, "Type your password again to make sure you \r\nentered it correctly on the first tim" +
                    "e");
            this.password2.TextChanged += new System.EventHandler(this.password2_TextChanged);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(126, 215);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "&OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(207, 216);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.helpProvider.SetHelpString(this.progressBar1, "Password strength. Use caps, numbers and special characters to maximize safety. W" +
                    "e recommend a password with at least more than 6 characters.");
            this.progressBar1.Location = new System.Drawing.Point(10, 175);
            this.progressBar1.Name = "progressBar1";
            this.helpProvider.SetShowHelp(this.progressBar1, true);
            this.progressBar1.Size = new System.Drawing.Size(272, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            this.toolTip.SetToolTip(this.progressBar1, "Password strength. Use caps, numbers and special \r\ncharacters to maximize safety." +
                    " We recommend a \r\npassword with at least more than 6 characters.");
            this.progressBar1.Value = 5;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 146);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(265, 29);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Password strength. Use caps, numbers and special characters to maximize safety.";
            // 
            // CryptoEditorProfileForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(294, 253);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.password2);
            this.Controls.Add(this.password1);
            this.Controls.Add(this.profileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorProfileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Editor";
            this.Load += new System.EventHandler(this.CryptoEditorProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox profileName;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.TextBox password1;
        public System.Windows.Forms.TextBox password2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}