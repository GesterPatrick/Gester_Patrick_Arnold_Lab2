using Gester_Patrick_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gester_Patrick_Lab2.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly Gester_Patrick_Lab2Context _context; // DbContext-ul inca gol


    // ca-n Java, la fiecare cerere catre pagina (GET sau POST) se creează un obiect nou, se apeleaza constructorul
    //  deci constructorul se ruleaza la fiecare vizita a paginii


    
    public CreateModel(Gester_Patrick_Lab2Context context) // constructorul paginii, primeste parametru DBcontext automat si-l salveaza in campul _contex definit de noi
    {                                                      // astfel, putem sa apelam OnGet() sau OnPost() pe obiectul creat,  _context CARE E BAZA NOASTRA DE DATE
        this._context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName", "LastName");
        return Page();
    }

    // ia datele primite din formular[POST] si le salveaza in obiectul Book daca se potrivesc numelui proprietatii (Book.Title, Book.Author, Book.Price)
    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}

/*Submit
  ↓
ASP.NET creează pagina(constructorul)
  ↓
[BindProperty] completează Book cu datele trimise   ← pasul pregătitor
  ↓
OnPostAsync rulează(Book e deja plin)
*/