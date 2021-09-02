using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface ICategoryService
    {
        void AddCategory(CategoryVm model);
        CategoryListVm GetAllCategoriesToList();
    }
}
