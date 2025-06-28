using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.interfaces;

public interface ILibraryItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }

    public void DisplayDetails();
}