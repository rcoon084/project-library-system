using LibraryManagement.Services;
using LibraryManagement.Models;
using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Services;

public class LibraryConsoleManager
{
    private readonly ILibraryRepository repository;
    private readonly ILibraryService service;
    public LibraryConsoleManager(ILibraryRepository repository, ILibraryService service)
    {
        this.repository = repository;
        this.service = service;
    }
    public void Run()
    {
        while (true)
        {
            ShowMainMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayAllItems();
                    break;
                case "2":
                    HandleAddItem();
                    break;
                case "3":
                    HandleCheckoutItem();
                    break;
                case "4":
                    HandleReturnItem();
                    break;
                case "5":
                    HandleRemoveItem();
                    break;
                case "0":
                    Console.WriteLine("\nExiting application. Goodbye!");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please select a valid option.");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
    private void ShowMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║         📚 LIBRARY MAIN MENU           ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("   1. View All Library Items");
        Console.WriteLine("   2. Add a New Item");
        Console.WriteLine("   3. Check Out an Item");
        Console.WriteLine("   4. Return an Item");
        Console.WriteLine("   5. Remove an Item");
        Console.WriteLine();
        Console.WriteLine("   0. Exit Application");
        Console.WriteLine();
        Console.Write("   Enter your choice: ");
    }
    private void DisplayAllItems()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("---  All Library Items ---");
        Console.ResetColor();
        Console.WriteLine();
        List<ILibraryItem> items = repository.GetAllItems();
        if (items.Count != 0)
        {
            foreach (var item in items)
            {
                item.DisplayDetails();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║   The library is currently empty.   ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            Console.ResetColor();
        }
    }
    private void HandleCheckoutItem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Check Out an Item ---");
        Console.ResetColor();
        DisplayAllItems();
        Console.WriteLine();
        var id = GetIntInput("Enter the ID of the item to check out:");
        bool success = service.CheckOutItem(id);
        if (success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem successfully checked out.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFailed to check out item. It may not exist or is already checked out.");
            Console.ResetColor();
        }
    }
    private void HandleRemoveItem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Remove an Item ---");
        Console.ResetColor();
        DisplayAllItems();
        Console.WriteLine();
        var id = GetIntInput("Enter the ID of the item to remove:");
        bool success = repository.RemoveItem(id);
        if (success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem successfully removed.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFailed to remove item. It may not exist.");
            Console.ResetColor();
        }
    }
    private void HandleReturnItem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Return an Item ---");
        Console.ResetColor();
        DisplayAllItems();
        Console.WriteLine();
        var id = GetIntInput("Enter the ID of the item to return:");
        bool success = service.ReturnItem(id);
        if (success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem successfully returned.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFailed to return item. It may not exist or was already available.");
            Console.ResetColor();
        }
    }
    private void HandleAddItem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--- Add a New Library Item ---");
        Console.ResetColor();
        Console.WriteLine("Which type of item would you like to add?");
        Console.WriteLine("   1. Book");
        Console.WriteLine("   2. Audiobook");
        Console.WriteLine("   3. Movie");
        Console.WriteLine("   4. Magazine");
        Console.WriteLine("   0. Cancel and return to Main Menu");
        Console.Write("\nEnter your choice: ");

        string choice = Console.ReadLine();
        ILibraryItem newItem = null;

        switch (choice)
        {
            case "1":
                newItem = new Book()
                {
                    Id = 0,
                    IsAvailable = true,
                    Title = GetStringInput("Enter the book's title:"),
                    Author = GetStringInput("Enter the book's author:")
                };
                break;
            case "2":
                newItem = new AudioBook()
                {
                    Id = 0,
                    IsAvailable = true,
                    Title = GetStringInput("Enter the audiobook's title:"),
                    Author = GetStringInput("Enter the audiobook's author:"),
                    Narrator = GetStringInput("Enter the narrator's name:"),
                    Duration = GetIntInput("Enter the duration in minutes:")
                };
                break;
            case "3":
                newItem = new Movie()
                {
                    Id = 0,
                    IsAvailable = true,
                    Title = GetStringInput("Enter the movie's title:"),
                    Director = GetStringInput("Enter the director's name:"),
                    Duration = GetIntInput("Enter the duration in minutes:")
                };
                break;
            case "4":
                newItem = new Magazine()
                {
                    Id = 0,
                    IsAvailable = true,
                    Title = GetStringInput("Enter the magazine's title:"),
                    Company = GetStringInput("Enter the publisher's company:"),
                    Season = GetStringInput("Enter the season (e.g., 'Fall 2025'):")
                };
                break;
            case "0":
                Console.WriteLine("\nAddition cancelled.");
                return;
            default:
                Console.WriteLine("\nInvalid choice.");
                return;
        }
        if (newItem != null)
        {
            repository.AddItem(newItem);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSuccess! '{newItem.Title}' has been added to the library.");
            Console.ResetColor();
        }
    }
    private string GetStringInput(string prompt)
    {
        string input;
        do
        {
            Console.Write("   " + prompt + " ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   Input cannot be empty. Please try again.");
                Console.ResetColor();
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    private int GetIntInput(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write("   " + prompt + " ");
            if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
            {
                return number;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   Invalid input. Please enter a valid positive number.");
                Console.ResetColor();
            }
        }
    }
}