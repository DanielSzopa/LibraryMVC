using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public RentalController(IRentalService rentalService,IUserService userService, ICustomerService customerService)
        {
            _rentalService = rentalService;
            _userService = userService;
            _customerService = customerService;
        }

        [Route("rental/all")]
        public IActionResult Index(int pageNumber, string searchString, int rentalsByCustomerId, string whoRentalFilter)
        {
            int pageSize = 8;

            if (pageNumber == 0)
                pageNumber = 1;

            if (searchString is null)
                searchString = string.Empty;

            if (whoRentalFilter == "my")
            {
                var userId = _userService.GetCurrentUserId();
                var customerId = _customerService.GetCustomerIdByUserId(userId);
                rentalsByCustomerId = customerId;
            }

            var rentalList = _rentalService
                .GetAllRentalsToList(pageNumber, pageSize, searchString, rentalsByCustomerId, whoRentalFilter);
            return View(rentalList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateRentalByReservation(int bookId, int customerId, int reservationId)
        {
            var rentalValues = _rentalService.GetRentalVm(bookId, customerId, reservationId);
            return PartialView("_RentalModelPartial", rentalValues);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateRentalByReservation(RentalDetailsVm rentalVm)
        {
            var rentalId = _rentalService.AddRental(rentalVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateLocalRental()
        {
            var rentalValues = _rentalService.SetParametrsToLocalReservationVm();
            return PartialView("_LocalRentalModelPartial", rentalValues);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateLocalRental(LocalRentalVm localRentalVm)
        {
            var rentalId = _rentalService.AddLocalRental(localRentalVm);
            return RedirectToAction("Index");
        }
    }
}
