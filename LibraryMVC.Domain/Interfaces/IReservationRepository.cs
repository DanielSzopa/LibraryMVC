using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IReservationRepository
    {
        int AddReservation(Reservation reservation);
        void DeleteReservation(int id);
        int GetBookIdByReservation(int id);
        Reservation GetReservationDetails(int id);
        IQueryable<Reservation> GetAllReservation();
    }
}
