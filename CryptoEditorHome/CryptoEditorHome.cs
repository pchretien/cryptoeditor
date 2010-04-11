using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;
using CryptoEditorHome;

namespace CryptoEditorHome
{
    [CryptoEditorPlugin("CryptoEditorHome")]
    public class CryptoEditorHome : ICryptoEditor
    {
        private CryptoEditorHomeRootNode root = null;
        private CryptoEditorHomeView view = null;
        private CryptoEditorHomeDetail detail = null;

        public CryptoEditorHome()
        {
            root = new CryptoEditorHomeRootNode(this, Text);
            view = new CryptoEditorHomeView(this);
            detail = new CryptoEditorHomeDetail(this);
        }

        public string Text
        {
            get
            {
                return "Home";
            }
            set
            {
            }
        }

        public void Load(string data)
        {
        }

        public string Save()
        {
            return null;
        }

        public string EncryptionXPath
        {
            get { return "/"; }
        }

        public bool HasChanged()
        {
            return false;
        }

        public void SetChanged()
        {
        }

        public ICryptoEditorView View
        {
            get { return view; }
        }

        public ICryptoEditorRootNode RootNode
        {
            get { return root; }
        }

        public ICryptoEditorDetail Detail
        {
            get { return detail; }
        }

        public object CreateItem()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object UpdateItem(object itemIn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ClearChanges()
        {
        }

        public bool HasProperties()
        {
            return false;
        }

        public void LoadProperties(string filename)
        {
        }

        public void UpdateProperties()
        {
        }

        public void SaveProperties()
        {
        }

        public object Search(string query, bool matchCase, int searchType, bool searchSubFolders, object doc)
        {
            return null;
        }

        public bool IsSearchable()
        {
            return false;
        }

        public bool isPersistent()
        {
            return false;
        }

        public ICryptoEditorDoc GetDoc()
        {
            throw new NotImplementedException();
        }

        public void GoTo(string destination)
        {
            MessageBox.Show("Goto ...");
        }
    }
}
