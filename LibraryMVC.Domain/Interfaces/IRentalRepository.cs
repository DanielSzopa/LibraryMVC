using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IRentalRepository
    {
        int AddRental(Rental rental);
        IQueryable<Rental> GetAllRentals();
        IQueryable<Rental> GetAllCustomerRentals(int customerId);
    }
}
