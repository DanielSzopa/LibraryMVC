using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IReservationService
    {
        NewReservationVm GetReservationVm(int bookId, string userId);

        int AddReservation(NewReservationVm reservationVm);
    }
}
