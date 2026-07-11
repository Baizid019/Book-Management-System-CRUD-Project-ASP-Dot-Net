using Microsoft.EntityFrameworkCore; //  This imports the Entity Framework Core library.
using BookList.Models; // This imports your Book model. 

namespace BookList.Data // This tells us the class belongs to the Data folder. 
{
    public class ApplicationDbContext : DbContext // This creates a class called that inherits from DbContext.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) // base refers to the parent class, which is DbContext. 
        /* 
           This constructor receives the database configuration (options) and passes it to
           the parent DbContext class so Entity Framework Core knows how to connect to and 
           manage the database.
        */
        {

        }

        public DbSet<Book> Books { get; set; }
        // A DbSet<T> represents a table in the database . I want a table that stores Book objects.

        public DbSet<Category> Categories { get; set; }

    }
}