using System.Runtime.CompilerServices;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Services;

/// <summary>
/// An implementation of ILibraryRepository, used for managing the items in memory.
/// Adheres to the SOLID principles
/// </summary>
public class LibraryRepository : ILibraryRepository
{
    private List<ILibraryItem> _items { get; set; } = new();
    private int NextId { get; set; }
    public void AddItem(ILibraryItem item)
    {
        if (item == null)
        {
            return;
        }
        item.Id = NextId;
        NextId++;
        _items.Add(item);
    }
    public ILibraryItem GetItemById(int id)
    {
        foreach (ILibraryItem item in _items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
    public List<ILibraryItem> GetAllItems()
    {
        if (_items != null)
        {
            return _items;
        }
        else
        {
            return new List<ILibraryItem>();
        }

    }
    public bool RemoveItem(int id)
    {
        var toRemove = _items.FirstOrDefault(item => item.Id == id);
        if (toRemove != null)
        {
            _items.Remove(toRemove);
            return true;
        }
        return false;
    }
}