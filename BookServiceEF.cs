using BookManagementAppwithEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementAppwithEntityFramework
{
    // Service class to manage book operations using Entity Framework
    public class BookServiceEF
    {
        // DbContext instance to interact with the database
        private readonly BookDbContext _context;

        // Constructor initializing the DbContext
        public BookServiceEF()
        {
            _context = new BookDbContext();
        }

        // Method to insert a new book into the database
        public void InsertNewBook()
        {
            // Prompt user for book details
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter book author: ");
            string author = Console.ReadLine();
            Console.Write("Enter published year: ");
            int publishedYear = int.Parse(Console.ReadLine());
            Console.Write("Enter book genre: ");
            string genre = Console.ReadLine();

            // Create a new Book object
            var newBook = new Book
            {
                Title = title,
                Author = author,
                PublishedYear = publishedYear,
                Genre = genre
            };

            // Add the new book to the context and save changes to the database
            _context.Add(newBook);
            _context.SaveChanges();
            Console.WriteLine("Book inserted successfully.");
        }

        // Method to retrieve and display all books from the database
        public void RetrieveAllBooks()
        {
            var books = _context.Books.ToList();
            Console.WriteLine("Books:");
            // Iterate through each book and display its details
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookID}, {book.Title}, {book.Author}, {book.PublishedYear}, {book.Genre}");
            }
        }

        // Method to retrieve and display books by a specific author
        public void RetrieveBooksByAuthor()
        {
            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            // Query books by the specified author
            var books = _context.Books.Where(b => b.Author == author).ToList();
            Console.WriteLine($"Books by {author}:");
            // Display the books by the author
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookID}, {book.Title}, {book.Author}, {book.PublishedYear}, {book.Genre}");
            }
        }

        // Method to update an existing book's details
        public void UpdateBook()
        {
            Console.Write("Enter BookID of the book to update: ");
            int bookID = int.Parse(Console.ReadLine());

            // Find the book to update by its ID
            var bookToUpdate = _context.Books.Find(bookID);
            if (bookToUpdate == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            // Prompt user for new book details
            Console.Write("Enter new book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter new book author: ");
            string author = Console.ReadLine();
            Console.Write("Enter new published year: ");
            int publishedYear = int.Parse(Console.ReadLine());
            Console.Write("Enter new book genre: ");
            string genre = Console.ReadLine();

            // Update the book details
            bookToUpdate.Title = title;
            bookToUpdate.Author = author;
            bookToUpdate.PublishedYear = publishedYear;
            bookToUpdate.Genre = genre;

            // Save changes to the database
            _context.SaveChanges();
            Console.WriteLine("Book updated successfully.");
        }

        // Method to delete a book from the database
        public void DeleteBook()
        {
            Console.Write("Enter BookID of the book to delete: ");
            int bookID = int.Parse(Console.ReadLine());

            // Find the book to delete by its ID
            var bookToDelete = _context.Books.Find(bookID);
            if (bookToDelete == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            // Remove the book from the context and save changes to the database
            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
            Console.WriteLine("Book deleted successfully.");
        }

        // Method to retrieve and display books with optional filtering, sorting, and pagination
        public void RetrieveBooks(string genreFilter = null, string sortBy = null, int page = 1, int pageSize = 10)
        {
            IQueryable<Book> query = _context.Books;

            // Apply genre filter if specified
            if (!string.IsNullOrEmpty(genreFilter))
            {
                query = query.Where(b => b.Genre == genreFilter);
            }

            // Apply sorting if specified
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "title":
                        query = query.OrderBy(b => b.Title);
                        break;
                    case "author":
                        query = query.OrderBy(b => b.Author);
                        break;
                    case "publishedyear":
                        query = query.OrderBy(b => b.PublishedYear);
                        break;
                    default:
                        Console.WriteLine("Invalid sorting criteria.");
                        return;
                }
            }

            // Apply pagination and retrieve the specified page of books
            var books = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            Console.WriteLine("Books:");
            // Display the retrieved books
            foreach (var book in books)
            {
                Console.WriteLine($"{book.BookID}, {book.Title}, {book.Author}, {book.PublishedYear}, {book.Genre}");
            }
        }
    }
}
