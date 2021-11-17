using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{ 
    public class NewReservationVm
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPesel { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
    }
}
