using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CryptoEditor.Common.Interfaces;

namespace CryptoEditor.Framework
{
    [Serializable]
    public class CryptoEditorClipboardItem<T>
        where T : ICryptoEditorPluginItem
    {
        public readonly bool IsCut = false;
        public readonly ArrayList NewItems;
        
        public CryptoEditorClipboardItem(ArrayList newItems, bool isCut)
        {
            IsCut = isCut;
            NewItems = newItems;
        }
    }

    [Serializable]
    public class CryptoEditorClipboardFolder<T>
        where T : ICryptoEditorPluginItem
    {
        public readonly bool IsCut = false;
        public readonly CryptoEditorDoc<T> NewFolder;

        public CryptoEditorClipboardFolder(CryptoEditorDoc<T> newFolder, bool isCut)
        {
            IsCut = isCut;
            NewFolder = newFolder;
        }
    }
}
