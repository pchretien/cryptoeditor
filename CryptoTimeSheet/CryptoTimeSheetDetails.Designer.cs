namespace CryptoTimeSheet
{
    partial class CryptoTimeSheetDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.TextBox();
            this.hours = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Task Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hours";
            // 
            // notes
            // 
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.BackColor = System.Drawing.SystemColors.Window;
            this.notes.Location = new System.Drawing.Point(2, 103);
            this.notes.Multiline = true;
            this.notes.Name = "notes";
            this.notes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notes.Size = new System.Drawing.Size(402, 129);
            this.notes.TabIndex = 3;
            this.notes.WordWrap = false;
            this.notes.Validated += new System.EventHandler(this.notes_Validated);
            // 
            // hours
            // 
            this.hours.BackColor = System.Drawing.SystemColors.Window;
            this.hours.Location = new System.Drawing.Point(142, 16);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(100, 20);
            this.hours.TabIndex = 1;
            this.hours.Validated += new System.EventHandler(this.hours_Validated);
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.name.BackColor = System.Drawing.SystemColors.Window;
            this.name.Location = new System.Drawing.Point(2, 61);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(402, 20);
            this.name.TabIndex = 2;
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.SystemColors.Window;
            this.time.Location = new System.Drawing.Point(2, 16);
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Size = new System.Drawing.Size(134, 20);
            this.time.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Notes";
            // 
            // CryptoTimeSheetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.hours);
            this.Controls.Add(this.name);
            this.Name = "CryptoTimeSheetDetails";
            this.Size = new System.Drawing.Size(407, 235);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox notes;
        private System.Windows.Forms.TextBox hours;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label4;
    }
}
