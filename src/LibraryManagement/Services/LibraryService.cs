using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Services;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository Repository;
    public LibraryService(ILibraryRepository repository)
    {
        Repository = repository;
    }

    public bool CheckOutItem(int id)
    {
        var item = Repository.GetItemById(id);

        if (item.IsAvailable == true)
        {
            item.IsAvailable = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ReturnItem(int id)
    {
        var item = Repository.GetItemById(id);
        if (item.IsAvailable == false)
        {
            item.IsAvailable = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}