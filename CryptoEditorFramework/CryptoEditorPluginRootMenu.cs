using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.FormFramework
{
    public class CryptoEditorPluginRootMenu<T> : ContextMenuStrip
        where T : ICryptoEditorPluginItem
    {
        private CryptoEditorPluginRootNode<T> parent = null;

        ToolStripMenuItem clearFolderToolStripMenuItem = null;
        ToolStripMenuItem newFolderToolStripMenuItem = null;
        ToolStripMenuItem renFolderToolStripMenuItem = null;
        ToolStripMenuItem deleteFolderToolStripMenuItem = null;
        ToolStripMenuItem cutFolderToolStripMenuItem = null;
        ToolStripMenuItem copyFolderToolStripMenuItem = null;
        ToolStripMenuItem pasteFolderToolStripMenuItem = null;
        ToolStripMenuItem searchFolderToolStripMenuItem = null;
        ToolStripMenuItem propertiesFolderToolStripMenuItem = null;
        ToolStripSeparator separator1 = new ToolStripSeparator();
        ToolStripSeparator separator2 = new ToolStripSeparator();
        ToolStripSeparator separator3 = new ToolStripSeparator();

        public CryptoEditorPluginRootMenu(CryptoEditorPluginRootNode<T> parentIn)
        {
            parent = parentIn;

            clearFolderToolStripMenuItem = new ToolStripMenuItem();
            clearFolderToolStripMenuItem.Name = "clearFolderToolStripMenuItem";
            clearFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            clearFolderToolStripMenuItem.Text = "Clear Results";
            clearFolderToolStripMenuItem.ShortcutKeys = Keys.Delete;
            clearFolderToolStripMenuItem.ShowShortcutKeys = true;
            clearFolderToolStripMenuItem.Click += parent.clearFolderToolStripMenuItem_Click;

            newFolderToolStripMenuItem = new ToolStripMenuItem();
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            newFolderToolStripMenuItem.Text = "New Group ...";
            newFolderToolStripMenuItem.ShortcutKeys = Keys.Insert;
            newFolderToolStripMenuItem.ShowShortcutKeys = true;
            newFolderToolStripMenuItem.Click += parent.newFolderToolStripMenuItem_Click;

            renFolderToolStripMenuItem = new ToolStripMenuItem();
            renFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
            renFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            renFolderToolStripMenuItem.Text = "Rename Group ...";
            renFolderToolStripMenuItem.ShortcutKeys = Keys.F2;
            renFolderToolStripMenuItem.ShowShortcutKeys = true;
            renFolderToolStripMenuItem.Click += parent.renFolderToolStripMenuItem_Click;

            deleteFolderToolStripMenuItem = new ToolStripMenuItem();
            deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            deleteFolderToolStripMenuItem.Text = "Delete Group ...";
            deleteFolderToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteFolderToolStripMenuItem.ShowShortcutKeys = true;
            deleteFolderToolStripMenuItem.Click += parent.deleteFolderToolStripMenuItem_Click;

            cutFolderToolStripMenuItem = new ToolStripMenuItem();
            cutFolderToolStripMenuItem.Name = "cutFolderToolStripMenuItem";
            cutFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            cutFolderToolStripMenuItem.Text = "Cut";
            cutFolderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutFolderToolStripMenuItem.ShowShortcutKeys = true;
            cutFolderToolStripMenuItem.Click += parent.cutFolderToolStripMenuItem_Click;

            copyFolderToolStripMenuItem = new ToolStripMenuItem();
            copyFolderToolStripMenuItem.Name = "copyFolderToolStripMenuItem";
            copyFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            copyFolderToolStripMenuItem.Text = "Copy";
            copyFolderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyFolderToolStripMenuItem.ShowShortcutKeys = true;
            copyFolderToolStripMenuItem.Click += parent.copyFolderToolStripMenuItem_Click;

            pasteFolderToolStripMenuItem = new ToolStripMenuItem();
            pasteFolderToolStripMenuItem.Name = "pasteFolderToolStripMenuItem";
            pasteFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            pasteFolderToolStripMenuItem.Text = "Paste";
            pasteFolderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteFolderToolStripMenuItem.ShowShortcutKeys = true;
            pasteFolderToolStripMenuItem.Click += parent.pasteFolderToolStripMenuItem_Click;

            searchFolderToolStripMenuItem = new ToolStripMenuItem();
            searchFolderToolStripMenuItem.Name = "searchFolderToolStripMenuItem";
            searchFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            searchFolderToolStripMenuItem.Text = "Search ...";
            searchFolderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            searchFolderToolStripMenuItem.ShowShortcutKeys = true;
            searchFolderToolStripMenuItem.Click += parent.searchFolderToolStripMenuItem_Click;
            
            propertiesFolderToolStripMenuItem = new ToolStripMenuItem();
            propertiesFolderToolStripMenuItem.Name = "propertiesFolderToolStripMenuItem";
            propertiesFolderToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            propertiesFolderToolStripMenuItem.Text = "Properties ...";
            propertiesFolderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            propertiesFolderToolStripMenuItem.ShowShortcutKeys = true;
            propertiesFolderToolStripMenuItem.Click += parent.propertiesFolderToolStripMenuItem_Click;
            
            Name = "rootContextMenu";
            Size = new System.Drawing.Size(155, 48);
            Items.AddRange(new ToolStripItem[] { clearFolderToolStripMenuItem,
                newFolderToolStripMenuItem, 
                renFolderToolStripMenuItem, 
                deleteFolderToolStripMenuItem, 
                separator1,
                cutFolderToolStripMenuItem,
                copyFolderToolStripMenuItem,
                pasteFolderToolStripMenuItem,
                separator2,
                searchFolderToolStripMenuItem,
                separator3,
                propertiesFolderToolStripMenuItem});

            Opening += this.contextMenuStrip1_Opening;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // DEFAULTS
            clearFolderToolStripMenuItem.Visible = false;
            newFolderToolStripMenuItem.Visible = true;
            renFolderToolStripMenuItem.Visible = true;
            deleteFolderToolStripMenuItem.Visible = true;
            separator1.Visible = true;
            cutFolderToolStripMenuItem.Visible = true;
            copyFolderToolStripMenuItem.Visible = true;
            pasteFolderToolStripMenuItem.Visible = true;
            separator2.Visible = true;
            searchFolderToolStripMenuItem.Visible = true;
            separator3.Visible = true;
            propertiesFolderToolStripMenuItem.Visible = true;

            propertiesFolderToolStripMenuItem.Enabled = true;

            // SEATCH RESULTS FOLDER
            if (parent.Doc.Name.Equals("__SEARCH_RESULT__"))
            {
                clearFolderToolStripMenuItem.Visible = true;
                newFolderToolStripMenuItem.Visible = false;
                renFolderToolStripMenuItem.Visible = false;
                deleteFolderToolStripMenuItem.Visible = false;
                separator1.Visible = false;
                cutFolderToolStripMenuItem.Visible = false;
                copyFolderToolStripMenuItem.Visible = false;
                pasteFolderToolStripMenuItem.Visible = false;
                separator2.Visible = false;
                searchFolderToolStripMenuItem.Visible = false;
                separator3.Visible = false;
                propertiesFolderToolStripMenuItem.Visible = false;

                return;
            }

            // PROPERTIES
            if (!parent.Plugin.HasProperties())
            {
                propertiesFolderToolStripMenuItem.Enabled = false;
            }

            // SEARCHABLE
            if (!parent.Plugin.IsSearchable())
            {
                searchFolderToolStripMenuItem.Enabled = false;
            }
        }
    }
}
