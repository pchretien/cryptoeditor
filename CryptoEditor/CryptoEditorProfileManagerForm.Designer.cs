namespace CryptoEditor
{
    partial class CryptoEditorProfileManagerForm
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
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.profilesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider.SetHelpString(this.add, "Create a new profile to protect your sensitive data.");
            this.add.Location = new System.Drawing.Point(340, 41);
            this.add.Name = "add";
            this.helpProvider.SetShowHelp(this.add, true);
            this.add.Size = new System.Drawing.Size(86, 23);
            this.add.TabIndex = 2;
            this.add.Text = "&Add User";
            this.toolTip.SetToolTip(this.add, "Create a new profile to protect your sensitive data.");
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.Enabled = false;
            this.helpProvider.SetHelpString(this.delete, "Delete an existing profile.");
            this.delete.Location = new System.Drawing.Point(340, 70);
            this.delete.Name = "delete";
            this.helpProvider.SetShowHelp(this.delete, true);
            this.delete.Size = new System.Drawing.Size(86, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "&Delete User";
            this.toolTip.SetToolTip(this.delete, "Delete an existing profile.");
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // open
            // 
            this.open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.open.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.open.Enabled = false;
            this.helpProvider.SetHelpString(this.open, "Open CryptoEditor with the selected profile.");
            this.open.Location = new System.Drawing.Point(340, 12);
            this.open.Name = "open";
            this.helpProvider.SetShowHelp(this.open, true);
            this.open.Size = new System.Drawing.Size(86, 23);
            this.open.TabIndex = 1;
            this.open.Text = "&Open";
            this.toolTip.SetToolTip(this.open, "Open CryptoEditor with the selected profile.");
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(340, 209);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(86, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // profilesListView
            // 
            this.profilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.profilesListView.FullRowSelect = true;
            this.helpProvider.SetHelpString(this.profilesListView, "This is the list of all available profiles. Pick the one with your name or alias " +
                    "or create a new profile.");
            this.profilesListView.Location = new System.Drawing.Point(12, 12);
            this.profilesListView.MultiSelect = false;
            this.profilesListView.Name = "profilesListView";
            this.helpProvider.SetShowHelp(this.profilesListView, true);
            this.profilesListView.Size = new System.Drawing.Size(322, 220);
            this.profilesListView.TabIndex = 0;
            this.toolTip.SetToolTip(this.profilesListView, "This is the list of all available profiles. Pick the one with \r\nyour name or alia" +
                    "s or create a new profile.");
            this.profilesListView.UseCompatibleStateImageBehavior = false;
            this.profilesListView.View = System.Windows.Forms.View.Details;
            this.profilesListView.SelectedIndexChanged += new System.EventHandler(this.profilesListView_SelectedIndexChanged);
            this.profilesListView.DoubleClick += new System.EventHandler(this.profilesListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Email";
            this.columnHeader2.Width = 125;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 20;
            // 
            // CryptoEditorProfileManagerForm
            // 
            this.AcceptButton = this.open;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(438, 245);
            this.Controls.Add(this.profilesListView);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.open);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorProfileManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Manager";
            this.Load += new System.EventHandler(this.CryptoEditorProfileManagerForm_Load);
            this.Shown += new System.EventHandler(this.CryptoEditorProfileManagerForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListView profilesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}