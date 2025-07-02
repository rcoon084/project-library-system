
namespace LibraryManagement.Interfaces;

///<summary>
/// Defines the contract for a Library Item.
/// </summary>
public interface ILibraryItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }

    public void DisplayDetails();
}