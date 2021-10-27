using LibraryMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;
        public ReservationRepository(Context context)
        {
            _context = context;
        }
    }
}
