namespace LibraryManagement.Models;

public class Magazine
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required bool IsAvailable { get; set; } = true; // It's true by default
    public required string Season { get; set; }
    public required string Company { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"--- Magazine Details (ID: {Id}) ---");
        Console.WriteLine($"  Title: {Title}");
        Console.WriteLine($"  Season: {Season}");
        Console.WriteLine($"  Company: {Company}");
        Console.WriteLine($"  Status: {(IsAvailable ? "Available" : "Checked Out")}"); // A nice touch to make the boolean more user-friendly
        Console.WriteLine("--------------------------");
    }
}