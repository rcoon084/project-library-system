using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Services;

LibraryRepository repository = new LibraryRepository();
LibraryService service = new LibraryService(repository);
LibraryConsoleManager console = new LibraryConsoleManager(repository, service);


console.Run();

