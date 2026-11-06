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

    public async Task OnGetAsync()
    {
        Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();
    }
}
