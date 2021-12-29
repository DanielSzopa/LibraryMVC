using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IRentalRepository
    {
        IQueryable<Rental> GetAllRentals();
        IQueryable<Rental> GetAllCustomerRentals(int customerId);
    }
}
