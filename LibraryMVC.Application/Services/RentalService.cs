using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class RentalService : IRentalService
    {
        private readonly IRentalService _rentalService;
        public RentalService(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
    }
}
