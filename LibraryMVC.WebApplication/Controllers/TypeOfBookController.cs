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
        public IActionResult Create()
        {
             var typeOfBook = new TypeOfBookVm();
             return PartialView("_TypeOfBookModelPartial", typeOfBook);
        }

        [HttpPost]
        public IActionResult Create(TypeOfBookVm typeOfBook)
        {
            _typeOfBookService.AddTypeOfBook(typeOfBook);
            return RedirectToAction("Index");
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
