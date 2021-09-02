using LibraryMVC.Domain;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
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
        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }
    }
}
