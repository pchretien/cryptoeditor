namespace CryptoTimeSheet
{
    partial class CryptoEditorTimeSheetReportForm
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
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.folderCheck = new System.Windows.Forms.CheckBox();
            this.totalsCheck = new System.Windows.Forms.CheckBox();
            this.delimiter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(49, 13);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(200, 20);
            this.fromDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(49, 42);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(49, 42);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(200, 20);
            this.toDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(174, 149);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // generate
            // 
            this.generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generate.Location = new System.Drawing.Point(93, 149);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 2;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // folderCheck
            // 
            this.folderCheck.AutoSize = true;
            this.folderCheck.Location = new System.Drawing.Point(49, 68);
            this.folderCheck.Name = "folderCheck";
            this.folderCheck.Size = new System.Drawing.Size(112, 17);
            this.folderCheck.TabIndex = 4;
            this.folderCheck.Text = "Display total hours";
            this.folderCheck.UseVisualStyleBackColor = true;
            // 
            // totalsCheck
            // 
            this.totalsCheck.AutoSize = true;
            this.totalsCheck.Location = new System.Drawing.Point(49, 91);
            this.totalsCheck.Name = "totalsCheck";
            this.totalsCheck.Size = new System.Drawing.Size(158, 17);
            this.totalsCheck.TabIndex = 4;
            this.totalsCheck.Text = "Display recursive total hours";
            this.totalsCheck.UseVisualStyleBackColor = true;
            // 
            // delimiter
            // 
            this.delimiter.FormattingEnabled = true;
            this.delimiter.Items.AddRange(new object[] {
            ";",
            ",",
            "[tab]"});
            this.delimiter.Location = new System.Drawing.Point(49, 115);
            this.delimiter.Name = "delimiter";
            this.delimiter.Size = new System.Drawing.Size(46, 21);
            this.delimiter.TabIndex = 5;
            this.delimiter.Text = "[tab]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Delimiter character";
            // 
            // CryptoEditorTimeSheetReportForm
            // 
            this.AcceptButton = this.generate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(263, 184);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.delimiter);
            this.Controls.Add(this.totalsCheck);
            this.Controls.Add(this.folderCheck);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorTimeSheetReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timesheet report generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.CheckBox folderCheck;
        private System.Windows.Forms.CheckBox totalsCheck;
        private System.Windows.Forms.ComboBox delimiter;
        private System.Windows.Forms.Label label4;
    }
}