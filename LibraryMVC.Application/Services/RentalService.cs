using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMVC.Application
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private readonly IPaginationService _pagerService;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public RentalService(IRentalRepository rentalRepository, ICustomerService customerService
            ,IBookService bookService,IPaginationService paginationService,IMapper mapper,
            IReservationRepository reservationRepository)
        {
            _rentalRepository = rentalRepository;
            _customerService = customerService;
            _bookService = bookService;
            _pagerService = paginationService;
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public int AddRental(RentalDetailsVm rentalVm)
        {
            var rental = new Rental
            {
                BookId = rentalVm.BookId,
                CustomerId = rentalVm.CustomerId,
                From = rentalVm.From,
                To = rentalVm.To
            };

            if(!(rentalVm.ReservationId == 0))
            _reservationRepository.DeleteReservation(rentalVm.ReservationId);

            var status = Status.Rental;
            _bookService.ChangeStatusOfBook(rentalVm.BookId, status);

            var rentalId = _rentalRepository.AddRental(rental);
            return rentalId;
        }

        public int AddLocalRental(LocalRentalVm rentalVm)
        {
            var rentalDetailsVm = _mapper.Map<RentalDetailsVm>(rentalVm);
            var rentalId = AddRental(rentalDetailsVm);

            return rentalId;
        }

        public void DeleteRental(int rentalId)
        {
            var bookId = _rentalRepository.GetBookIdByRental(rentalId);
            var status = Status.Active;
            _bookService.ChangeStatusOfBook(bookId, status);

            _rentalRepository.DeleteRental(rentalId);
        }

        public RentalDetailsVm GetRentalVm(int bookId, int customerId, int reservationId)
        {
            var book = _bookService.GetBookDetailsForReservationOrRental(bookId);
            var customerVm = _customerService.GetCustomerForRentalByCustomerId(customerId);

            var rentalVm = new RentalDetailsVm
            {
                BookId = bookId,
                CustomerId = customerVm.Id,
                ReservationId = reservationId,
                Title = book.Title,
                Author = book.Author,
                CustomerFirstName = customerVm.FirstName,
                CustomerLastName = customerVm.LastName,
                CustomerEmail = customerVm.Mail,
                CustomerPesel = customerVm.Pesel,
                From = DateTime.Now,
                To = DateTime.Now.AddMonths(3)
            };

            return rentalVm;
        }

        public RentalListVm GetAllRentalsToList(int pageNumber, int pageSize, string searchString, int customerId, string whoRentalFilter)
        {
            var rentals = default(IQueryable<Rental>);
            switch (whoRentalFilter)
            {
                case "my":
                    rentals = _rentalRepository.GetAllCustomerRentals(customerId);
                    break;
                case "customer":
                    rentals = _rentalRepository.GetAllCustomerRentals(customerId);
                    break;
                case "all":
                    rentals = _rentalRepository.GetAllRentals();
                    break;
            }
            if (rentals is null)
            {
                var defaultRentals = new List<Rental>();
                rentals = defaultRentals.AsQueryable<Rental>();
            }
               

                var rentalsVm = rentals
                    .Where(r => r.Book.Title.Contains(searchString) || (r.Customer.FirstName + " " + r.Customer.LastName).Contains(searchString))
                    .ProjectTo<RentalForListVm>(_mapper.ConfigurationProvider).ToList();

                var records = _pagerService.ReturnRecordsToShow(pageNumber, pageSize, rentalsVm);
                var result = new RentalListVm
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    SearchString = searchString,
                    Count = rentalsVm.Count,
                    ListOfRentalForListVm = records,
                    RentalByCustomerId = customerId,
                    WhoRentalFilter = whoRentalFilter
                };

            return result;
        }


        public LocalRentalVm SetParametrsToLocalReservationVm()
        {
            var customersFullNames = _customerService.GetAllCustomersFullName()
               .OrderBy(c => c.CustomerFullName).ToList();

            var booksFullNames = _bookService.GetAllActiveBooksFullName()
                .OrderBy(b => b.BookFullName).ToList();

            var localRental = new LocalRentalVm
            {
                Customers = customersFullNames,
                Books = booksFullNames,
                From = DateTime.Now,
                To = DateTime.Now.AddMonths(3)
            };
            return localRental;
        }
    }
}
