using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Interfaces;

public interface ILibraryItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }

    public void DisplayDetails();
}