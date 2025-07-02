using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Services;


//Initialize the services
LibraryRepository repository = new LibraryRepository();
LibraryService service = new LibraryService(repository);
LibraryConsoleManager console = new LibraryConsoleManager(repository, service);
//Start the Console Manager service
console.Run();

