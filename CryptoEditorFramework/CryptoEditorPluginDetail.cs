using System;
using System.Reflection;
using System.Windows.Forms;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Framework
{
    public partial class CryptoEditorPluginDetail<T> : UserControl, ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;

        public CryptoEditorPluginDetail(ICryptoEditor plugin)
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
            detailTextBox.Text = "";
            BringToFront();

            if (item == null)
            {
                detailTextBox.Enabled = false;
                return;
            }

            detailTextBox.Enabled = true;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach( PropertyInfo property in properties)
            {
                object val = property.GetValue(item, null);
                if (val == null)
                    val = "";

                detailTextBox.Text += property.Name + " = ";
                detailTextBox.Text += val.ToString();
                detailTextBox.Text += "\n";
            }
        }
    }
}
