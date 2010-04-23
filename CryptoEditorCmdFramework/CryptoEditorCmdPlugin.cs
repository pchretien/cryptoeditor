using System;
using System.Reflection;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.CmdFramework
{
    public class CryptoEditorCmdPlugin<T> : ICryptoEditor
        where T : ICryptoEditorPluginItem
    {
        private CryptoEditorDoc<T> doc;
        private ICryptoEditorView view;
        private ICryptoEditorDetail detail;

        private string encryptionXPath = "/*";
        private bool hasChanged;
        
        public CryptoEditorCmdPlugin()
        {
            view = new CryptoEditorCmdPluginView<T>(this);
            detail = new CryptoEditorCmdPluginDetail<T>(this);
        }

        public string Text { get; set; }

        public virtual void Load(string data)
        {
            // Load the XML document from disk ...
            doc = CryptoEditorDoc<T>.LoadXml(data);
            doc.Name = Text;
        }

        public virtual string Save()
        {
            return doc.GetXml();
        }

        public virtual string EncryptionXPath
        {
            get { return encryptionXPath; }
        }

        public virtual bool HasChanged()
        {
            return hasChanged;
        }

        public virtual void ClearChanges()
        {
            hasChanged = false;
        }

        public virtual void SetChanged()
        {
            hasChanged = true;
        }

        public virtual ICryptoEditorView View
        {
            get { return view; }
            set { view = value; }
        }

        public virtual ICryptoEditorDetail Detail
        {
            get { return detail; }
        }

        public virtual object CreateItem()
        {
            SetChanged();
            return null;
        }

        public virtual object UpdateItem(object itemIn)
        {
            SetChanged();
            CryptoEditorPluginItem item = (CryptoEditorPluginItem)itemIn;
            item.Update();
            return item;
        }

        public virtual bool HasProperties()
        {
            return false;
        }

        public virtual void LoadProperties(string filename)
        {
        }

        public virtual void UpdateProperties(object doc)
        {
        }

        public virtual void SaveProperties()
        {
        }

        public virtual bool IsSearchable()
        {
            return false;
        }

        public virtual object Search(string query, bool matchCase, int searchType, bool searchSubFolders, object doc)
        {
            throw new System.NotImplementedException();
        }

        public virtual bool isPersistent()
        {
            return true;
        }

        public virtual ICryptoEditorDoc GetDoc()
        {
            return doc;
        }

        public ICryptoEditorRootNode RootNode
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
