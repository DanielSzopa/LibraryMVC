using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IUserService userService, ILogger<RoleController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [Route("role/all")]
        public IActionResult Index()
        {
            var listOfRoles = _userService.GetAllRolesToList();
            return View(listOfRoles);
        }

        [Route("role/{roleId}")]
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

        [Route("role/Update/{roleId}/{userId}")]
        public IActionResult UpdateRole(string userId, string roleId)
        {
            _userService.UpdateRole(userId, roleId);
            _logger.LogInformation($"Role for {userId} has been changed to {roleId}");

            return RedirectToAction("ViewUsers", new { roleId = roleId});
        }
    }
}
