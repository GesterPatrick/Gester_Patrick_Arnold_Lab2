

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gester_Patrick_Lab2.Models
{
    public class BookCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Gester_Patrick_Lab2Context context,
        Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                            book.Book_Categories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(Gester_Patrick_Lab2Context context,
        string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.Book_Categories = new List<Book_Category>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.Book_Categories.Select(c => c.CategoryID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.Book_Categories.Add(
                        new Book_Category
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        Book_Category courseToRemove
                        = bookToUpdate
                        .Book_Categories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
