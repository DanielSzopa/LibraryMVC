using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pesel { get; set; }
        public CustomerContactDetail CustomerContactDetail { get; set; }
        public Address Address { get; set; } 
        public List<Reservation> Reservations { get; set; } 
        


    }
}
