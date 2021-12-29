namespace LibraryMVC.Application
{
    public interface IRentalService
    {
        int CreateLocalReservation();
        RentalListVm GetAllRentalsToList(int pageNumber, int pageSize, string searchString, int customerId, string whoRentalFilter);
        LocalRentalVm SetParametrsToLocalReservationVm();
    }
}
