using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public class BookListVm
    {
        public List<BookForListVm> ListOfBookForList { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public string Filter { get; set; }
        public int FilterId { get; set; }
    }
}
