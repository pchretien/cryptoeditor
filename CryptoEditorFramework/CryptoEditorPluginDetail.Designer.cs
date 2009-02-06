using System.Windows.Forms;

namespace CryptoEditor.Framework
{
    partial class CryptoEditorPluginDetail<T>
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
            this.detailTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // detailTextBox
            // 
            this.detailTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTextBox.Location = new System.Drawing.Point(0, 0);
            this.detailTextBox.Name = "detailTextBox";
            this.detailTextBox.Size = new System.Drawing.Size(407, 203);
            this.detailTextBox.TabIndex = 0;
            this.detailTextBox.Text = "";
            // 
            // CryptoEditorPluginDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailTextBox);
            this.Name = "CryptoEditorPluginDetail";
            this.Size = new System.Drawing.Size(407, 203);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox detailTextBox;

    }
}
