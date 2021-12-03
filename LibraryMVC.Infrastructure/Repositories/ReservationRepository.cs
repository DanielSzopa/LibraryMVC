using LibraryMVC.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public int GetBookIdByReservation(int id)
        {
            var bookId = _context.Reservations.Find(id).BookId;
            return bookId;
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

        public IQueryable<Reservation> GetAllCustomerReservations(int customerId)
        {
            var reservations = _context.Reservations
                .Where(r => r.CustomerId == customerId);
            return reservations;
        }
    }
}
