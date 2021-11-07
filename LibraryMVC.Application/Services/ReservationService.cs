using LibraryMVC.Application.ViewModels.Reservation;
using LibraryMVC.Domain.Interfaces;
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
