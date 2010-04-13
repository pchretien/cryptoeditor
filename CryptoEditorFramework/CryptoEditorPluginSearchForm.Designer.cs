namespace CryptoEditor.FormFramework
{
    partial class CryptoEditorPluginSearchForm
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.phraseRadioButton = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.anyRadioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.searchTextBox, "Enter the text to search");
            this.searchTextBox.Location = new System.Drawing.Point(72, 13);
            this.searchTextBox.Name = "searchTextBox";
            this.helpProvider1.SetShowHelp(this.searchTextBox, true);
            this.searchTextBox.Size = new System.Drawing.Size(267, 20);
            this.searchTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.searchTextBox, "Enter the text to search");
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.helpProvider1.SetHelpString(this.matchCaseCheckBox, "Select this checkbox to match the exact case in the search");
            this.matchCaseCheckBox.Location = new System.Drawing.Point(183, 81);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.helpProvider1.SetShowHelp(this.matchCaseCheckBox, true);
            this.matchCaseCheckBox.Size = new System.Drawing.Size(83, 17);
            this.matchCaseCheckBox.TabIndex = 1;
            this.matchCaseCheckBox.Text = "&Match Case";
            this.toolTip1.SetToolTip(this.matchCaseCheckBox, "Select this checkbox to match the exact case in the search");
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(264, 109);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.search.Location = new System.Drawing.Point(183, 109);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "&Search";
            this.search.UseVisualStyleBackColor = true;
            // 
            // phraseRadioButton
            // 
            this.phraseRadioButton.AutoSize = true;
            this.phraseRadioButton.Checked = true;
            this.phraseRadioButton.Location = new System.Drawing.Point(6, 19);
            this.phraseRadioButton.Name = "phraseRadioButton";
            this.phraseRadioButton.Size = new System.Drawing.Size(121, 17);
            this.phraseRadioButton.TabIndex = 4;
            this.phraseRadioButton.TabStop = true;
            this.phraseRadioButton.Text = "Match whole phrase";
            this.phraseRadioButton.UseVisualStyleBackColor = true;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Location = new System.Drawing.Point(6, 42);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(99, 17);
            this.allRadioButton.TabIndex = 4;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "Match all words";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // anyRadioButton3
            // 
            this.anyRadioButton3.AutoSize = true;
            this.anyRadioButton3.Location = new System.Drawing.Point(6, 64);
            this.anyRadioButton3.Name = "anyRadioButton3";
            this.anyRadioButton3.Size = new System.Drawing.Size(101, 17);
            this.anyRadioButton3.TabIndex = 4;
            this.anyRadioButton3.TabStop = true;
            this.anyRadioButton3.Text = "Match any word";
            this.anyRadioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phraseRadioButton);
            this.groupBox1.Controls.Add(this.anyRadioButton3);
            this.groupBox1.Controls.Add(this.allRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Find what";
            // 
            // subFoldersCheckBox
            // 
            this.subFoldersCheckBox.AutoSize = true;
            this.subFoldersCheckBox.Location = new System.Drawing.Point(183, 58);
            this.subFoldersCheckBox.Name = "subFoldersCheckBox";
            this.subFoldersCheckBox.Size = new System.Drawing.Size(125, 17);
            this.subFoldersCheckBox.TabIndex = 1;
            this.subFoldersCheckBox.Text = "&Search in sub folders";
            this.subFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // CryptoEditorPluginSearchForm
            // 
            this.AcceptButton = this.search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(351, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.subFoldersCheckBox);
            this.Controls.Add(this.matchCaseCheckBox);
            this.Controls.Add(this.searchTextBox);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorPluginSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox searchTextBox;
        public System.Windows.Forms.CheckBox matchCaseCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton phraseRadioButton;
        public System.Windows.Forms.RadioButton allRadioButton;
        public System.Windows.Forms.RadioButton anyRadioButton3;
        public System.Windows.Forms.CheckBox subFoldersCheckBox;
    }
}