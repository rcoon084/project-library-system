namespace LibraryManagement.Models;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using LibraryManagement.Interfaces;

/// <summary>
/// An implementation of ILibraryItem
/// </summary>
public class Book : ILibraryItem
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required bool IsAvailable { get; set; } = true; // It's true by default
    public required string Author { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"--- Book Details (ID: {Id}) ---");
        Console.WriteLine($"  Title: {Title}");
        Console.WriteLine($"  Author: {Author}");
        Console.WriteLine($"  Status: {(IsAvailable ? "Available" : "Checked Out")}"); // A nice touch to make the boolean more user-friendly
        Console.WriteLine("--------------------------");
    }
}