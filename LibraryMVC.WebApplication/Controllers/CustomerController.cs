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

        public IActionResult Index(int pageNumber, string searchString)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            int pageSize = 2;
            var customers = _customerService.GetAllCustomerToList(pageNumber, pageSize, searchString);
            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer(bool isLocalAccount)
        {
            var customer = new NewCustomerVm();
            customer.isLocalAccount = isLocalAccount;
            return View(customer);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVm newCustomerVm)
        {
           var customerId = _customerService.AddCustomer(newCustomerVm);
            return RedirectToAction("CustomerDetails", new { id = customerId});
        }   

        public IActionResult ViewCustomerProfil()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var customer = _customerService.GetCustomerDetailsByUserId(currentUserId);
            return View(customer);
        }

        public IActionResult CustomerDetails(int id)
        {
            var customerVm = _customerService.GetCustomerDetailsByCustomerId(id);
            return View(customerVm);
        }

       
    }
}
