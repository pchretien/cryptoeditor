using System.Windows.Forms;

namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditorRootNode
    {
        /// <summary>
        /// Returns a reference to the parent plugin.
        /// </summary>
        ICryptoEditor Plugin { get; }

        /// <summary>
        /// Called by the CryptoEditor container application. 
        /// This function is called when the tree view node is selected.
        /// </summary>
        void OnSelect();

        void DragOver(object sender, DragEventArgs e);
        void DragEnter(object sender, DragEventArgs e);
        void DragDrop(object sender, DragEventArgs e);
        void ItemDrag(object sender, ItemDragEventArgs e);

        /// <summary>
        /// Clear the folder that has been cut&pasted
        /// </summary>
        void ClearCut(bool isCut);
    }
}
