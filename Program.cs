using System;
using BookManagementAppwithEntityFramework;

namespace BookManagementSystemEF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the BookServiceEF class to perform book operations
            BookServiceEF bookService = new BookServiceEF();
            bool exit = false; // Flag to control the loop for the main menu

            // Main loop for the application menu
            while (!exit)
            {
                // Display the main menu to the user
                Console.WriteLine("\nBook Management Application");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. View books by author");
                Console.WriteLine("4. Update a book's details");
                Console.WriteLine("5. Delete a book");
                Console.WriteLine("6. Search books by genre");
                Console.WriteLine("7. Sort and paginate books");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                // Read the user's choice
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Call the method to insert a new book
                        bookService.InsertNewBook();
                        break;
                    case "2":
                        // Call the method to retrieve and display all books
                        bookService.RetrieveAllBooks();
                        break;
                    case "3":
                        // Call the method to retrieve and display books by a specific author
                        bookService.RetrieveBooksByAuthor();
                        break;
                    case "4":
                        // Call the method to update an existing book's details
                        bookService.UpdateBook();
                        break;
                    case "5":
                        // Call the method to delete a book
                        bookService.DeleteBook();
                        break;
                    case "6":
                        // Prompt the user to enter a genre to search for books
                        Console.Write("Enter genre to search: ");
                        string genre = Console.ReadLine();
                        // Call the method to retrieve books filtered by genre
                        bookService.RetrieveBooks(genreFilter: genre);
                        break;
                    case "7":
                        // Prompt the user to enter sorting criteria and pagination details
                        Console.Write("Enter sorting criteria (Title, Author, PublishedYear): ");
                        string sortBy = Console.ReadLine();
                        Console.Write("Enter page number: ");
                        int page = int.Parse(Console.ReadLine());
                        // Call the method to retrieve and display books with sorting and pagination
                        bookService.RetrieveBooks(sortBy: sortBy, page: page);
                        break;
                    case "8":
                        // Set the exit flag to true to exit the application
                        exit = true;
                        break;
                    default:
                        // Handle invalid menu options
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            // Display a farewell message when exiting the application
            Console.WriteLine("Goodbye!");
        }
    }
}
