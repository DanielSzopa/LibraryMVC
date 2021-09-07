using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface ICategoryService
    {
        void AddCategory(CategoryVm model);
        void DeleteCategory(int id);
        void ChangeCategoryBeforeDelete(int id);
        CategoryListVm GetAllCategoriesToList();
    }
}
