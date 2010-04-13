using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.CmdFramework
{
    public class CryptoEditorCmdPluginView<T> : ICryptoEditorView
        where T : ICryptoEditorPluginItem
    {
        private CryptoEditorDoc<T> doc = null;
        private ICryptoEditor plugin = null;

        private CryptoEditorDoc<T> originalDoc = null;
        private ArrayList originalItems = null;

        public CryptoEditorCmdPluginView(ICryptoEditor plugin)
        {
            this.plugin = plugin;
        }

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayView(object docIn)
        {
            if (docIn != null)
                doc = (CryptoEditorDoc<T>)docIn;

            if (doc == null)
                return;

            foreach(CryptoEditorDoc<T> folder in doc.Folders)
            {
                if(folder.Active)
                    Console.WriteLine(folder.Name);
            }

            foreach (T item in doc.GetItems())
            {
                if (item.Active)
                {
                    WriteItem(item);
                    Console.WriteLine("");
                }
            }
        }

        public void ClearCut(bool isCut)
        {
            throw new NotImplementedException();
        }

        private void WriteItem(object itemIn)
        {
            // List of values from the item to display in the listview
            List<ItemCollection> list = new List<ItemCollection>();

            // Reflection to find the properties to display
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object[] attributes = property.GetCustomAttributes(typeof(CryptoEditorPluginItemAttribute), true);
                foreach (Attribute attribute in attributes)
                {
                    if (attribute is CryptoEditorPluginItemAttribute)
                    {
                        CryptoEditorPluginItemAttribute attr = (CryptoEditorPluginItemAttribute)attribute;
                        if (attr.Rank > -1)
                        {
                            string val = "";
                            if (itemIn != null)
                                val = (string)property.GetValue(itemIn, null);
                            if (val == null)
                                val = "";
                            val = val.Replace("\n", " ");
                            val = val.Replace("\r", " ");
                            while (val.IndexOf("  ") > -1)
                                val = val.Replace("  ", " ");
                            list.Add(new ItemCollection(property.Name, attr, val));
                        }
                    }
                }
            }

            // Sort the values by their column rank as defined in the CryptoEditorPluginItemAttribute
            list.Sort(new ItemCollectionComparer());

            if (itemIn == null)
                return;

            //for (int i = 0; i < list.Count; i++)
            //    Console.Write(list[i].Value);
            Console.Write(list[0].Value);
        }

        class ItemCollection
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
    }
}
