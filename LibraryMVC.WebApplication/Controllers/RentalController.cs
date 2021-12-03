using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
