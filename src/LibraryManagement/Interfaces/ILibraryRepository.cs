namespace LibraryManagement.Interfaces;

///<summary>
/// Defines the contract for a Library Repository that manages the CRUD operations.
/// </summary>
public interface ILibraryRepository
{
    public void AddItem(ILibraryItem item);
    public ILibraryItem GetItemById(int id);
    public List<ILibraryItem> GetAllItems();
    public bool RemoveItem(int id);
}