using System;
using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public List<Book> Books { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ReservationOrRental ReservationOrRental { get; set; }

    }

    public enum ReservationOrRental
    {
        Reservation,
        Rental
    }
}
