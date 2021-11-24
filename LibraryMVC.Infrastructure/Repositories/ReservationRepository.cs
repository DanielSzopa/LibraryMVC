using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation.Id;
        }

        public IQueryable<Reservation> GetAllReservation()
        {
            var reservations = _context.Reservations;
            return reservations;
        }
    }
}
