using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class RentalListVm
    {
        public List<RentalForListVm> ListOfRentalForListVm { get; set; }

        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int RentalByCustomerId { get; set; }
        public string WhoRentalFilter { get; set; }

    }
}
