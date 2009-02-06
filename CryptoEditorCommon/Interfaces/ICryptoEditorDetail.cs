namespace CryptoEditor.Common.Interfaces
{
    public interface ICryptoEditorDetail
    {
        /// <summary>
        /// Returns a reference to the parent plugin.
        /// </summary>
        ICryptoEditor Plugin { get; }

        /// <summary>
        /// Display a data item in the detail view control.
        /// </summary>
        /// <param name="item">The data item to be displayed.</param>
        void DisplayItem(object item);
    }
}
