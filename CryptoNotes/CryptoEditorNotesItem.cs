using System;
using CryptoEditor.Common;

namespace CryptoNotes
{
    [Serializable]
    public class CryptoEditorNotesItem : CryptoEditorPluginItem
    {
        public CryptoEditorNotesItem()
        {
        }

        public CryptoEditorNotesItem(string title, string note)
        {
            Title = title;
            Note = note;
        }

        private string title = "";
        [CryptoEditorPluginItem(0, Header = "Title", Width = 100)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string note = "";
        [CryptoEditorPluginItem(1, Header="Note", Width=400)]
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
