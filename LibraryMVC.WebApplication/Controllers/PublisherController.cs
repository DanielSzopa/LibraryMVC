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
        [HttpGet]
        public IActionResult Create()
        {
            var publisher = new PublisherVm();
            return PartialView("_PublisherModelPartial", publisher);
        }
        [HttpPost]
        public IActionResult Create(PublisherVm publisher)
        {
            _publisherService.AddPublisher(publisher);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            return View("_PublisherModelPartialForEdit", publisher);
        }

        [HttpPost]
        public IActionResult EditPublisher(PublisherVm model)
        {
            _publisherService.UpdatePublisher(model);
            return RedirectToAction("Index", new { model.Id });
        }

        public IActionResult DeletePublisher(int id)
        {
            if(id != 1)
            {
            _publisherService.DeletePublisher(id);
            return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
