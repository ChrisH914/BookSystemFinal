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
        var books = new[]
{
    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction" },
    new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
    new Book { Title = "Moby-Dick", Author = "Herman Melville", Genre = "Adventure" },
    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance" },
    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" },
    new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction" },
    new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy" },
    new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Genre = "Fantasy" },
    new Book { Title = "The Da Vinci Code", Author = "Dan Brown", Genre = "Thriller" },
    new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Genre = "Dystopian" },
    new Book { Title = "The Alchemist", Author = "Paulo Coelho", Genre = "Philosophical" },
    new Book { Title = "A Game of Thrones", Author = "George R.R. Martin", Genre = "Fantasy" },
    new Book { Title = "The Road", Author = "Cormac McCarthy", Genre = "Post-apocalyptic" },
    new Book { Title = "The Book Thief", Author = "Markus Zusak", Genre = "Historical Fiction" },
    new Book { Title = "Beloved", Author = "Toni Morrison", Genre = "Historical" },
    new Book { Title = "Goodnight Moon", Author = "Margaret Wise Brown", Genre = "Children's" },
    new Book { Title = "The Fault in Our Stars", Author = "John Green", Genre = "Young Adult" },
    new Book { Title = "The Shining", Author = "Stephen King", Genre = "Horror" },
    new Book { Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Genre = "Gothic" },
    new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction" },
    new Book { Title = "Wuthering Heights", Author = "Emily Brontë", Genre = "Classic" },
    new Book { Title = "Dracula", Author = "Bram Stoker", Genre = "Horror" },
    new Book { Title = "The Outsiders", Author = "S.E. Hinton", Genre = "Young Adult" },
    new Book { Title = "The Chronicles of Narnia", Author = "C.S. Lewis", Genre = "Fantasy" },
    new Book { Title = "Jane Eyre", Author = "Charlotte Brontë", Genre = "Romance" },
    new Book { Title = "The Secret Garden", Author = "Frances Hodgson Burnett", Genre = "Children's" },
    new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Genre = "Psychological Fiction" },
    new Book { Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical Fiction" },
    new Book { Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Genre = "Magical Realism" },
    new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Genre = "Dystopian" },
    new Book { Title = "The Night Circus", Author = "Erin Morgenstern", Genre = "Fantasy" }
};


        context.Books.AddRange(books);

        // Seed Borrowers with phone numbers and associated books
        var borrowers = new[]
        {
            new Borrower 
            { 
                Name = "John Doe", 
                Email = "johndoe@example.com", 
                Phone = "123-456-7890", 
                BorrowedBooks = new List<Book> { books[0], books[1] }
            },
            new Borrower 
            { 
                Name = "Jane Smith", 
                Email = "janesmith@example.com", 
                Phone = "987-654-3210", 
                BorrowedBooks = new List<Book> { books[2] }
            },
            new Borrower 
            { 
                Name = "Emily Johnson", 
                Email = "emilyjohnson@example.com", 
                Phone = "456-789-1234", 
                BorrowedBooks = new List<Book> { books[3], books[4], books[5] }
            },
            new Borrower 
            { 
                Name = "Michael Brown", 
                Email = "michaelbrown@example.com", 
                Phone = "789-123-4567", 
                BorrowedBooks = new List<Book> { books[6] }
            },
            new Borrower 
            { 
                Name = "Sarah Davis", 
                Email = "sarahdavis@example.com", 
                Phone = "321-654-9870", 
                BorrowedBooks = new List<Book> { books[7], books[8], books[9] }
            },
            new Borrower
            {
                Name = "Christopher Herrera",
                Email = "cherrera4@buffs.wtamu.edu",
                Phone = "555-555-5555",
                BorrowedBooks = new List<Book> { books[7], books[8], books[9] }
            
            }
        };

        context.Borrowers.AddRange(borrowers);

        // Save changes to the database
        context.SaveChanges();
    }
}
