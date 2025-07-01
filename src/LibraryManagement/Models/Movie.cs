using LibraryManagement.Interfaces;
using LibraryManagement.Models;

public class Movie : ILibraryItem
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required bool IsAvailable { get; set; } = true; // It's true by default
    public required string Director { get; set; }
    public required int Duration { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"--- Movie Details (ID: {Id}) ---");
        Console.WriteLine($"  Title: {Title}");
        Console.WriteLine($"  Director: {Director}");
        Console.WriteLine($"  Duration: {Duration} minutes");
        Console.WriteLine($"  Status: {(IsAvailable ? "Available" : "Checked Out")}"); // A nice touch to make the boolean more user-friendly
        Console.WriteLine("--------------------------");
    }

}