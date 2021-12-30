using LibraryMVC.Domain;
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

        public int AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return rental.Id;
        }

        public void DeleteRental(int rentalId)
        {
            var rental = _context.Rentals
                .Find(rentalId);

            if(!(rental is null))
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
            }

        }

        public int GetBookIdByRental(int rentalId)
        {
            var rental = _context.Rentals
                .Find(rentalId);
            var bookId = rental.BookId;

            return bookId;               
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
