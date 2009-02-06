namespace CryptoEditor
{
    partial class CryptoEditorPasswordValidation
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
            this.NewPassword1 = new System.Windows.Forms.TextBox();
            this.NewPassword2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // NewPassword1
            // 
            this.helpProvider1.SetHelpString(this.NewPassword1, "Your new password. This is the password you will be using in the future");
            this.NewPassword1.Location = new System.Drawing.Point(12, 66);
            this.NewPassword1.Name = "NewPassword1";
            this.NewPassword1.PasswordChar = '*';
            this.helpProvider1.SetShowHelp(this.NewPassword1, true);
            this.NewPassword1.Size = new System.Drawing.Size(268, 20);
            this.NewPassword1.TabIndex = 0;
            this.toolTipHelp.SetToolTip(this.NewPassword1, "Your new password. This is the password \r\nyou will be using in the future");
            this.NewPassword1.UseSystemPasswordChar = true;
            this.NewPassword1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // NewPassword2
            // 
            this.helpProvider1.SetHelpString(this.NewPassword2, "Your new password again to make sure you did not make any typo");
            this.NewPassword2.Location = new System.Drawing.Point(12, 107);
            this.NewPassword2.Name = "NewPassword2";
            this.NewPassword2.PasswordChar = '*';
            this.NewPassword2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.NewPassword2, true);
            this.NewPassword2.Size = new System.Drawing.Size(268, 20);
            this.NewPassword2.TabIndex = 1;
            this.toolTipHelp.SetToolTip(this.NewPassword2, "Your new password again to make \r\nsure you did not make any typo");
            this.NewPassword2.UseSystemPasswordChar = true;
            this.NewPassword2.TextChanged += new System.EventHandler(this.password2_TextChanged);
            // 
            // progressBar1
            // 
            this.helpProvider1.SetHelpString(this.progressBar1, "The strength of your password. Uses caps, numbers and special characters to impro" +
                    "ve your password strength");
            this.progressBar1.Location = new System.Drawing.Point(12, 167);
            this.progressBar1.Name = "progressBar1";
            this.helpProvider1.SetShowHelp(this.progressBar1, true);
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            this.toolTipHelp.SetToolTip(this.progressBar1, "The strength of your password. Uses caps, \r\nnumbers and special characters to imp" +
                    "rove \r\nyour password strength");
            this.progressBar1.Value = 5;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(124, 200);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password Confirmation";
            // 
            // OldPassword
            // 
            this.helpProvider1.SetHelpString(this.OldPassword, "Your actual password to make sure no one else is changing your password");
            this.OldPassword.Location = new System.Drawing.Point(12, 25);
            this.OldPassword.Name = "OldPassword";
            this.OldPassword.PasswordChar = '*';
            this.helpProvider1.SetShowHelp(this.OldPassword, true);
            this.OldPassword.Size = new System.Drawing.Size(268, 20);
            this.OldPassword.TabIndex = 0;
            this.toolTipHelp.SetToolTip(this.OldPassword, "Your actual password to make sure no \r\none else is changing your password");
            this.OldPassword.UseSystemPasswordChar = true;
            this.OldPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Old Password";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 136);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(265, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Password strength. Use caps, numbers and special characters to maximize safety.";
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.AutomaticDelay = 100;
            this.toolTipHelp.AutoPopDelay = 5000;
            this.toolTipHelp.InitialDelay = 100;
            this.toolTipHelp.ReshowDelay = 20;
            // 
            // CryptoEditorPasswordValidation
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(291, 232);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.NewPassword2);
            this.Controls.Add(this.OldPassword);
            this.Controls.Add(this.NewPassword1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorPasswordValidation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password";
            this.Load += new System.EventHandler(this.CryptoEditorPasswordValidation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.TextBox NewPassword1;
        public System.Windows.Forms.TextBox NewPassword2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox OldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTipHelp;
    }
}