using System;
using System.Reflection;
using CryptoEditor.Common;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.FormFramework
{
    public class CryptoEditorPlugin<T> : ICryptoEditor
        where T : ICryptoEditorPluginItem
    {
        private string text = "Plugin";
        private string encryptionXPath = "/*";
        protected ICryptoEditorView view;
        protected ICryptoEditorDetail detail;

        private CryptoEditorDoc<T> doc = null;
        protected CryptoEditorPluginRootNode<T> rootNode;

        private bool hasChanged = false;

        public CryptoEditorPlugin()
        {
            rootNode = new CryptoEditorPluginRootNode<T>(this, Text);
            view = new CryptoEditorPluginView<T>(this);
            detail = new CryptoEditorPluginDetail<T>(this);
        }

        public CryptoEditorDoc<T> Doc
        {
            get { return doc; }
        }

        public virtual string Text
        {
            get { return text; }
            set
            {
                text = value;
                rootNode.Text = value;
            }
        }

        public virtual void Load(string data)
        {
            try
            {
                CryptoEditorPluginItem.Sarializing = true;
                
                // Clear existing nodes ...
                rootNode.Nodes.Clear();

                // Load the XML document from disk ...
                doc = CryptoEditorDoc<T>.LoadXml(data);
                doc.Name = Text;

                rootNode.Name = Text;
                rootNode.Doc = doc;

                // Build the tree view
                rootNode.LoadFolder(doc);

                /// TODO: Pas tres tres elegant comme fix ...
                if (rootNode.TreeView != null &&
                    rootNode.TreeView.SelectedNode is CryptoEditorPluginRootNode<T>)
                {
                    CryptoEditorPluginRootNode<T> node = (CryptoEditorPluginRootNode<T>)rootNode.TreeView.SelectedNode;
                    View.DisplayView(node.Doc);
                }

                ClearChanges();
            }
            finally
            {
                CryptoEditorPluginItem.Sarializing = false;
            }
        }

        public virtual string Save()
        {
            string ret = "";
            try
            {
                CryptoEditorPluginItem.Sarializing = true;
                ret = Doc.GetXml();
            }
            finally
            {
                CryptoEditorPluginItem.Sarializing = false;
            }

            return ret;
        }

        public virtual string EncryptionXPath
        {
            get { return encryptionXPath; }
        }

        public virtual ICryptoEditorView View
        {
            get { return view; }
            set { view = value; }
        }

        public virtual ICryptoEditorRootNode RootNode
        {
            get { return rootNode; }
            set { rootNode = (CryptoEditorPluginRootNode<T>)value; }
        }

        public ICryptoEditorDetail Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public virtual object CreateItem()
        {
            SetChanged();
            return null;
        }

        public virtual object UpdateItem( object itemIn )
        {
            SetChanged();
            CryptoEditorPluginItem item = (CryptoEditorPluginItem) itemIn;
            item.Update();
            return item;
        }

        public virtual bool HasChanged()
        {
            return hasChanged;
        }

        public void ClearChanges()
        {
            hasChanged = false;
        }

        public void SetChanged()
        {
            hasChanged = true;
        }

        public virtual bool HasProperties()
        {
            return false;
        }

        public virtual void LoadProperties(string filename)
        {
        }

        public virtual void UpdateProperties()
        {
        }

        public virtual void SaveProperties()
        {
        }

        public virtual bool IsSearchable()
        {
            return false;
        }

        /*
         if (form.phraseRadioButton.Checked)
                searchType = 1;
            if (form.allRadioButton.Checked)
                searchType = 2;
            if (form.anyRadioButton3.Checked)
                searchType = 3;
         */
        public virtual object Search(string query, bool matchCase, int searchType, bool searchSubFolders, object docIn)
        {
            CryptoEditorDoc<T> docSearch = doc;
            if( docIn != null && docIn is CryptoEditorDoc<T>)
                docSearch = (CryptoEditorDoc<T>)docIn;

            // Reflection to find the properties to display
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            CryptoEditorDoc<T> resultDoc = new CryptoEditorDoc<T>("__SEARCH_RESULT__");
            SearchFolder(query, matchCase, searchType, searchSubFolders, docSearch, properties, resultDoc);

            return resultDoc;
        }

        private void SearchFolder(string query, 
            bool matchCase,
            int searchType,
            bool searchSubFolders, 
            CryptoEditorDoc<T> docIn, 
            PropertyInfo[] properties,
            CryptoEditorDoc<T> resultDoc)
        {
            if (searchSubFolders)
            {
                foreach (CryptoEditorDoc<T> folder in docIn.GetFolders())
                {
                    SearchFolder(query, matchCase, searchType, searchSubFolders, folder, properties, resultDoc);
                }
            }

            foreach (T itemIn in docIn.GetItems())
            {
                char[] sep = { ' ','\t','\r','\n'};
                string[] tokens = query.Split(sep);

                if(searchType == 1)
                {
                    tokens = new string[1];
                    tokens[0] = query;
                }

                int foundall = 0;
                bool stopSearchingThisItem = false;
                foreach (string token in tokens)
                {
                    if (stopSearchingThisItem)
                        break;
                    
                    bool stopSearchingThisToken = false;
                    foreach (PropertyInfo property in properties)
                    {
                        if(stopSearchingThisToken)
                            break;

                        bool searcheable = false;
                        object[] attributes = property.GetCustomAttributes(typeof (CryptoEditorPluginItemAttribute), true);
                        foreach (Attribute attribute in attributes)
                        {
                            if (attribute is CryptoEditorPluginItemAttribute)
                            {
                                CryptoEditorPluginItemAttribute attr = (CryptoEditorPluginItemAttribute) attribute;
                                if (attr.Searchable)
                                {
                                    searcheable = true;
                                    break;
                                }
                            }
                        }

                        if(!searcheable)
                            continue;

                        string val = "";
                        if (itemIn != null)
                            val = (string) property.GetValue(itemIn, null);
                        if (val == null)
                            val = "";

                        if (matchCase && val.IndexOf(token) > -1)
                        {
                            foundall++;
                            stopSearchingThisToken = true;
                        }

                        if (!matchCase && val.ToLower().IndexOf(token.ToLower()) > -1)
                        {
                            foundall++;
                            stopSearchingThisToken = true;
                        }

                        if( (searchType == 3 && foundall > 0) ||
                            ((searchType == 1 || searchType == 2) && foundall == tokens.Length) )
                        {
                            resultDoc.AddItem(itemIn);
                            stopSearchingThisItem = true;
                            break;
                        }
                    }
                }
            }
        }

        public virtual bool isPersistent()
        {
            return true;
        }

        public ICryptoEditorDoc GetDoc()
        {
            return doc;
        }
    }
}
