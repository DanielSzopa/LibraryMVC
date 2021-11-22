using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        public ReservationService(IReservationRepository reservationRepository, IBookService bookService, ICustomerService customerService)
        {
            _reservationRepository = reservationRepository;
            _bookService = bookService;
            _customerService = customerService;
        }

        public int AddReservation(NewReservationVm reservationVm)
        {
            var reservation = new Reservation
            {
                BookId = reservationVm.BookId,
                CustomerId = reservationVm.CustomerId,
                From = reservationVm.ReservationFrom,
                To = reservationVm.ReservationTo
            };

            _bookService.ChangeActiveOfBook(reservation.BookId);
            var reservationId = _reservationRepository.AddReservation(reservation);
            return reservationId;
        }

        public NewReservationVm GetReservationVm(int bookId, string userId)
        {
            var book = _bookService.GetBookById(bookId);
            var customer = _customerService.GetCustomerByUserId(userId);


            var reservationVm = new NewReservationVm
            {
                BookId = bookId,
                CustomerId = customer.Id,
                Title = book.Title,
                Author = $"{book.Author.FirstName} {book.Author.LastName}",
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerEmail = customer.CustomerContactDetail.Mail,
                CustomerPesel = customer.Pesel,
                ReservationFrom = DateTime.Now,
                ReservationTo = DateTime.Now.AddDays(7)
            };

            return reservationVm;
        }
      
    }
}
