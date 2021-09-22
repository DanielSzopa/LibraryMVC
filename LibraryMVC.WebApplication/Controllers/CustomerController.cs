using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public CustomerController(IUserService userService, ICustomerService customerService)
        {
            _userService = userService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCustomerProfil()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var customer = _customerService.GetCustomerDetailsByUserId(currentUserId);
            return View(customer);
        }

    }
}
