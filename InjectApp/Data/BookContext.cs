using InjectApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InjectApp.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
