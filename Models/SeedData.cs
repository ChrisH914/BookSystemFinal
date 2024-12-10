using ADV_Business_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ADV_Business_Final_Project;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>());

        // Check if the database has already been seeded
        if (context.Books.Any() && context.Borrowers.Any())
        {
            return; // DB has been seeded
        }

        // Seed Books
        context.Books.AddRange(
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction" },
            new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
            new Book { Title = "Moby-Dick", Author = "Herman Melville", Genre = "Adventure" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance" },
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" },
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction" },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy" },
            new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Genre = "Fantasy" },
            new Book { Title = "The Da Vinci Code", Author = "Dan Brown", Genre = "Thriller" },
            new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Genre = "Dystopian" }
        );

        // Seed Borrowers
        context.Borrowers.AddRange(
            new Borrower { Name = "John Doe", Email = "johndoe@example.com" },
            new Borrower { Name = "Jane Smith", Email = "janesmith@example.com" },
            new Borrower { Name = "Emily Johnson", Email = "emilyjohnson@example.com" },
            new Borrower { Name = "Michael Brown", Email = "michaelbrown@example.com" },
            new Borrower { Name = "Sarah Davis", Email = "sarahdavis@example.com" }
        );

        // Save changes to the database
        context.SaveChanges();
    }
}
