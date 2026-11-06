using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gester_Patrick_Lab2.Models;

namespace Gester_Patrick_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Gester_Patrick_Lab2Context _context;

    public IndexModel(Gester_Patrick_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;
    public BookData BookD { get; set; }
    public int BookID { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id, int? categoryID)
    {
        BookD = new BookData();

        BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.Book_Categories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
        if (id != null)
        {
            BookID = id.Value;
            Book book = BookD.Books
            .Where(i => i.ID == id.Value).Single();
            BookD.Categories = book.Book_Categories.Select(s => s.Category);
        }
    }
}