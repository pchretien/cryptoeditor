using System;
using CryptoEditor.Common;

namespace CryptoEditorBookmark
{
    [Serializable]
    public class CryptoEditorBookmarkItem : CryptoEditorPluginItem
    {
        public CryptoEditorBookmarkItem()
        {
        }

        public CryptoEditorBookmarkItem(string title, string url, string note)
        {
            Title = title;
            Url = url;
            Note = note;
        }

        private string title = "";
        [CryptoEditorPluginItem(0, Header = "Title", Width = 100, Searchable = true)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string url = "";
        [CryptoEditorPluginItem(1, Header = "Url", Width = 400, Searchable = true)]
        public string Url
        {
            get { return url; }
            set { url = value; }
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
