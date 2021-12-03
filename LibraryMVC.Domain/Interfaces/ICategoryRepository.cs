using System.Linq;

namespace LibraryMVC.Domain
{
    public interface ICategoryRepository
    {
        void AddCategory(Category model);
        void UpdateCategory(Category model);
        void DeleteCategory(int id);
        void ChangeCategoryNameToOther(int id);
        int CountBooksOfCategory(int id);      
        Category GetCategoryById(int id);
        IQueryable<Book> GetAllBooksByCategoryId(int id);
        IQueryable<Category> GetAllCategories();
    }
}
