using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryMVC.WebApplication
{

    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public ReservationController(IReservationService reservationService, IUserService userService, ICustomerService customerService)
        {
            _reservationService = reservationService;
            _userService = userService;
            _customerService = customerService;
        }

        public IActionResult Index(int pageNumber, string searchString, int reservationsByCustomerId, string whoReservationFilter)
        {
            int pageSize = 8;

            if (pageNumber == 0)
                pageNumber = 1;

            if(searchString is null)
                searchString = string.Empty;

            if(whoReservationFilter == "my")
            {
                var userId = _userService.GetCurrentUserId();
                var customerId = _customerService.GetCustomerIdByUserId(userId);
                reservationsByCustomerId = customerId;
            }    
            
            var resevationList = _reservationService
                .GetAllResevationToList(pageNumber, pageSize, searchString, reservationsByCustomerId, whoReservationFilter);
            return View(resevationList);
        }

        [HttpGet]
        public IActionResult CreateReservation(int bookId)
        {
            var userId = _userService.GetCurrentUserId();
            var result = _customerService.IsCustomerDetailsAreCorrect(userId);
            if(!result)
            {
                return PartialView("_ReservationErrorModelPartial");
            }
            var reservationVm = _reservationService.GetReservationVm(bookId,userId);
            return PartialView("_ReservationModelPartial", reservationVm);
        }
     
        [HttpPost]
        public IActionResult CreateReservation(ReservationDetailsVm reservationVm)
        {
            var reservationId = _reservationService.AddReservation(reservationVm);
            return RedirectToAction("ReservationDetails", new { id = reservationId });
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateLocalReservation()
        {
            var reservationValues = _reservationService.SetParametrsToLocalReservationVm();
            return PartialView("_LocalReservationModelPartial", reservationValues);          
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateLocalReservation(LocalReservationVm localReservationVm)
        {
            var reservationId = _reservationService.AddLocalReservation(localReservationVm);
            return RedirectToAction("ReservationDetails", new { id = reservationId });
        }

        public IActionResult ReservationDetails(int id)
        {
            var reservationVm = _reservationService.GetReservationDetails(id);
            return View(reservationVm);
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult DeleteReservation(int id, int reservationsByCustomerId, string whoReservationFilter)
        {           
            _reservationService.DeleteReservation(id);
            return RedirectToAction("Index", new { reservationsByCustomerId = reservationsByCustomerId, whoReservationFilter = whoReservationFilter });
        }
    }
}
