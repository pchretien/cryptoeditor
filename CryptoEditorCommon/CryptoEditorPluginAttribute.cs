using System;

namespace CryptoEditor.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class CryptoEditorPluginAttribute : Attribute
    {
        private string text = null;

        public CryptoEditorPluginAttribute()
        {
        }

        public CryptoEditorPluginAttribute(string textIn)
        {
            Text = textIn;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
