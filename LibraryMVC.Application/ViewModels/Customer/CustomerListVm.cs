using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public class CustomerListVm
    {
        public List<CustomerForListVm> Customers { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }

    }
}
