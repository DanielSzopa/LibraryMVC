using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System.Linq;

namespace LibraryMVC.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public void AddCategory(CategoryVm model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.AddCategory(category);
        }
        public void UpdateCategory(CategoryVm model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.UpdateCategory(category);
        }
        public void DeleteCategory(int id)
        {
            ChangeCategoryBeforeDelete(id);
            _categoryRepository.DeleteCategory(id);
        }
        public void ChangeCategoryBeforeDelete(int id)
        {
            _categoryRepository.ChangeCategoryNameToOther(id);
        }

        public BookListVm GetBooksByCategoryId(int id)
        {
            var books = _categoryRepository.GetAllBooksByCategoryId(id)
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var result = new BookListVm
            {
                ListOfBookForList = books
            };
            return result;
        }
        public CategoryVm GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            var categoryVm = _mapper.Map<CategoryVm>(category);
            return categoryVm;
        }
        public CategoryListVm GetAllCategoriesToList()
        {
            var categories = _categoryRepository.GetAllCategories().ProjectTo<CategoryVm>(_mapper.ConfigurationProvider)
                .ToList();
            foreach(var categoryVm in categories)
            {
                categoryVm.NumberOfBooks = _categoryRepository.CountBooksOfCategory(categoryVm.Id);
            }

            var result = new CategoryListVm
            {
                CategoriesOfBooks = categories
            };

            return result;
        }
    }
}
