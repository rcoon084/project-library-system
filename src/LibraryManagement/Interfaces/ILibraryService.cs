namespace LibraryManagement.Interfaces;

///<summary>
/// Defines the contract for a Library Service, used to checkout or return items.
/// </summary>
public interface ILibraryService
{
    public bool CheckOutItem(int id);
    public bool ReturnItem(int id);
}