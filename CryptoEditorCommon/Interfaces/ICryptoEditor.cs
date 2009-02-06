namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditor
    {
        /// <summary>
        /// Sets or gets the name of the plugin.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Called by the CryptoEditor container application. This call initialise the plugin with the data loaded from disk.
        /// </summary>
        /// <param name="data">The data loaded from the disk.</param>
        void Load(string data);

        /// <summary>
        /// Called by the CryptoEditor container application. 
        /// </summary>
        /// <returns>The plugin returns the data to be saved on disk.</returns>
        string Save();

        /// <summary>
        /// Called by the CryptoEditor container application. Returns the XPath of the data to encrypt in the XML document returned by the Save() function. If the data returned by the Save() function is not an XML document, the XPath /* will be used by default.
        /// </summary>
        string EncryptionXPath{ get; }

        /// <summary>
        /// Called by the CryptoEditor container application. Returns true if the data of the plugin has changed. Returns false otherwise.
        /// </summary>
        /// <returns></returns>
        bool HasChanged();
        void SetChanged();
        void ClearChanges();

        /// <summary>
        /// Returns the general view control of the plugin.
        /// </summary>
        ICryptoEditorView View{ get; }

        /// <summary>
        /// Returns the tree view root node of the plugin.
        /// </summary>
        ICryptoEditorRootNode RootNode { get; }

        /// <summary>
        /// Returns the detail view control of the plugin.
        /// </summary>
        ICryptoEditorDetail Detail { get; }

        /// <summary>
        /// Returns a new instance of data item. All Forms and logic required to create a new data item must be located in this function.
        /// </summary>
        /// <returns>The new instance of the data item.</returns>
        object CreateItem(); // The returned object is of type T
        
        /// <summary>
        /// Modify an existing instance of data item. All Forms and logic required to update the existing data item must be located in this function.
        /// </summary>
        /// <param name="itemIn">The data item to be modified.</param>
        /// <returns>The modified data item.</returns>
        object UpdateItem(object itemIn); // Param in and return value of type T

        /// <summary>
        /// Returns weither or not the plugin have properties to load/save/update ...
        /// </summary>
        /// <returns></returns>
        bool HasProperties();

        /// <summary>
        /// Load the properties specific to this plugin.
        /// </summary>
        /// <param name="filename">Fullpath of the properties file ... if any.</param>
        void LoadProperties(string filename);

        /// <summary>
        /// Change the properties of the plugin. It is the responsability of the plugin to display a specific edition UI.
        /// </summary>
        void UpdateProperties();

        /// <summary>
        /// Save the plugin properties to the disk.
        /// </summary>
        void SaveProperties();

        /// <summary>
        /// Return true if the plugin contains Searchable fields.
        /// </summary>
        /// <returns></returns>
        bool IsSearchable();

        /// <summary>
        /// Search specific words in the plugin Items.
        /// </summary>
        /// <param name="query"></param>
        object Search(string query, bool matchCase, int searchType, bool searchSubFolders, object doc);

        bool isPersistent();
    }
}
