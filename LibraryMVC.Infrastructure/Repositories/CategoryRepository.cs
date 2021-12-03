using LibraryMVC.Domain;
using System.Linq;

namespace LibraryMVC.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public void AddCategory(Category model)
        {
            _context.Categories.Add(model);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category model)
        {
            _context.Attach(model);
            _context.Entry(model).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void ChangeCategoryNameToOther(int id)
        {
            var books = _context.Books.Where(b => b.CategoryId == id)
                 .ToList();

            books.ForEach(b => b.CategoryId = 1);
            _context.SaveChanges();
        }

        public int CountBooksOfCategory(int id)
        {
           var numberOfBooks =  _context.Books.Where(b => b.CategoryId == id).Count();
            return numberOfBooks;
        }

        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

        public IQueryable<Book> GetAllBooksByCategoryId(int id)
        {
            var categories = _context.Books.Where(b => b.CategoryId == id);
            return categories;
        }
        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }     
    }
}
