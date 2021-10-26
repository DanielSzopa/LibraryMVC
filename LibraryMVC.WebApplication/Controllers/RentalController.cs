using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            rentalService = _rentalService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
