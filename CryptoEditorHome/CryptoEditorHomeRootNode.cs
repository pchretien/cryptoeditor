using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditorHome
{
    public class CryptoEditorHomeRootNode : TreeNode, ICryptoEditorRootNode
    {
        private ICryptoEditor plugin = null;

        public CryptoEditorHomeRootNode(ICryptoEditor plugin, string newName)
            : base(newName)
        {
            this.plugin = plugin;
        }

        #region ICryptoEditorRootNode Members

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void OnSelect()
        {
            Plugin.View.DisplayView(null);
        }

        public void DragOver(object sender, DragEventArgs e)
        {
        }

        public void DragEnter(object sender, DragEventArgs e)
        {
        }

        public void DragDrop(object sender, DragEventArgs e)
        {
        }

        public void ItemDrag(object sender, ItemDragEventArgs e)
        {
        }

        #endregion

        #region ICryptoEditorRootNode Members


        public void ClearCut(bool isCut)
        {
        }

        #endregion
    }
}
