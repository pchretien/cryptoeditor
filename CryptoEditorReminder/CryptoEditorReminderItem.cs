using System;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common;

namespace CryptoEditor.Reminder
{
    [Serializable]
    public class CryptoEditorReminderItem : CryptoEditorPluginItem
    {
        private string subject = "";
        [CryptoEditorPluginItem(1, Header = "Subject", Width = 200)]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private DateTime date;
        [CryptoEditorPluginItem(0, Header = "When", Width = 100)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private int status = 0;
        [CryptoEditorPluginItem(Header = "Status", Width = 100)]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string note = "";
        [CryptoEditorPluginItem(Header = "Notes", Width = 400, Searchable = true)]
        public string Note
        {
            get
            {
                if (!Serializing)
                    return note;

                // Note: This could be a function in the framework
                string ret = note.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Serializing)
                {
                    note = value;
                    return;
                }

                // Note: This could be a function in the framework
                string input = value.Replace("{{N}}", "\n");
                input = input.Replace("{{R}}", "\r");

                note = input;
            }
        }
    }
}
