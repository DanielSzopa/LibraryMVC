using System.Collections.Generic;

namespace LibraryMVC.Domain.Models
{
    public class CustomerContactDetail
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}
