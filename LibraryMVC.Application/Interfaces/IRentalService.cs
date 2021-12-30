namespace LibraryMVC.Application
{
    public interface IRentalService
    {
        int AddRental(RentalDetailsVm rentalVm);
        int AddLocalRental(LocalRentalVm rentalVm);
        RentalDetailsVm GetRentalVm(int bookId, int customerId, int reservationId);
        RentalListVm GetAllRentalsToList(int pageNumber, int pageSize, string searchString, int customerId, string whoRentalFilter);
        LocalRentalVm SetParametrsToLocalReservationVm();
    }
}
