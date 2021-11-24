using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IReservationService
    {
        NewReservationVm GetReservationVm(int bookId, string userId);
        int AddReservation(NewReservationVm reservationVm);
        ReservationListVm GetAllResevationToList(int pageNumber, int pageSize, string searchString);
    }
}
