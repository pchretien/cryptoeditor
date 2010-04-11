using System;
using System.Xml.Serialization;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Common
{
    [Serializable]
    public class CryptoEditorPluginItem : ICryptoEditorPluginItem
    {
        private DateTime lastUpdate;
        private Guid id;
        private bool active;

        public static bool Sarializing = false;

        public CryptoEditorPluginItem()
        {
            lastUpdate = DateTime.Now;
            id = Guid.NewGuid();
            Active = true;
        }

        [XmlAttribute("lastupdate")]
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        [XmlAttribute("item_id")]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
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
    }
}
