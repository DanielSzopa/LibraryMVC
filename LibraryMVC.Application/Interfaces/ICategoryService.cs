namespace LibraryMVC.Application
{
    public interface ICategoryService
    {
        void AddCategory(CategoryVm model);
        void UpdateCategory(CategoryVm model);
        void DeleteCategory(int id);
        void ChangeCategoryBeforeDelete(int id);
        BookListVm GetBooksByCategoryId(int id);
        CategoryVm GetCategoryById(int id);
        CategoryListVm GetAllCategoriesToList();
    }
}
