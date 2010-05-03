namespace CryptoEditor.CreditCard
{
    partial class CryptoEditorCreditCardDetails
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
            this.month = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.verification = new System.Windows.Forms.TextBox();
            this.year = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.creditcard = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // month
            // 
            this.month.Enabled = false;
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
            this.month.Location = new System.Drawing.Point(198, 100);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(82, 21);
            this.month.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Month";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Year";
            // 
            // verification
            // 
            this.verification.Location = new System.Drawing.Point(198, 57);
            this.verification.Name = "verification";
            this.verification.ReadOnly = true;
            this.verification.Size = new System.Drawing.Size(178, 20);
            this.verification.TabIndex = 5;
            // 
            // year
            // 
            this.year.Enabled = false;
            this.year.FormattingEnabled = true;
            this.year.IntegralHeight = false;
            this.year.Location = new System.Drawing.Point(287, 100);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(82, 21);
            this.year.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Verification Number";
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(198, 16);
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Size = new System.Drawing.Size(178, 20);
            this.number.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Card Number";
            // 
            // notes
            // 
            this.notes.AcceptsReturn = true;
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.Location = new System.Drawing.Point(3, 186);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notes.Size = new System.Drawing.Size(465, 163);
            this.notes.TabIndex = 8;
            this.notes.Validated += new System.EventHandler(this.notes_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Notes";
            // 
            // company
            // 
            this.company.Location = new System.Drawing.Point(3, 139);
            this.company.Name = "company";
            this.company.ReadOnly = true;
            this.company.Size = new System.Drawing.Size(166, 20);
            this.company.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Card Company / Bank";
            // 
            // name2
            // 
            this.name2.Location = new System.Drawing.Point(3, 100);
            this.name2.Name = "name2";
            this.name2.ReadOnly = true;
            this.name2.Size = new System.Drawing.Size(166, 20);
            this.name2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Second Card Holder";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(3, 57);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(166, 20);
            this.name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Card Holder Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Card";
            // 
            // creditcard
            // 
            this.creditcard.Enabled = false;
            this.creditcard.FormattingEnabled = true;
            this.creditcard.Items.AddRange(new object[] {
            "Visa",
            "Master Card",
            "American Express"});
            this.creditcard.Location = new System.Drawing.Point(3, 16);
            this.creditcard.Name = "creditcard";
            this.creditcard.Size = new System.Drawing.Size(166, 21);
            this.creditcard.TabIndex = 0;
            // 
            // CryptoEditorCreditCardDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.month);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.verification);
            this.Controls.Add(this.year);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.number);
            this.Controls.Add(this.label7);
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
            this.Name = "CryptoEditorCreditCardDetails";
            this.Size = new System.Drawing.Size(471, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox verification;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox notes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox company;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox creditcard;
    }
}
