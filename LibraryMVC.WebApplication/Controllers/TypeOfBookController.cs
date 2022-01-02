using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class TypeOfBookController : Controller
    {
        private readonly ITypeOfBookService _typeOfBookService;
        private readonly ILogger<TypeOfBookController> _logger;

        public TypeOfBookController(ITypeOfBookService typeOfBookService, ILogger<TypeOfBookController> logger)
        {
            _typeOfBookService = typeOfBookService;
            _logger = logger;
        }

        [Route("type/all")]
        public IActionResult Index()
        {
            var typeOfBooks = _typeOfBookService.GetAllTypeOfBooksToList();
            return View(typeOfBooks);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateTypeOfBook()
        {
             var typeOfBook = new TypeOfBookVm();
             return PartialView("_TypeOfBookModelPartialForCreate", typeOfBook);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateTypeOfBook(TypeOfBookVm typeOfBook)
        {
            _typeOfBookService.AddTypeOfBook(typeOfBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditTypeOfBook(int id)
        {
            var typeOfBook = _typeOfBookService.GetTypeOfBookById(id);
            return PartialView("_TypeOfBookModelPartialForEdit", typeOfBook);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditTypeOfBook(TypeOfBookVm model)
        {
            _typeOfBookService.UpdateTypeOfBook(model);
            return RedirectToAction("Index", new { model.Id });
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult DeleteTypeOfBook(int id)
        {
            if (id != 1)
            {
                _typeOfBookService.DeleteTypeOfBook(id);
                _logger.LogInformation($"TypeOfBook with id:{id} has been deleted");
                return RedirectToAction("Index");
            }
            _logger.LogInformation($"TypeOfBook with id:{id} can not be deleted");
            return RedirectToAction("Index");
        }
    }
}
