using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public int NumberOfLocal { get; set; }
        public int? NumberOfAccommodation { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
