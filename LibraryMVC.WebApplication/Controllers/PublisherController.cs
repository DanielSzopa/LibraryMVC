using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [Route("publisher/all")]
        public IActionResult Index()
        {
            var publishers = _publisherService.GetAllPublishersToList();
            return View(publishers);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreatePublisher()
        {
            var publisher = new PublisherVm();
            return PartialView("_PublisherModelPartialForCreate", publisher);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreatePublisher(PublisherVm publisher)
        {
            _publisherService.AddPublisher(publisher);
            return RedirectToAction("Index");
        } 

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            return PartialView("_PublisherModelPartialForEdit", publisher);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditPublisher(PublisherVm model)
        {
            _publisherService.UpdatePublisher(model);
            return RedirectToAction("Index", new { model.Id });
        }

        [Authorize(Roles = "Admin, Employee")]
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
