using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        public ReservationController(IReservationService reservationService, IUserService userService)
        {
            _reservationService = reservationService;
            _userService = userService;
        }
        public IActionResult Index(int pageNumber, string searchString)
        {
            if(pageNumber == 0)
            {
                pageNumber = 1;
            }
            if(searchString is null)
            {
                searchString = string.Empty;
            }
            int pageSize = 10;
            var resevationList = _reservationService.GetAllResevationToList(pageNumber,pageSize,searchString);
            return View(resevationList);
        }

        [HttpGet]
        public IActionResult CreateReservation(int bookId)
        {
            var userId = _userService.GetCurrentUserId();
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
        public IActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction("Index");
        }
    }
}
