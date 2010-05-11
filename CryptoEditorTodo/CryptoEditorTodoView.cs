using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Todo
{
    public class CryptoEditorTodoView : CryptoEditorPluginView<CryptoEditorTodoItem>
    {
        public CryptoEditorTodoView(ICryptoEditor plugin)
            : base(plugin, false, false)
        {
        }

        protected override void CustomizeItem(object itemIn, ListViewItem listItem)
        {
            CryptoEditorTodoItem item = (CryptoEditorTodoItem) itemIn;
            switch(item.Status)
            {
                case 0:
                    listItem.ForeColor = Color.Blue;
                    break;
                case 1:
                    listItem.ForeColor = Color.Green;
                    break;
                case 2:
                    listItem.ForeColor = Color.Red;
                    break;
            }
        }

        protected override string FormatValue(object propertyVal, CryptoEditorPluginItemAttribute attr)
        {
            string val = "";

            if (propertyVal is DateTime)
            {
                DateTime dateTime = (DateTime)propertyVal;

                val += string.Format("{0:0000}/", dateTime.Year);
                val += string.Format("{0:00}/", dateTime.Month);
                val += string.Format("{0:00}", dateTime.Day);
            }
            else if (propertyVal is double)
            {
                val = string.Format("{0:00.00}", (double)propertyVal);
            }
            else if (propertyVal is int && attr.Header.ToLower().Equals("priority"))
            {
                switch ((int)propertyVal)
                {
                    case 0:
                        val = "0 - Verry Low";
                        break;
                    case 1:
                        val = "1 - Low";
                        break;
                    case 2:
                        val = "2 - Normal";
                        break;
                    case 3:
                        val = "3 - High";
                        break;
                    case 4:
                        val = "4 - Urgent";
                        break;
                }
            }
            else if (propertyVal is int && attr.Header.ToLower().Equals("status"))
            {
                switch ((int)propertyVal)
                {
                    case 0:
                        val = "0 - Pending";
                        break;
                    case 1:
                        val = "1 - Open";
                        break;
                    case 2:
                        val = "2 - Close";
                        break;
                }
            }
            else
            {
                val = Convert.ToString(propertyVal);
                val = val.Replace("\n", " ");
                val = val.Replace("\r", " ");
                while (val.IndexOf("  ") > -1)
                    val = val.Replace("  ", " ");
            }

            return val;
        }
    }
}
