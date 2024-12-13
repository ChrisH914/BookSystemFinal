using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADV_Business_Final_Project.Models;

namespace BookSystemFinal.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }

        // List of books
        public IList<Book> Book { get; set; } = default!;
        
        // Property for search query
        public string SearchQuery { get; set; } = string.Empty;

        // Pagination properties
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        // OnGetAsync method to handle data retrieval and pagination
        public async Task OnGetAsync(string searchQuery, int pageIndex = 1)
        {
            IQueryable<Book> books = _context.Books.Include(b => b.Borrower);

            // Search query logic
            if (!string.IsNullOrEmpty(searchQuery))
            {
                books = books.Where(b => b.Title.Contains(searchQuery) || 
                                         b.Author.Contains(searchQuery) ||
                                         b.Genre.Contains(searchQuery));
            }

            // Set search query value
            SearchQuery = searchQuery;

            // Calculate total number of pages
            var totalBooks = await books.CountAsync();
            TotalPages = (int)Math.Ceiling(totalBooks / (double)PageSize);

            // Get the books for the current page
            Book = await books
                .Skip((pageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            CurrentPage = pageIndex;
        }
    }
}
