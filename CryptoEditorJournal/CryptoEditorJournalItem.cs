using System;
using CryptoEditor.Common;

namespace CryptoEditor.Journal
{
    [Serializable]
    public class CryptoEditorJournalItem : CryptoEditorPluginItem
    {
        public CryptoEditorJournalItem()
        {
        }

        public CryptoEditorJournalItem(DateTime date, string title, string text)
        {
            Date = date;
            Title = title;
            Text = text;
        }

        private DateTime date;
        [CryptoEditorPluginItem(0, Header = "Date", Width = 100)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string title = "";
        [CryptoEditorPluginItem(1, Header = "Title", Width = 250, Searchable = true)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string notes = "";
        [CryptoEditorPluginItem(Header = "Text", Searchable = true)]
        public string Text
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
