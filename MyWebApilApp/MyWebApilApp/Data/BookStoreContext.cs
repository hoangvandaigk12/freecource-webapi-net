using Microsoft.EntityFrameworkCore;

namespace MyWebApilApp.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<Book>? Books { get; set; }
        public DbSet<Computer> Computers { get; set; }
        #endregion
    }
}
