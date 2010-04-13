using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.CmdFramework
{
    public class CryptoEditorCmdPluginDetail<T> : ICryptoEditorDetail
    {
        private ICryptoEditor plugin = null;

        public CryptoEditorCmdPluginDetail(ICryptoEditor plugin)
        {
            this.plugin = plugin;
        }

        public ICryptoEditor Plugin
        {
            get { return plugin; }
        }

        public void DisplayItem(object item)
        {
            if (item == null)
                return;
            
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object val = property.GetValue(item, null);
                if (val == null)
                    val = "";

                Console.WriteLine(property.Name + " = " + val.ToString());
            }
        }
    }
}
