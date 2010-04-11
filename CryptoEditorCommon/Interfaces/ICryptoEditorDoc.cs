using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditorDoc
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        ICryptoEditorDoc GetFolder(string folderName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        ICryptoEditorPluginItem GetItem(string itemName);
    }
}
