namespace CryptoEditor.FormFramework
{
    partial class CryptoEditorPluginDetailList<T>
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
            this.detailListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // detailListView
            // 
            this.detailListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailListView.Location = new System.Drawing.Point(0, 0);
            this.detailListView.Name = "detailListView";
            this.detailListView.Size = new System.Drawing.Size(356, 206);
            this.detailListView.TabIndex = 0;
            this.detailListView.UseCompatibleStateImageBehavior = false;
            this.detailListView.View = System.Windows.Forms.View.Details;
            // 
            // CryptoEditorPluginDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailListView);
            this.Name = "CryptoEditorPluginDetailList";
            this.Size = new System.Drawing.Size(356, 206);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView detailListView;


    }
}
