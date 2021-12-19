using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IUserService _userService;
        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var listOfRoles = _userService.GetAllRolesToList();
            return View(listOfRoles);
        }

        public IActionResult ViewUsers(int pageNumber, string searchString, string roleId)
        {
            if (pageNumber == 0)
                pageNumber = 1;

            if (searchString is null)
                searchString = String.Empty;

            int pageSize = 8;
            var customers = _userService.GetAllForListOfUserForVm(pageNumber, pageSize, searchString, roleId);
            return View(customers);
        }

        public IActionResult UpdateRole(string userId, string roleId)
        {
            _userService.UpdateRole(userId, roleId);
            return RedirectToAction("ViewUsers", new { roleId = roleId});
        }
    }
}
