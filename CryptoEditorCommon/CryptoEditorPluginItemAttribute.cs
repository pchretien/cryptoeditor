using System;

namespace CryptoEditor.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=true, Inherited=true)]
    public class CryptoEditorPluginItemAttribute : Attribute
    {
        private int rank = -1;
        private string header = null;
        private int width = 200;
        private bool searchable = false;

        public CryptoEditorPluginItemAttribute()
        {
        }

        public CryptoEditorPluginItemAttribute(int rank)
        {
            Rank = rank;
        }

        public CryptoEditorPluginItemAttribute(int rank, string header)
        {
            Rank = rank;
            Header = header;
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public bool Searchable
        {
            get { return searchable; }
            set { searchable = value; }
        }
    }
}
