namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditorView
    {
        /// <summary>
        /// Returns a reference to the parent plugin.
        /// </summary>
        ICryptoEditor Plugin { get; }

        /// <summary>
        /// Display the list of data items of the current node.
        /// </summary>
        /// <param name="doc"></param>
        void DisplayView( object doc ); // object is of type CryptoEditorDoc<T>

        /// <summary>
        /// Remove the items that have been cut&pasted from the original ListView.
        /// </summary>
        void ClearCut(bool isCut);
    }
}
