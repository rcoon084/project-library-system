using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Services;

/// <summary>
/// An implementation of ILibraryService, used for cheking out and returning
/// Adheres to the SOLID principles
/// </summary>
public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository Repository;
    public LibraryService(ILibraryRepository repository)
    {
        Repository = repository;
    }

    public bool CheckOutItem(int id)
    {
        ILibraryItem? item = Repository.GetItemById(id);
        if (item != null)
        {
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
        return false;

    }
    public bool ReturnItem(int id)
    {
        ILibraryItem? item = Repository.GetItemById(id);
        if (item != null)
        {
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
        return false;
    }
}