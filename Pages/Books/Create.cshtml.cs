using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ADV_Business_Final_Project.Models;

namespace BookSystemFinal.Pages_Books
{
    public class CreateModel : PageModel
    {
        private readonly ADV_Business_Final_Project.Models.LibraryContext _context;

        public CreateModel(ADV_Business_Final_Project.Models.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BorrowerID"] = new SelectList(_context.Borrowers, "BorrowerID", "Email");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
