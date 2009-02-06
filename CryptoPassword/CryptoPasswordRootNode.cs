using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Password
{
    public class CryptoPasswordRootNode : CryptoEditor.Framework.CryptoEditorPluginRootNode<CryptoPasswordItem>
    {
        public CryptoPasswordRootNode(ICryptoEditor plugin, string name) 
            : base(plugin, name)
        {
            //ToolStripMenuItem item = new ToolStripMenuItem();
            //item.Name = "HideShowPassword_Click";
            //item.Size = new System.Drawing.Size(154, 22);
            //item.Text = "Hide/Show Password";
            //item.Click += HideShowPassword_Click;

            //AddMenuItem(new ToolStripSeparator());
            //AddMenuItem(item);
        }

        public void HideShowPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HideShowPassword_Click");
        }
    }
}
