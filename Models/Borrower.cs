using System.ComponentModel.DataAnnotations;

namespace ADV_Business_Final_Project.Models
{
    public class Borrower
    {
        public int BorrowerID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}
