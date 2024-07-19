using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementAppwithEntityFramework
{
    // Represents a book entity in the system
    public class Book
    {
        // Primary key for the Book entity
        public int BookID { get; set; }

        // Title of the book, e.g., "The Great Gatsby"
        public string Title { get; set; }

        // Author of the book, e.g., "F. Scott Fitzgerald"
        public string Author { get; set; }

        // Year the book was published, e.g., 1925
        public int PublishedYear { get; set; }

        // Genre of the book, e.g., "Fiction"
        public string Genre { get; set; }
    }
}
