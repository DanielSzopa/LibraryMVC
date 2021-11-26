using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public Reservation GetReservationDetails(int id)
        {
            var reservation = _context.Reservations
                .Include(r => r.Book)
                .ThenInclude(b => b.Author)
                .Include(r => r.Customer)
                .ThenInclude(c => c.CustomerContactDetail)
                .FirstOrDefault(r => r.Id == id);

            return reservation;
        }

        public IQueryable<Reservation> GetAllReservation()
        {
            var reservations = _context.Reservations;
            return reservations;
        }

    }
}
