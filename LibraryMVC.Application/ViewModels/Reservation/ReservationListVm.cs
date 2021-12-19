using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public class ReservationListVm
    {
        public List<ReservationForListVm> ListOfReservationForListVm { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int ReservationsByCustomerId { get; set; }
        public string WhoReservationFilter { get; set; }

    }
}
