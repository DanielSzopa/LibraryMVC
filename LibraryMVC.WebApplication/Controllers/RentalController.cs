using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<RentalController> _logger;
        public RentalController(IRentalService rentalService,IUserService userService,
            ICustomerService customerService, ILogger<RentalController> logger)
        {
            _rentalService = rentalService;
            _userService = userService;
            _customerService = customerService;
            _logger = logger;
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
            return RedirectToAction("RentalDetails", new { id = rentalId });
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
            return RedirectToAction("RentalDetails", new { id = rentalId });
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult DeleteRental(int rentalId, int rentalByCustomerId, string whoRentalFilter)
        {
            _rentalService.DeleteRental(rentalId);
            _logger.LogInformation($"Rental with id:{rentalId} has been deleted");

            return RedirectToAction("Index", new { rentalByCustomerId = rentalByCustomerId, whoRentalFilter = whoRentalFilter });
        }

        [Route("rental/details/{id}")]
        public IActionResult RentalDetails(int id)
        {
            var rentalDetailsVm = _rentalService.GetRentalDetails(id);
            return View(rentalDetailsVm);
        }
    }
}
