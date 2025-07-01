using System.Runtime.CompilerServices;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;

namespace LibraryManagement.Services;

public class LibraryRepository : ILibraryRepository
{
    public List<ILibraryItem> _items { get; set; } = new();
    public int NextId { get; set; }
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
        return _items;
    }
    public void RemoveItem(int id)
    {
        var toRemove = _items.FirstOrDefault(item => item.Id == id);
        if (toRemove != null)
        {
            _items.Remove(toRemove);
        }
    }
}