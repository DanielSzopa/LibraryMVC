using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IRentalRepository
    {
        int AddRental(Rental rental);
        void DeleteRental(int rentalId);
        int GetBookIdByRental(int rentalId);
        Rental GetRentalDetails(int rentalId);
        IQueryable<Rental> GetAllRentals();
        IQueryable<Rental> GetAllCustomerRentals(int customerId);
    }
}
