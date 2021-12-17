using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public CustomerController(IUserService userService, ICustomerService customerService)
        {
            _userService = userService;
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin, Employee")]
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
            int pageSize = 10;
            var customers = _customerService.GetAllCustomerToList(pageNumber, pageSize, searchString);
            return View(customers);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AddCustomer(bool isLocalAccount)
        {
            var customer = new NewCustomerVm();
            customer.isLocalAccount = isLocalAccount;
            return View(customer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AddCustomer(NewCustomerVm newCustomerVm)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var customerId = _customerService.AddCustomer(newCustomerVm);
            return RedirectToAction("CustomerDetails", new { id = customerId});
        }   

        [HttpGet]
        public IActionResult ViewCustomerProfil()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var customer = _customerService.GetCustomerDetailsByUserId(currentUserId);
            return View(customer);
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CustomerDetails(int id)
        {
            var customerVm = _customerService.GetCustomerDetailsByCustomerId(id);
            return View(customerVm);
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            ViewBag.FormAction = "EditProfile";
            ViewBag.Title = "Edit Profile";
            ViewBag.smallTitle = "profile";

            return View("EditCustomer", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(NewCustomerVm newCustomerVm)
        {
            var customerId = _customerService.UpdateCustomer(newCustomerVm);
            return RedirectToAction("ViewCustomerProfil", new { id = customerId });
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditCustomer(int id)
        {
            var customer = _customerService.GetCustomerForEdit(id);
            ViewBag.FormAction = "EditCustomer";
            ViewBag.Title = "Edit Customer";
            ViewBag.smallTitle = "customer";

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditCustomer(NewCustomerVm newCustomerVm)
        {
            var customerId = _customerService.UpdateCustomer(newCustomerVm);
            return RedirectToAction("CustomerDetails", new { id = customerId });
        }
    }
}
