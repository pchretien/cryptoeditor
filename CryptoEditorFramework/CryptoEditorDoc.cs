using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CryptoEditor.Common.Interfaces;
using System.Xml;

namespace CryptoEditor.Framework
{
    [Serializable]
    [XmlRoot("CryptoEditorDoc")]
    public class CryptoEditorDoc<T> : ICloneable
        where T : ICryptoEditorPluginItem
    {
        private string name = "";
        private Guid id;
        private DateTime lastUpdate;
        private List<T> items = null;
        private List<CryptoEditorDoc<T>> folders = null;

        private bool active;

        public CryptoEditorDoc()
        {
            id = Guid.NewGuid();
            items = new List<T>();
            folders = new List<CryptoEditorDoc<T>>();
            Active = true;

            Update();
        }

        public CryptoEditorDoc( string name)
        {
            Name = name;
            id = Guid.NewGuid();
            items = new List<T>();
            folders = new List<CryptoEditorDoc<T>>();
            Active = true;

            Update();
        }

        public List<T> GetItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            //Items.Remove(item);
            item.Active = false;
            item.Update();
        }

        public List<CryptoEditorDoc<T>> GetFolders()
        {
            return Folders;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlArrayItem("Item")]
        public List<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        [XmlArrayItem("Folder")]
        public List<CryptoEditorDoc<T>> Folders
        {
            get { return folders; }
            set { folders = value; }
        }

        [XmlAttribute("folder_id")]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        [XmlAttribute("lastupdate")]
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        [XmlAttribute("active")]
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public void Update()
        {
            LastUpdate = DateTime.Now;
        }

        public string GetXml()
        {
            Type[] types = new Type[3];
            types[0] = typeof(T);
            types[1] = typeof (List<T>);
            types[2] = typeof (List<CryptoEditorDoc<T>>);
            XmlSerializer serializer = new XmlSerializer(typeof(CryptoEditorDoc<T>), types);
            
            TextWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter, this);

            string ret = textWriter.ToString();
            return ret;
        }

        public static CryptoEditorDoc<T> LoadXml(string xml)
        {
            if(xml==null)
                return new CryptoEditorDoc<T>();

            Type[] types = new Type[3];
            types[0] = typeof(T);
            types[1] = typeof(List<T>);
            types[2] = typeof(List<CryptoEditorDoc<T>>);
            XmlSerializer serializer = new XmlSerializer(typeof(CryptoEditorDoc<T>), types);

            TextReader textReader = new StringReader(xml);
            return (CryptoEditorDoc<T>)serializer.Deserialize(textReader);
        }

        public CryptoEditorDoc<T> AddFolder(string nameIn)
        {
            CryptoEditorDoc<T> folder = new CryptoEditorDoc<T>(nameIn);
            Folders.Add(folder);

            return folder;
        }

        public CryptoEditorDoc<T> AddFolder(CryptoEditorDoc<T> folder)
        {
            Folders.Add(folder);

            return folder;
        }

        public void RemoveFolder(CryptoEditorDoc<T> doc)
        {
            //Folders.Remove(doc);
            doc.Active = false;
            doc.Update();
        }

        public void AddItem(T item)
        {
            Items.Add(item);
        }

        public object Clone()
        {
            // Working with Xml avoids the implementation of the ICloneable interface 
            // in all the document childs
            string XmlDoc = GetXml();
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XmlDoc);
            XmlNodeList nodeIds = doc.SelectNodes("//@item_id | //@folder_id");
            foreach (XmlNode node in nodeIds)
                node.InnerText = System.Guid.NewGuid().ToString();

            return CryptoEditorDoc<T>.LoadXml(doc.OuterXml);
        }
    }
}
