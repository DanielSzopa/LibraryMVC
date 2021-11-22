using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class ReservationListVm
    {
        public List<ReservationForListVm> ListOfReservationForListVm { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }

    }
}
