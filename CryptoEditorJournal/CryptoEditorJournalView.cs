using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Journal
{
    public class CryptoEditorJournalView : CryptoEditorPluginView<CryptoEditorJournalItem>
    {
        public CryptoEditorJournalView(ICryptoEditor plugin)
            : base(plugin, true, true)
        {
        }

        protected override string FormatValue(object propertyVal, CryptoEditorPluginItemAttribute attr)
        {
            string val = "";

            if (propertyVal is DateTime)
            {
                DateTime dateTime = (DateTime)propertyVal;

                val += string.Format("{0:0000}/", dateTime.Year);
                val += string.Format("{0:00}/", dateTime.Month);
                val += string.Format("{0:00} ", dateTime.Day);
                val += string.Format("{0:00}:", dateTime.Hour);
                val += string.Format("{0:00}", dateTime.Minute);
            }
            else if (propertyVal is double)
            {
                val = string.Format("{0:00.00}", (double)propertyVal);
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
