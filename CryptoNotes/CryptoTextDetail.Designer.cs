namespace CryptoEditor.Notes
{
    partial class CryptoTextDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cryptoNotesTabs = new System.Windows.Forms.TabControl();
            this.notesTab = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.propertiesTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.keywordsTextBox = new System.Windows.Forms.TextBox();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.cryptoNotesTabs.SuspendLayout();
            this.notesTab.SuspendLayout();
            this.propertiesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cryptoNotesTabs
            // 
            this.cryptoNotesTabs.Controls.Add(this.notesTab);
            this.cryptoNotesTabs.Controls.Add(this.propertiesTab);
            this.cryptoNotesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoNotesTabs.Location = new System.Drawing.Point(0, 0);
            this.cryptoNotesTabs.Name = "cryptoNotesTabs";
            this.cryptoNotesTabs.SelectedIndex = 0;
            this.cryptoNotesTabs.Size = new System.Drawing.Size(501, 350);
            this.cryptoNotesTabs.TabIndex = 1;
            // 
            // notesTab
            // 
            this.notesTab.Controls.Add(this.checkBox1);
            this.notesTab.Controls.Add(this.notesTextBox);
            this.notesTab.Location = new System.Drawing.Point(4, 22);
            this.notesTab.Name = "notesTab";
            this.notesTab.Padding = new System.Windows.Forms.Padding(3);
            this.notesTab.Size = new System.Drawing.Size(493, 324);
            this.notesTab.TabIndex = 1;
            this.notesTab.Text = "Text";
            this.notesTab.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 302);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Text Wrap";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // notesTextBox
            // 
            this.notesTextBox.AcceptsReturn = true;
            this.notesTextBox.AllowDrop = true;
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.notesTextBox.Location = new System.Drawing.Point(3, 3);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notesTextBox.Size = new System.Drawing.Size(490, 293);
            this.notesTextBox.TabIndex = 0;
            this.notesTextBox.WordWrap = false;
            this.notesTextBox.Validated += new System.EventHandler(this.notesTextBox_Validated);
            // 
            // propertiesTab
            // 
            this.propertiesTab.Controls.Add(this.label4);
            this.propertiesTab.Controls.Add(this.label5);
            this.propertiesTab.Controls.Add(this.keywordsTextBox);
            this.propertiesTab.Controls.Add(this.commentsTextBox);
            this.propertiesTab.Controls.Add(this.label3);
            this.propertiesTab.Controls.Add(this.label2);
            this.propertiesTab.Controls.Add(this.authorTextBox);
            this.propertiesTab.Controls.Add(this.label1);
            this.propertiesTab.Controls.Add(this.subjectTextBox);
            this.propertiesTab.Controls.Add(this.titleTextBox);
            this.propertiesTab.Location = new System.Drawing.Point(4, 22);
            this.propertiesTab.Name = "propertiesTab";
            this.propertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesTab.Size = new System.Drawing.Size(493, 324);
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
            this.label4.TabIndex = 5;
            this.label4.Text = "Keywords";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comments";
            // 
            // keywordsTextBox
            // 
            this.keywordsTextBox.AcceptsReturn = true;
            this.keywordsTextBox.AllowDrop = true;
            this.keywordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.keywordsTextBox.Location = new System.Drawing.Point(9, 175);
            this.keywordsTextBox.Multiline = true;
            this.keywordsTextBox.Name = "keywordsTextBox";
            this.keywordsTextBox.ReadOnly = true;
            this.keywordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keywordsTextBox.Size = new System.Drawing.Size(478, 143);
            this.keywordsTextBox.TabIndex = 7;
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.commentsTextBox.Location = new System.Drawing.Point(9, 136);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.ReadOnly = true;
            this.commentsTextBox.Size = new System.Drawing.Size(478, 20);
            this.commentsTextBox.TabIndex = 6;
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
            this.authorTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.authorTextBox.Location = new System.Drawing.Point(9, 97);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.ReadOnly = true;
            this.authorTextBox.Size = new System.Drawing.Size(478, 20);
            this.authorTextBox.TabIndex = 2;
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
            this.subjectTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.subjectTextBox.Location = new System.Drawing.Point(9, 58);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.ReadOnly = true;
            this.subjectTextBox.Size = new System.Drawing.Size(478, 20);
            this.subjectTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.titleTextBox.Location = new System.Drawing.Point(9, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(478, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // CryptoTextDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cryptoNotesTabs);
            this.Name = "CryptoTextDetail";
            this.Size = new System.Drawing.Size(501, 350);
            this.cryptoNotesTabs.ResumeLayout(false);
            this.notesTab.ResumeLayout(false);
            this.notesTab.PerformLayout();
            this.propertiesTab.ResumeLayout(false);
            this.propertiesTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl cryptoNotesTabs;
        private System.Windows.Forms.TabPage propertiesTab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox subjectTextBox;
        public System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TabPage notesTab;
        public System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox keywordsTextBox;
        public System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
