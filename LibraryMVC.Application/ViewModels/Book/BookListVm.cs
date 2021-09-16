using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class BookListVm
    {
        public List<BookForListVm> ListOfBookForList { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int TypeOfBookId { get; set; }
        public int AuthorId { get; set; }
    }
}
