using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationService _reservationService;
        public ReservationService(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
    }
}
