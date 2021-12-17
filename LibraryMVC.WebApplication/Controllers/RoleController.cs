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
    }
}
