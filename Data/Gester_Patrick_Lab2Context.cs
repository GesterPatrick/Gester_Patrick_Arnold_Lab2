using Microsoft.EntityFrameworkCore;

public class Gester_Patrick_Lab2Context(DbContextOptions<Gester_Patrick_Lab2Context> options) : DbContext(options)
{
    public DbSet<Gester_Patrick_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Gester_Patrick_Lab2.Models.Publisher> Publisher { get; set; }
    public DbSet<Gester_Patrick_Lab2.Models.Author> Author { get; set; }
}
