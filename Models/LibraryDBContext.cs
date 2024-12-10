using Microsoft.EntityFrameworkCore;

namespace ADV_Business_Final_Project.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }

        // Optional: Configure relationships in OnModelCreating if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring One-to-Many relationship between Book and Borrower
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrower)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(b => b.BorrowerID)
                .OnDelete(DeleteBehavior.SetNull);  // You can modify this behavior based on your needs
        }
    }
}
