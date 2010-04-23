using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.FormFramework
{
    public class CryptoEditorPluginRootNode<T> : TreeNode, ICryptoEditorRootNode
        where T : ICryptoEditorPluginItem
    {
        private ICryptoEditor plugin = null;
        private CryptoEditorDoc<T> doc = null;
        private CryptoEditorPluginRootMenu<T> rootMenu = null;

        private static CryptoEditorPluginRootNode<T> originalFolderToDelete = null;
        
        public CryptoEditorPluginRootNode(ICryptoEditor plugin, string newName)
            : base(newName)
        {
            this.plugin = plugin;
            Initialize();
        }

        public virtual void Initialize()
        {
            rootMenu = new CryptoEditorPluginRootMenu<T>(this);
            ContextMenuStrip = rootMenu;
        }

        public virtual ICryptoEditor Plugin
        {
            get
            {
                return plugin;
            }
        }

        public virtual CryptoEditorDoc<T> Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        public void AddMenuItem( ToolStripItem item)
        {
            rootMenu.Items.Add(item);
        }

        internal virtual void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CryptoEditorPluginRootNodeNameForm form  = new CryptoEditorPluginRootNodeNameForm();
            form.folderNameTextBox.Text = "";

            if( form.ShowDialog() != DialogResult.OK)
                return;

            string newName = form.folderNameTextBox.Text;
            CryptoEditorDoc<T> docItem = Doc.AddFolder(newName);
            
            CryptoEditorPluginRootNode<T> node = new CryptoEditorPluginRootNode<T>(plugin, newName);
            node.Doc = docItem;

            Nodes.Add(node);
            Expand();

            Plugin.SetChanged();
            return;
        }

        internal virtual void renFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parent == null)
            {
                MessageBox.Show("You can not rename the root folder!", "Rename Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CryptoEditorPluginRootNodeNameForm form = new CryptoEditorPluginRootNodeNameForm();
            form.folderNameTextBox.Text = Text;

            if (form.ShowDialog() != DialogResult.OK)
                return;

            Text = form.folderNameTextBox.Text;
            Doc.Name = form.folderNameTextBox.Text;
            Doc.Update();

            Plugin.SetChanged();
            return;
        }

        internal virtual void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMe(true);
        }

        internal virtual void clearFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMe(false);
        }

        private void DeleteMe(bool confirm)
        {
            if (Parent == null)
            {
                if (confirm)
                    MessageBox.Show("You can not delete the root folder!", "Delete Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (confirm && MessageBox.Show("Do you want to delete folder " + Text + "?", "Delete Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            ((CryptoEditorPluginRootNode<T>)Parent).Doc.RemoveFolder(Doc);
            Remove();

            Plugin.SetChanged();
            return;
        }
        
        internal virtual void copyFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternalCopy(sender, e, false);
        }

        internal virtual void cutFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternalCopy(sender, e, true);
        }

        private void InternalCopy(object sender, EventArgs e, bool isCut)
        {
            originalFolderToDelete = this;

            CryptoEditorDoc<T> o = (CryptoEditorDoc<T>)Doc.Clone();
            CryptoEditorClipboardFolder<T> folder = new CryptoEditorClipboardFolder<T>(o, isCut);
            Clipboard.SetData(DataFormats.Serializable, folder);
            return;
            
        }

        internal virtual void propertiesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.UpdateProperties(doc);
        }

        internal virtual void searchFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "";

            CryptoEditorPluginSearchForm form = new CryptoEditorPluginSearchForm();
            form.subFoldersCheckBox.Checked = true;

            if(form.ShowDialog() != DialogResult.OK)
                return;
            
            int searchType = 0;
            if (form.phraseRadioButton.Checked)
                searchType = 1;
            if (form.allRadioButton.Checked)
                searchType = 2;
            if (form.anyRadioButton3.Checked)
                searchType = 3;

            query = form.searchTextBox.Text;
            CryptoEditorDoc<T> resultDoc = (CryptoEditorDoc<T>)Plugin.Search(
                query, 
                form.matchCaseCheckBox.Checked, 
                searchType, 
                form.subFoldersCheckBox.Checked,
                Doc);

            if(resultDoc.GetItems().Count == 0)
            {
                MessageBox.Show("No result found for '" + query + "'", 
                    "No result found", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            CryptoEditorPluginRootNode<T> node = new CryptoEditorPluginRootNode<T>(plugin, "Search Result '"+query+" '");
            node.Doc = resultDoc;
            node.ForeColor = Color.Red;

            Nodes.Add(node);
            Expand();

            Plugin.SetChanged();
            return;
        }

        internal virtual void pasteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object clipboardObject = Clipboard.GetData(DataFormats.Serializable);
            if (clipboardObject is CryptoEditorClipboardFolder<T>)
            {
                CryptoEditorClipboardFolder<T> folder =
                    (CryptoEditorClipboardFolder<T>) Clipboard.GetData(DataFormats.Serializable);
                if (folder != null)
                {
                    Doc.AddFolder(folder.NewFolder);

                    CryptoEditorPluginRootNode<T> node =
                        new CryptoEditorPluginRootNode<T>(plugin, folder.NewFolder.Name);
                    node.Doc = folder.NewFolder;

                    // Should add all child folders ...
                    //Nodes.Add(node);
                    LoadFolder(Doc);

                    Expand();

                    Plugin.RootNode.ClearCut(folder.IsCut);
                    Clipboard.Clear();

                    Plugin.SetChanged();
                    return;
                }
            }

            if (clipboardObject is CryptoEditorClipboardItem<T>)
            {
                CryptoEditorClipboardItem<T> items =
                    (CryptoEditorClipboardItem<T>) Clipboard.GetData(DataFormats.Serializable);
                if (items != null)
                {
                    foreach (T item in items.NewItems)
                    {
                        if (item != null)
                        {
                            doc.AddItem(item);
                        }
                    }

                    Plugin.View.ClearCut(items.IsCut);
                    Clipboard.Clear();

                    plugin.View.DisplayView(doc);
                    Plugin.SetChanged();

                    return;
                }
            }

            Clipboard.Clear();

            return;
        }

        public virtual void OnSelect()
        {
            plugin.View.DisplayView( doc );
        }

        public void LoadFolder(CryptoEditorDoc<T> parentDoc)
        {
            this.Nodes.Clear();
            LoadFolder(parentDoc, this);
        }

        private void LoadFolder(CryptoEditorDoc<T> parentDoc, CryptoEditorPluginRootNode<T> node)
        {
            foreach (CryptoEditorDoc<T> docIn in parentDoc.GetFolders())
            {
                if (!docIn.Active)
                    continue;

                CryptoEditorPluginRootNode<T> newNode = new CryptoEditorPluginRootNode<T>(node.Plugin, docIn.Name);
                newNode.Doc = docIn;
                node.Nodes.Add(newNode);
                LoadFolder(docIn, newNode);
            }
        }

        public virtual void DragOver(object sender, DragEventArgs e)
        {
            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;

            }
            else if ((e.KeyState & 32) == 32 &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {

                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;

            }
            else if ((e.KeyState & 4) == 4 &&
              (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {

                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;

            }
            else if ((e.KeyState & 8) == 8 &&
              (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {

                // CTL KeyState for copy.
                e.Effect = DragDropEffects.Copy;

            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            }
            else
                e.Effect = DragDropEffects.None;

            return;
        }

        public virtual void DragEnter(object sender, DragEventArgs e)
        {
            return;
        }

        public virtual void DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy || e.Effect == DragDropEffects.Move)
            {
                if (e.Data.GetDataPresent(typeof (CryptoEditorClipboardFolder<T>)))
                {
                    // This is a folder ...
                    CryptoEditorClipboardFolder<T> folder =
                        (CryptoEditorClipboardFolder<T>) e.Data.GetData(typeof (CryptoEditorClipboardFolder<T>));

                    Doc.AddFolder(folder.NewFolder);

                    CryptoEditorPluginRootNode<T> node =
                        new CryptoEditorPluginRootNode<T>(plugin, folder.NewFolder.Name);
                    node.Doc = folder.NewFolder;

                    LoadFolder(Doc);
                    Expand();

                    if (e.Effect == DragDropEffects.Move)
                        Plugin.RootNode.ClearCut(true);

                    Plugin.SetChanged();
                }
                else if (e.Data.GetDataPresent(typeof (CryptoEditorClipboardItem<T>)))
                {
                    // This is an item ...
                    CryptoEditorClipboardItem<T> items =
                        (CryptoEditorClipboardItem<T>) e.Data.GetData(typeof (CryptoEditorClipboardItem<T>));
                    foreach (T item in items.NewItems)
                    {
                        if (item != null)
                        {
                            // Insert the item in the folder
                            Doc.AddItem(item);
                        }
                    }

                    if (e.Effect == DragDropEffects.Move)
                        Plugin.View.ClearCut(true);

                    Plugin.View.DisplayView(doc);
                    Plugin.SetChanged();
                }
            }

            return;
        }

        public void ItemDrag(object sender, ItemDragEventArgs e)
        {
            originalFolderToDelete = this;

            CryptoEditorDoc<T> newDoc = (CryptoEditorDoc<T>)Doc.Clone();
            CryptoEditorClipboardFolder<T> folder = new CryptoEditorClipboardFolder<T>(newDoc, false);
            
            System.Windows.Forms.TreeView treeView = (System.Windows.Forms.TreeView)sender;
            treeView.DoDragDrop(folder, DragDropEffects.Move | DragDropEffects.Copy);

            return;
        }

        public void ClearCut(bool isCut)
        {
            if (originalFolderToDelete != null)
            {
                if (isCut)
                {
                    originalFolderToDelete.DeleteMe(false);
                }

                originalFolderToDelete = null;
            }
        }
    }
}
