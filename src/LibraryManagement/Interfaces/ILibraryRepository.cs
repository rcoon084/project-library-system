namespace LibraryManagement.Interfaces;

public interface ILibraryRepository
{
    public void AddItem(ILibraryItem item);
    public ILibraryItem GetItemById(int id);
    public List<ILibraryItem> GetAllItems();
    public void RemoveItem(int id);
}