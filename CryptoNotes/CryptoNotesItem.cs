using System;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common;
using CryptoEditor.FormFramework;

namespace CryptoEditor.Notes
{
    [Serializable]
    public class CryptoNotesItem : CryptoEditorPluginItem
    {
        private string title = "";
        private string subject = "";
        private string author = "";
        private string keywords = "";
        private string comments = "";
        private string notes = "";

        [CryptoEditorPluginItem(Searchable = true)]
        public string Notes
        {
            get
            {
                if (!Sarializing)
                    return notes;

                // Note: This could be a function in the framework
                string ret = notes.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Sarializing)
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

        [CryptoEditorPluginItem(0, Width = 150, Searchable = true)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [CryptoEditorPluginItem(1, Width = 150, Searchable = true)]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        [CryptoEditorPluginItem(2, Width = 150, Searchable = true)]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        [CryptoEditorPluginItem(Searchable = true)]
        public string Keywords
        {
            get
            {
                if (!Sarializing)
                    return keywords;

                // Note: This could be a function in the framework
                string ret = keywords.Replace("\n", "{{N}}");
                ret = ret.Replace("\r", "{{R}}");

                return ret;
            }
            set
            {
                if (!Sarializing)
                {
                    keywords = value;
                    return;
                }

                // Note: This could be a function in the framework
                string input = value.Replace("{{N}}", "\n");
                input = input.Replace("{{R}}", "\r");

                keywords = input;
            }
        }

        [CryptoEditorPluginItem(2, Width = 200, Searchable = true)]
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
