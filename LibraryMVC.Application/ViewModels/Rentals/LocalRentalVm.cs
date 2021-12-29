using System;
using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public class LocalRentalVm
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<BookFullNameVm> Books { get; set; }
        public List<CustomerFullNameVm> Customers { get; set; }
    }
}
