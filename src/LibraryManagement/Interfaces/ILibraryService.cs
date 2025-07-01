namespace LibraryManagement.Interfaces;

public interface ILibraryService
{
    public bool CheckOutItem(int id);
    public bool ReturnItem(int id);
}