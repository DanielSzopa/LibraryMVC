using System.Linq;

namespace LibraryMVC.Domain
{
    public interface IReservationRepository
    {
        int AddReservation(Reservation reservation);
        void DeleteReservation(int id);
        int GetBookIdByReservation(int id);
        Reservation GetReservationDetails(int id);
        IQueryable<Reservation> GetAllReservation();
        IQueryable<Reservation> GetAllCustomerReservations(int customerId);
    }
}
