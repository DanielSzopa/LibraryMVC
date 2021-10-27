using LibraryMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class RentalRepository : IRentalRepository
    {
        private readonly Context _context;
        public RentalRepository(Context context)
        {
            _context = context;
        }
    }
}
