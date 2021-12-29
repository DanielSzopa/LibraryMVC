﻿using LibraryMVC.Domain;
using System.Linq;

namespace LibraryMVC.Infrastructure
{
    public class RentalRepository : IRentalRepository
    {
        private readonly Context _context;
        public RentalRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Rental> GetAllRentals()
        {
            var rentals = _context.Rentals;
            return rentals;
        }

        public IQueryable<Rental> GetAllCustomerRentals(int customerId)
        {
            var rentals = _context.Rentals
                .Where(r => r.CustomerId == customerId);

            return rentals;
        }

    }
}
