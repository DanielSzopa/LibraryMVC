using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class BookListVm
    {
        public List<BookForListVm> ListOfBookForList { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
