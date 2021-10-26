using LibraryMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Infrastructure
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationRepository(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
    }
}
