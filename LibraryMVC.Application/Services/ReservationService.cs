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

        public int AddReservation(ReservationDetailsVm reservationVm)
        {
            var reservation = new Reservation
            {
                BookId = reservationVm.BookId,
                CustomerId = reservationVm.CustomerId,
                From = reservationVm.From,
                To = reservationVm.To
            };
            var status = Status.Reservation;

            _bookService.ChangeStatusOfBook(reservation.BookId, status);
            var reservationId = _reservationRepository.AddReservation(reservation);
            return reservationId;
        }

        public void DeleteReservation(int id)
        {
            var status = Status.Active;
            var bookId = GetBookIdByReservation(id);

            _bookService.ChangeStatusOfBook(bookId, status);
            _reservationRepository.DeleteReservation(id);
        }

        public int GetBookIdByReservation(int id)
        {
            var bookId =  _reservationRepository.GetBookIdByReservation(id);
            return bookId;
        }

        public ReservationDetailsVm GetReservationDetails(int id)
        {
            var reservation = _reservationRepository.GetReservationDetails(id);
            var reservationVm = _mapper.Map<ReservationDetailsVm>(reservation);

            return reservationVm;
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


        public ReservationDetailsVm GetReservationVm(int bookId, string userId)
        {
            var book = _bookService.GetBookById(bookId);
            var customer = _customerService.GetCustomerByUserId(userId);


            var reservationVm = new ReservationDetailsVm
            {
                BookId = bookId,
                CustomerId = customer.Id,
                Title = book.Title,
                Author = $"{book.Author.FirstName} {book.Author.LastName}",
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerEmail = customer.CustomerContactDetail.Mail,
                CustomerPesel = customer.Pesel,
                From = DateTime.Now,
                To = DateTime.Now.AddDays(7)
            };

            return reservationVm;
        }

        public LocalReservationVm SetParametrsToLocalReservationVm()
        {
            var customersFullNames = _customerService.GetAllCustomersFullName().ToList();
            var booksFullNames = _bookService.GetAllActiveBooksFullName().ToList();

            var localReservation = new LocalReservationVm
            {
                Customers = customersFullNames,
                Books = booksFullNames,
                From = DateTime.Now,
                To = DateTime.Now.AddDays(7)
            };
            return localReservation;
        }
    }
}
