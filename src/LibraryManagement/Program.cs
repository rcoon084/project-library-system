using LibraryManagement.Models;

Book book = new Book()
{
    Id = 1,
    Title = "100 Años de Soledad",
    IsAvailable = true,
    Author = "Gabriel García Marquez"
};


book.DisplayDetails();