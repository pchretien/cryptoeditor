using System;
using CryptoEditor.Common;

namespace CryptoTimeSheet
{
    [Serializable]
    public class CryptoEditorTimeSheetItem : CryptoEditorPluginItem
    {
        public CryptoEditorTimeSheetItem()
        {
        }

        public CryptoEditorTimeSheetItem( DateTime time, string name, double hours, string notes)
        {
            this.time = time;
            this.name = name;
            this.hours = hours;
            this.notes = notes;
        }

        private DateTime time;
        [CryptoEditorPluginItem(0, Header = "Date", Width = 100)]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private string name = "";
        [CryptoEditorPluginItem(1, Header = "Task name", Width = 250, Searchable = true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double hours;
        [CryptoEditorPluginItem(2, Header = "Hours", Width = 50)]
        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        private string notes = "";
        [CryptoEditorPluginItem(Header = "Notes", Width = 400, Searchable = true)]
        public string Notes
        {
            get
            {
                if (!Serializing)
                    return notes;

                // Note: This could be a function in the framework
                string ret = notes.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Serializing)
                {
                    notes = value;
                    return;
                }

                // Note: This could be a function in the framework
                string input = value.Replace("{{N}}", "\n");
                input = input.Replace("{{R}}", "\r");

                notes = input;
            }
        }
    }
}
