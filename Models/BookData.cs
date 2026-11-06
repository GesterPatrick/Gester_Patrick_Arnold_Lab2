namespace Gester_Patrick_Lab2.Models
{
    public class BookData
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book_Category> BookCategories { get; set; }
    }
}
