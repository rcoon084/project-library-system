using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Services;

Book book = new Book()
{
    Id = 1,
    Title = "100 Años de Soledad",
    IsAvailable = true,
    Author = "Gabriel García Marquez"
};

Movie movie = new Movie()
{
    Id = 1,
    Title = "AaaAAAAA",
    IsAvailable = true,
    Director = "A24",
    Duration = 244
};


book.DisplayDetails();
movie.DisplayDetails();

LibraryRepository repository = new LibraryRepository();
LibraryService service = new LibraryService()
{
    Repository = repository
};

repository.AddItem(movie);
foreach (ILibraryItem item in repository.GetAllItems())
{
    Console.WriteLine("");
    item.DisplayDetails();
    Console.WriteLine("");
}
repository.AddItem(book);
foreach (ILibraryItem item in repository.GetAllItems())
{
    Console.WriteLine("");
    item.DisplayDetails();
    Console.WriteLine("");
}

service.CheckOutItem(movie.Id);



repository.GetItemById(movie.Id).DisplayDetails();

service.ReturnItem(movie.Id);

repository.GetItemById(movie.Id).DisplayDetails();

repository.RemoveItem(movie.Id);
foreach (ILibraryItem item in repository.GetAllItems())
{
    Console.WriteLine("");
    item.DisplayDetails();
    Console.WriteLine("");
}
