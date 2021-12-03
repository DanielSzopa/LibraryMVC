using System;

namespace LibraryMVC.Domain
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }

    }
}
