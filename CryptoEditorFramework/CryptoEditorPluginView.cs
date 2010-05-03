using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.FormFramework
{
    public partial class CryptoEditorPluginView<T> : UserControl, ICryptoEditorView
        where T : ICryptoEditorPluginItem
    {
        private CryptoEditorDoc<T> doc = null;
        private ICryptoEditor plugin = null;

        private CryptoEditorDoc<T> originalDoc = null;
        private ArrayList originalItems = null;

        private bool groupBy = false;
        private int lastColumnClicked = 0;
        private Color lastSelectedColor = Color.Empty;
        
        public CryptoEditorPluginView(ICryptoEditor plugin, bool GroupBy)
        {
            InitializeComponent();
            this.plugin = plugin;
            this.groupBy = GroupBy;
        }

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayView(object docIn)
        {
            listView.Clear();
            
            if (docIn != null)
                doc = (CryptoEditorDoc<T>)docIn;

            AddItem(null); // Display columns names ...

            if(doc == null)
                return;

            foreach (T item in doc.GetItems())
            {
                if(item.Active)
                    AddItem(item);
            }

            if (this.groupBy)
            {
                bool gray = true;
                string lastVal = "";
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    if (!listView.Items[i].Text.Equals(lastVal))
                    {
                        lastVal = listView.Items[i].Text;
                        gray = !gray;
                    }

                    if (gray)
                        listView.Items[i].BackColor = Color.Cyan;
                }
            }

            Plugin.Detail.DisplayItem(null);
            BringToFront();
        }

        public void AddMenuItem(ToolStripItem item)
        {
            contextMenuStrip1.Items.Add(item);
        }

        private void AddItem(object itemIn)
        {
            // List of values from the item to display in the listview
            List<ItemCollection> list = new List<ItemCollection>();

            // Reflection to find the properties to display
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                object[] attributes = property.GetCustomAttributes(typeof (CryptoEditorPluginItemAttribute), true);
                foreach(Attribute attribute in attributes)
                {
                    if(attribute is CryptoEditorPluginItemAttribute)
                    {
                        CryptoEditorPluginItemAttribute attr = (CryptoEditorPluginItemAttribute) attribute;
                        if (attr.Rank > -1)
                        {
                            string val = "";
                            if (itemIn != null)
                            {
                                object propertyVal = property.GetValue(itemIn, null);
                                val = FormatValue(propertyVal, attr);
                            }
                            
                            if (val == null)
                                val = "";
                            
                            list.Add(new ItemCollection(property.Name, attr, val));
                        }
                    }
                }
            }

            // Sort the values by their column rank as defined in the CryptoEditorPluginItemAttribute
            list.Sort(new ItemCollectionComparer());

            if (listView.Columns.Count == 0)
            {
                for(int i=0; i<list.Count; i++)
                {
                    ColumnHeader col;
                    if (list[i].Attr.Header != null)
                    {
                        col = listView.Columns.Add(list[i].Attr.Header);
                    }
                    else
                    {
                        col = listView.Columns.Add(list[i].Name);
                    }

                    col.Width = list[i].Attr.Width;
                }
            }

            if( list.Count != listView.Columns.Count )
                throw new Exception("Invalid number of values for that item!");

            if (itemIn == null)
                return;

            ListViewItem listItem = listView.Items.Add(list[0].Value);
            listItem.Tag = itemIn;

            for (int i = 1; i < list.Count; i++)
            {
                listItem.SubItems.Add(list[i].Value);
            }
        }

        protected virtual string FormatValue(object propertyVal, CryptoEditorPluginItemAttribute attr)
        {
            string val = Convert.ToString(propertyVal);
            val = val.Replace("\n", " ");
            val = val.Replace("\r", " ");
            while (val.IndexOf("  ") > -1)
                val = val.Replace("  ", " ");

            return val;
        }

        protected class ItemCollection
        {
            public readonly string Name = null;
            public readonly string Value = null;
            public readonly CryptoEditorPluginItemAttribute Attr = null;

            public ItemCollection(string name, CryptoEditorPluginItemAttribute attr, string item)
            {
                Name = name;
                Attr = attr;
                Value = item;
            }
        }

        class ItemCollectionComparer : IComparer<ItemCollection>
        {
            public int Compare(ItemCollection x, ItemCollection y)
            {
                return x.Attr.Rank.CompareTo(y.Attr.Rank);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( listView.SelectedItems.Count > 0 )
                Plugin.Detail.DisplayItem( listView.SelectedItems[0].Tag);
            else
                Plugin.Detail.DisplayItem(null);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListView list = (ListView) sender;
            ListViewItem selected = list.SelectedItems[0];

            // From here we must forward the call to the plugin ...
            selected.Tag = Plugin.UpdateItem(selected.Tag);
            int index = selected.Index;
            
            // Refresh
            DisplayView(doc);
            Plugin.Detail.DisplayItem(selected.Tag);

            listView.Items[index].Selected = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            ListViewItem selected = listView.SelectedItems[0];
            int index = selected.Index;

            // From here we must forward the call to the plugin ...
            selected.Tag = Plugin.UpdateItem(selected.Tag);
            
            // Refresh
            DisplayView(doc);
            Plugin.Detail.DisplayItem(selected.Tag);

            listView.Items[index].Selected = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;
            
            if(MessageBox.Show("You are about to delete on or more items. Are you sure you want to delete these items?", "Deleting Items", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            int index = listView.SelectedItems[0].Index;
            foreach (ListViewItem selected in listView.SelectedItems)
            {
                // From here we must forward the call to the plugin ...
                T item = (T) selected.Tag;
                doc.RemoveItem(item);
            }

            // Refresh
            DisplayView(doc);

            if (listView.Items.Count > 0)
            {
                if (index >= listView.Items.Count)
                    index = listView.Items.Count - 1;

                listView.Items[index].Selected = true;
                
                if (listView.SelectedItems.Count > 0)
                    Plugin.Detail.DisplayItem(listView.SelectedItems[0].Tag);
            }

            Plugin.SetChanged();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object item = Plugin.CreateItem();
            if( item != null )
            {
                doc.AddItem((T)item);
                DisplayView(doc);
                
                Plugin.SetChanged();
            }
        }

        private void InternalCopy(object sender, EventArgs e, bool cut)
        {
            originalDoc = doc;
            originalItems = new ArrayList();

            ArrayList newItems = new ArrayList();
            foreach (ListViewItem selected in listView.SelectedItems)
            {
                // From here we must forward the call to the plugin ...
                T item = (T)selected.Tag;

                originalItems.Add(item);

                // Serialize ... Passing by an Xml serialization avoids implementing ICloneable
                // for client Items 
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter textWriter = new StringWriter();
                serializer.Serialize(textWriter, item);
                string serializedItem = textWriter.ToString();

                // Deserialize
                TextReader textReader = new StringReader(serializedItem);
                T newItem = (T)serializer.Deserialize(textReader);

                // Copy the new object to the draganddrop buffer
                newItem.Id = System.Guid.NewGuid();

                newItems.Add(newItem);
            }

            CryptoEditorClipboardItem<T> items = new CryptoEditorClipboardItem<T>(newItems, cut);
            Clipboard.SetData(DataFormats.Serializable, items);
            
            return;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternalCopy(sender, e, false);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CryptoEditorClipboardItem<T> items = (CryptoEditorClipboardItem<T>) Clipboard.GetData(DataFormats.Serializable);
            if( items == null )
                return;

            foreach (T newItem in items.NewItems)
            {
                if (newItem != null)
                {
                    doc.AddItem(newItem);
                }
            }

            Plugin.View.ClearCut(items.IsCut);
            Clipboard.Clear();

            DisplayView(doc);
            Plugin.SetChanged();
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            originalDoc = doc;
            originalItems = new ArrayList();

            ArrayList newItems = new ArrayList();
            foreach (ListViewItem selected in listView.SelectedItems)
            {
                // From here we must forward the call to the plugin ...
                T item = (T)selected.Tag;

                originalItems.Add(item);

                // Serialize ... Passing by an Xml serialization avoids implementing ICloneable
                // for client Items 
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter textWriter = new StringWriter();
                serializer.Serialize(textWriter, item);
                string serializedItem = textWriter.ToString();

                // Deserialize
                TextReader textReader = new StringReader(serializedItem);
                T newItem = (T)serializer.Deserialize(textReader);

                // Copy the new object to the draganddrop buffer
                newItem.Id = System.Guid.NewGuid();

                newItems.Add(newItem);
            }

            CryptoEditorClipboardItem<T> items = new CryptoEditorClipboardItem<T>(newItems, false);
            DoDragDrop(items, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void listView_DragOver(object sender, DragEventArgs e)
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

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy || e.Effect == DragDropEffects.Move)
            {
                if (e.Data.GetDataPresent(typeof (ArrayList)))
                {
                    CryptoEditorClipboardItem<T> items = (CryptoEditorClipboardItem<T>)Clipboard.GetData(DataFormats.Serializable);
                    if (items == null)
                        return;

                    foreach (T newItem in items.NewItems)
                    {
                        if (newItem != null)
                        {
                            doc.AddItem(newItem);
                        }
                    }

                    if(e.Effect == DragDropEffects.Move)
                    {
                        // Remove the original data ...
                        Plugin.View.ClearCut(true);
                    }

                    Plugin.View.DisplayView(doc);
                    Plugin.SetChanged();
                }
            }

            return;
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ListView list = (ListView)sender;

                if(list.SelectedItems.Count == 0)
                    return;

                ListViewItem selected = list.SelectedItems[0];
                int index = selected.Index;

                // From here we must forward the call to the plugin ...
                selected.Tag = Plugin.UpdateItem(selected.Tag);

                // Refresh
                DisplayView(doc);
                Plugin.Detail.DisplayItem(selected.Tag);

                list.Items[index].Selected = true;
            }
            else if(e.KeyCode == Keys.Escape)
            {
                // Clear Cut buffer ...
                Clipboard.Clear();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternalCopy(sender, e, true);
        }

        public virtual void ClearCut(bool isCut)
        {
            if (originalDoc != null && originalItems != null)
            {
                if (isCut)
                {
                    foreach (T item in originalItems)
                        originalDoc.RemoveItem(item);
                }

                originalDoc = null;
                originalItems = null;
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != lastColumnClicked)
            {
                listView.Sorting = SortOrder.Ascending;
                listView.ListViewItemSorter = new ListViewItemComparer(e.Column);
                return;
            }

            listView.Sorting = listView.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        }

        private void listView_Leave(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count > 0)
            {
                lastSelectedColor = listView.SelectedItems[0].BackColor;
                listView.SelectedItems[0].BackColor = Color.LightGray;
            }
        }

        private void listView_Enter(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems[0].BackColor = lastSelectedColor;
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.UpdateProperties(doc);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Plugin.HasProperties())
            {
                propertiesToolStripMenuItem.Enabled = false;
                return;
            }

            propertiesToolStripMenuItem.Enabled = true;
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        private bool desc = false;

        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public ListViewItemComparer(int column, bool descending)
        {
            desc = descending;
            col = column;
        }
        public int Compare(object x, object y)
        {
            int ret = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            // Ascending or descending
            if (desc) ret *= -1;

            return ret;
        }
    }
}
