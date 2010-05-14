namespace CryptoEditor.Text
{
    partial class CryptoTextEditionForm
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
            this.cryptoNotesTabs = new System.Windows.Forms.TabControl();
            this.propertiesTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.keywordsTextBox = new System.Windows.Forms.TextBox();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.notesTab = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cryptoNotesTabs.SuspendLayout();
            this.propertiesTab.SuspendLayout();
            this.notesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cryptoNotesTabs
            // 
            this.cryptoNotesTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cryptoNotesTabs.Controls.Add(this.propertiesTab);
            this.cryptoNotesTabs.Controls.Add(this.notesTab);
            this.cryptoNotesTabs.Location = new System.Drawing.Point(12, 12);
            this.cryptoNotesTabs.Name = "cryptoNotesTabs";
            this.cryptoNotesTabs.SelectedIndex = 0;
            this.cryptoNotesTabs.Size = new System.Drawing.Size(410, 260);
            this.cryptoNotesTabs.TabIndex = 0;
            this.cryptoNotesTabs.TabStop = false;
            // 
            // propertiesTab
            // 
            this.propertiesTab.Controls.Add(this.label4);
            this.propertiesTab.Controls.Add(this.label5);
            this.propertiesTab.Controls.Add(this.label3);
            this.propertiesTab.Controls.Add(this.keywordsTextBox);
            this.propertiesTab.Controls.Add(this.commentsTextBox);
            this.propertiesTab.Controls.Add(this.label2);
            this.propertiesTab.Controls.Add(this.authorTextBox);
            this.propertiesTab.Controls.Add(this.label1);
            this.propertiesTab.Controls.Add(this.subjectTextBox);
            this.propertiesTab.Controls.Add(this.titleTextBox);
            this.propertiesTab.Location = new System.Drawing.Point(4, 22);
            this.propertiesTab.Name = "propertiesTab";
            this.propertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesTab.Size = new System.Drawing.Size(402, 234);
            this.propertiesTab.TabIndex = 0;
            this.propertiesTab.Text = "Properties";
            this.propertiesTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Keywords";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Comments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Author";
            // 
            // keywordsTextBox
            // 
            this.keywordsTextBox.AcceptsReturn = true;
            this.keywordsTextBox.AllowDrop = true;
            this.keywordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordsTextBox.Location = new System.Drawing.Point(9, 175);
            this.keywordsTextBox.Multiline = true;
            this.keywordsTextBox.Name = "keywordsTextBox";
            this.keywordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keywordsTextBox.Size = new System.Drawing.Size(387, 50);
            this.keywordsTextBox.TabIndex = 5;
            this.keywordsTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsTextBox.Location = new System.Drawing.Point(9, 136);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(387, 20);
            this.commentsTextBox.TabIndex = 3;
            this.commentsTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(9, 97);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(387, 20);
            this.authorTextBox.TabIndex = 2;
            this.authorTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.Location = new System.Drawing.Point(9, 58);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(387, 20);
            this.subjectTextBox.TabIndex = 1;
            this.subjectTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(9, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(387, 20);
            this.titleTextBox.TabIndex = 0;
            this.titleTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // notesTab
            // 
            this.notesTab.Controls.Add(this.checkBox1);
            this.notesTab.Controls.Add(this.notesTextBox);
            this.notesTab.Location = new System.Drawing.Point(4, 22);
            this.notesTab.Name = "notesTab";
            this.notesTab.Padding = new System.Windows.Forms.Padding(3);
            this.notesTab.Size = new System.Drawing.Size(402, 234);
            this.notesTab.TabIndex = 1;
            this.notesTab.Text = "Text";
            this.notesTab.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 240);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Text Wrap";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // notesTextBox
            // 
            this.notesTextBox.AcceptsReturn = true;
            this.notesTextBox.AcceptsTab = true;
            this.notesTextBox.AllowDrop = true;
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.Location = new System.Drawing.Point(3, 3);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notesTextBox.Size = new System.Drawing.Size(393, 231);
            this.notesTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(343, 278);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(262, 278);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CryptoTextEditionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(434, 312);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cryptoNotesTabs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoTextEditionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Edition";
            this.cryptoNotesTabs.ResumeLayout(false);
            this.propertiesTab.ResumeLayout(false);
            this.propertiesTab.PerformLayout();
            this.notesTab.ResumeLayout(false);
            this.notesTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl cryptoNotesTabs;
        private System.Windows.Forms.TabPage propertiesTab;
        private System.Windows.Forms.TabPage notesTab;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox keywordsTextBox;
        public System.Windows.Forms.TextBox titleTextBox;
        public System.Windows.Forms.TextBox authorTextBox;
        public System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}