using System.ComponentModel.DataAnnotations;

namespace ADV_Business_Final_Project.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Author name must be between 2 and 50 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Genre must be between 3 and 30 characters.")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public bool IsCheckedOut { get; set; } = false;

        // Foreign Key for Borrower
        public int? BorrowerID { get; set; }

        // Navigation property to the Borrower entity
        public Borrower? Borrower { get; set; }
    }
}
