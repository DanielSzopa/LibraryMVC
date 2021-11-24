using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryMVC.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerService;
        private readonly IPaginationService _pagerService;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, 
            IBookService bookService, ICustomerService customerService
            ,IPaginationService paginationService, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _bookService = bookService;
            _customerService = customerService;
            _pagerService = paginationService;
            _mapper = mapper;
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

        public ReservationListVm GetAllResevationToList(int pageNumber, int pageSize, string searchString)
        {
            var reservationsVm = _reservationRepository.GetAllReservation()
                .Where(r => r.Book.Title.Contains(searchString) || (r.Customer.FirstName + " " + r.Customer.LastName).Contains(searchString))
                .ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();
            
            var records = _pagerService.ReturnRecordsToShow(pageNumber,pageSize,reservationsVm);
            var result = new ReservationListVm
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchString = searchString,
                Count = reservationsVm.Count,
                ListOfReservationForListVm = records
            };

            return result;
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
