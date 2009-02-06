using System;
using System.Xml.Serialization;

namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditorPluginItem
    {
        DateTime LastUpdate { get; set; }
        Guid Id { get; set; }
        bool Active{ get; set; }
        void Update();
    }
}