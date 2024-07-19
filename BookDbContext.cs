using Microsoft.EntityFrameworkCore;

namespace BookManagementAppwithEntityFramework
{
    // DbContext class for managing the database connection and entity configurations
    public class BookDbContext : DbContext
    {
        // DbSet representing the Books table in the database
        public DbSet<Book> Books { get; set; }

        // Configures the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Check if the context options are already configured
            if (!optionsBuilder.IsConfigured)
            {
                // Define the connection string for the MySQL database
                string connectionString = "Server=localhost;Database=BookDB;User ID=root;Password=root;";
                // Configure the context to use MySQL with automatic server version detection
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        // Configures the model to map to the database schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                // Configure Title property to be required and have a maximum length of 100 characters
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configure Author property to be required and have a maximum length of 100 characters
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configure Genre property with a maximum length of 50 characters
                entity.Property(e => e.Genre)
                    .HasMaxLength(50);

                // Configure PublishedYear property to match the database column name
                entity.Property(e => e.PublishedYear)
                    .HasColumnName("PublishedYear"); // Ensure this matches the actual column name in your database

                // Map the entity to the "Books" table in the database
                entity.ToTable("Books"); // Specify the table name, useful if it differs from the entity name
            });

            // Call the base method to ensure any additional configuration is applied
            base.OnModelCreating(modelBuilder);
        }
    }
}
