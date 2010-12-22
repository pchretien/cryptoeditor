namespace CryptoEditor.Common
{
    partial class CryptoEditorGoToWebForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CryptoEditorGoToWebForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.haveAccountButton = new System.Windows.Forms.Button();
            this.dontHaveAccountButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(223, 276);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.Location = new System.Drawing.Point(12, 12);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(286, 40);
            this.messageTextBox.TabIndex = 2;
            // 
            // haveAccountButton
            // 
            this.haveAccountButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.haveAccountButton.Location = new System.Drawing.Point(12, 130);
            this.haveAccountButton.Name = "haveAccountButton";
            this.haveAccountButton.Size = new System.Drawing.Size(75, 23);
            this.haveAccountButton.TabIndex = 4;
            this.haveAccountButton.Text = "Login";
            this.haveAccountButton.UseVisualStyleBackColor = true;
            this.haveAccountButton.Click += new System.EventHandler(this.haveAccountButton_Click);
            // 
            // dontHaveAccountButton
            // 
            this.dontHaveAccountButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dontHaveAccountButton.Location = new System.Drawing.Point(12, 237);
            this.dontHaveAccountButton.Name = "dontHaveAccountButton";
            this.dontHaveAccountButton.Size = new System.Drawing.Size(75, 23);
            this.dontHaveAccountButton.TabIndex = 4;
            this.dontHaveAccountButton.Text = "Register";
            this.dontHaveAccountButton.UseVisualStyleBackColor = true;
            this.dontHaveAccountButton.Click += new System.EventHandler(this.dontHaveAccountButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 65);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 65);
            this.label2.TabIndex = 6;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // CryptoEditorGoToWebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(310, 311);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dontHaveAccountButton);
            this.Controls.Add(this.haveAccountButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorGoToWebForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button haveAccountButton;
        private System.Windows.Forms.Button dontHaveAccountButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}