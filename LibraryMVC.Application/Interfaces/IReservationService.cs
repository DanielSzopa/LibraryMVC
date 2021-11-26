using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IReservationService
    {
        ReservationDetailsVm GetReservationVm(int bookId, string userId);
        int AddReservation(ReservationDetailsVm reservationVm);
        ReservationDetailsVm GetReservationDetails(int id);
        ReservationListVm GetAllResevationToList(int pageNumber, int pageSize, string searchString);

    }
}
