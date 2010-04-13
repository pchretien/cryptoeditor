using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.FormFramework;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Password
{
    public class CryptoPasswordView : CryptoEditorPluginView<CryptoPasswordItem>
    {
        public CryptoPasswordView(ICryptoEditor plugin)
            : base(plugin)
        {
        }

        public override void DisplayView(object docIn)
        {
            base.DisplayView(docIn);

            CryptoPassword parent = (CryptoPassword) Plugin;
            if (!parent.Properties.ShowPasswords)
            {
                // To do this we had to make the ListView protected ...
                base.listView.Columns[2].Width = 0;
                base.listView.Refresh();
            }
        }
    }
}
