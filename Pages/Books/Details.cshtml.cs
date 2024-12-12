using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADV_Business_Final_Project.Models;

namespace BookSystemFinal.Pages_Books
{
    public class DetailsModel : PageModel
    {
        private readonly ADV_Business_Final_Project.Models.LibraryContext _context;

        public DetailsModel(ADV_Business_Final_Project.Models.LibraryContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include Borrower details when retrieving the Book entity
            var book = await _context.Books
                .Include(b => b.Borrower) // Eagerly load the related Borrower entity
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book is not null)
            {
                Book = book;
                return Page();
            }

            return NotFound();
        }
    }
}
