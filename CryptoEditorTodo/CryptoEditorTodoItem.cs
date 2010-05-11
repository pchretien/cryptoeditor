using System;
using CryptoEditor.Common;

namespace CryptoEditor.Todo
{
    [Serializable]
    public class CryptoEditorTodoItem : CryptoEditorPluginItem
    {
        public CryptoEditorTodoItem()
        {
        }

        public CryptoEditorTodoItem(string title, int priority, DateTime date, int status, string note)
        {
            Title = title;
            Priority = priority;
            Date = date;
            Status = status;
            Note = note;
        }

        private string title = "";
        [CryptoEditorPluginItem(1, Header = "Title", Width = 100, Searchable = true)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int priority = 0;
        [CryptoEditorPluginItem(2, Header = "Priority", Width = 100, Searchable = true)]
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private DateTime date;
        [CryptoEditorPluginItem(0, Header = "Date", Width = 100)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private int status = 0;
        [CryptoEditorPluginItem(3, Header = "Status", Width = 100, Searchable = true)]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string note = "";
        [CryptoEditorPluginItem(Header = "Note", Width = 400, Searchable = true)]
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
