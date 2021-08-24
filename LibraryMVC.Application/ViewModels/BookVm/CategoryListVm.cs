using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class CategoryListVm
    {
        public List<CategoryVm> CategoriesOfBooks { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
