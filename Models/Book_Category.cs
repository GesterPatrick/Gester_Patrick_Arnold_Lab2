namespace Gester_Patrick_Lab2.Models
{
    public class Book_Category
    {
        public int ID { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; } //navigation property

        public int CategoryID { get; set; }
        public Category Category { get; set; } //navigation property


    }
}
