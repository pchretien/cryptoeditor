namespace CryptoEditor.CreditCard
{
    partial class CryptoEditorCreditCardForm
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
            this.creditcard = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.verification = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.TextBox();
            this.year = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.month = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // creditcard
            // 
            this.creditcard.FormattingEnabled = true;
            this.creditcard.Items.AddRange(new object[] {
            "Visa",
            "Master Card",
            "American Express"});
            this.creditcard.Location = new System.Drawing.Point(12, 25);
            this.creditcard.Name = "creditcard";
            this.creditcard.Size = new System.Drawing.Size(166, 21);
            this.creditcard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Card";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Card Holder Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(12, 66);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(166, 20);
            this.name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Card Company / Bank";
            // 
            // company
            // 
            this.company.Location = new System.Drawing.Point(12, 148);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(166, 20);
            this.company.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Notes";
            // 
            // notes
            // 
            this.notes.AcceptsReturn = true;
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.Location = new System.Drawing.Point(12, 195);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notes.Size = new System.Drawing.Size(373, 62);
            this.notes.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(310, 269);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(229, 269);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Card Number";
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(207, 25);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(178, 20);
            this.number.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Verification Number";
            // 
            // verification
            // 
            this.verification.Location = new System.Drawing.Point(207, 66);
            this.verification.Name = "verification";
            this.verification.Size = new System.Drawing.Size(178, 20);
            this.verification.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Second Card Holder";
            // 
            // name2
            // 
            this.name2.Location = new System.Drawing.Point(12, 109);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(166, 20);
            this.name2.TabIndex = 2;
            // 
            // year
            // 
            this.year.FormattingEnabled = true;
            this.year.IntegralHeight = false;
            this.year.Location = new System.Drawing.Point(296, 109);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(82, 21);
            this.year.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Month";
            // 
            // month
            // 
            this.month.FormattingEnabled = true;
            this.month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.month.Location = new System.Drawing.Point(207, 109);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(82, 21);
            this.month.TabIndex = 6;
            // 
            // CryptoEditorCreditCardForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(397, 300);
            this.Controls.Add(this.month);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.verification);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.number);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.company);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.creditcard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CryptoEditorCreditCardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox creditcard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox company;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox notes;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox verification;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox month;
    }
}