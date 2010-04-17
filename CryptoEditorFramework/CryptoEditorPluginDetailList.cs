using System;
using System.Reflection;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.FormFramework
{
    public partial class CryptoEditorPluginDetailList<T> : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;

        public CryptoEditorPluginDetailList(ICryptoEditor plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        public virtual ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public virtual void DisplayItem(object item)
        {
            detailListView.Items.Clear();
            BringToFront();

            if (item == null)
            {
                detailListView.Enabled = false;
                return;
            }

            if (detailListView.Columns.Count == 0)
            {
                ColumnHeader col1 = detailListView.Columns.Add("Property");
                col1.Width = 150;

                ColumnHeader col2 = detailListView.Columns.Add("Value");
                col2.Width = 300;
            }

            detailListView.Enabled = true;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object[] attributes = property.GetCustomAttributes(true);
                foreach (Attribute attribute in attributes)
                {
                    if (attribute is CryptoEditorPluginItemAttribute)
                    {
                        CryptoEditorPluginItemAttribute attr = (CryptoEditorPluginItemAttribute) attribute;
                        string valName = (attr.Header.Length > 0) ? attr.Header : property.Name;

                        object val = property.GetValue(item, null);
                        if (val == null)
                            val = "";

                        ListViewItem line = detailListView.Items.Add(valName);
                        line.SubItems.Add(Convert.ToString(val));

                        break;
                    }
                }
            }
        }
    }
}
