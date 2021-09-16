using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    public class TypeOfBookController : Controller
    {
        private readonly ITypeOfBookService _typeOfBookService;
        public TypeOfBookController(ITypeOfBookService typeOfBookService)
        {
            _typeOfBookService = typeOfBookService;
        }

        public IActionResult Index()
        {
            var typeOfBooks = _typeOfBookService.GetAllTypeOfBooksToList();
            return View(typeOfBooks);
        }

        [HttpGet]
        public IActionResult CreateTypeOfBook()
        {
             var typeOfBook = new TypeOfBookVm();
             return PartialView("_TypeOfBookModelPartialForCreate", typeOfBook);
        }

        [HttpPost]
        public IActionResult CreateTypeOfBook(TypeOfBookVm typeOfBook)
        {
            _typeOfBookService.AddTypeOfBook(typeOfBook);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTypeOfBook(int id)
        {
            var typeOfBook = _typeOfBookService.GetTypeOfBookById(id);
            return PartialView("_TypeOfBookModelPartialForEdit", typeOfBook);
        }

        [HttpPost]
        public IActionResult EditTypeOfBook(TypeOfBookVm model)
        {
            _typeOfBookService.UpdateTypeOfBook(model);
            return RedirectToAction("Index", new { model.Id });
        }

        public IActionResult DeleteTypeOfBook(int id)
        {
            if (id != 1)
            {
                _typeOfBookService.DeleteTypeOfBook(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
