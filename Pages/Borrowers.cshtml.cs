using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADV_Business_Final_Project.Models;

namespace ADV_Business_Final_Project.Pages
{
    public class BorrowersModel : PageModel
    {
        private readonly LibraryContext _context;

        public BorrowersModel(LibraryContext context)
        {
            _context = context;
        }

        public List<Borrower> Borrowers { get; set; }

        public async Task OnGetAsync()
        {
            Borrowers = await _context.Borrowers.ToListAsync();
        }
    }
}
