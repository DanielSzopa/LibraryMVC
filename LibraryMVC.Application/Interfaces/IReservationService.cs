using LibraryMVC.Application.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public interface IReservationService
    {
        NewReservationVm GetReservationVm(int bookId, string userId);
    }
}
