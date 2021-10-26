using LibraryMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalRepository(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
    }
}
