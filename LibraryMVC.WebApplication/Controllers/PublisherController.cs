using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public IActionResult Index()
        {
            var publishers = _publisherService.GetAllPublishersToList();
            return View(publishers);
        }
    }
}
