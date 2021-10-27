using LibraryMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
    }
}
