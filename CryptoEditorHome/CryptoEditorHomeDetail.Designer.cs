namespace CryptoEditorHome
{
    partial class CryptoEditorHomeDetail
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
#if !MONO_MWF
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.webBrowserBuffer = new System.Windows.Forms.WebBrowser();
#endif
            
            this.SuspendLayout();

#if !MONO_MWF
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(396, 243);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // webBrowserBuffer
            // 
            this.webBrowserBuffer.Location = new System.Drawing.Point(332, 96);
            this.webBrowserBuffer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBuffer.Name = "webBrowserBuffer";
            this.webBrowserBuffer.Size = new System.Drawing.Size(20, 20);
            this.webBrowserBuffer.TabIndex = 2;
            this.webBrowserBuffer.Visible = false;
            this.webBrowserBuffer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserBuffer_DocumentCompleted);
#endif
            // 
            // CryptoEditorHomeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

#if !MONO_MWF
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.webBrowserBuffer);
#endif

            this.Name = "CryptoEditorHomeDetail";
            this.Size = new System.Drawing.Size(396, 243);
            this.ResumeLayout(false);

        }

        #endregion
#if !MONO_MWF
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.WebBrowser webBrowserBuffer;
#endif
    }
}
