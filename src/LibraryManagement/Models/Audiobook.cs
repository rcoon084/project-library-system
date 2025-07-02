using LibraryManagement.Interfaces;
namespace LibraryManagement.Models;

/// <summary>
/// An implementation of ILibraryItem
/// </summary>
public class AudioBook : ILibraryItem
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required bool IsAvailable { get; set; } = true; // It's true by default
    public required string Author { get; set; }
    public required string Narrator { get; set; }
    public required int Duration { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"--- Audiobook Details (ID: {Id}) ---");
        Console.WriteLine($"  Title: {Title}");
        Console.WriteLine($"  Author: {Author}");
        Console.WriteLine($"  Narrator: {Narrator}");
        Console.WriteLine($"  Duration: {Duration} minutes");
        Console.WriteLine($"  Status: {(IsAvailable ? "Available" : "Checked Out")}"); // A nice touch to make the boolean more user-friendly
        Console.WriteLine("--------------------------");
    }
}