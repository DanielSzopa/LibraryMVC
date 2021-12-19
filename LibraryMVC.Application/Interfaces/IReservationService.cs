namespace LibraryMVC.Application
{
    public interface IReservationService
    {
        ReservationDetailsVm GetReservationVm(int bookId, string userId);
        int AddReservation(ReservationDetailsVm reservationVm);
        int AddLocalReservation(LocalReservationVm localReservationVm);
        void DeleteReservation(int id);
        int GetBookIdByReservation(int id);       
        ReservationDetailsVm GetReservationDetails(int id);
        ReservationListVm GetAllResevationToList(int pageNumber, int pageSize, string searchString, int customerId, string whoReservationFilter);
        LocalReservationVm SetParametrsToLocalReservationVm();

    }
}
