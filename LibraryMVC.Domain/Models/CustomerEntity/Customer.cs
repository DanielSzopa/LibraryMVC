using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public CustomerContactDetail CustomerContactDetail { get; set; }
        public Address Address { get; set; } 
        public List<Reservation> Reservations { get; set; } 
        


    }
}
