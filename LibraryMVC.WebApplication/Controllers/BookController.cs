using LibraryMVC.Application;
using LibraryMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryMVC.WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }   
        public IActionResult Index(int pageNumber, int categoryId, int publisherId, int typeOfBookId, string searchString)
        {        
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            int pageSize = 2;
            var books = _bookService.GetAllBooksToList(pageNumber, pageSize, searchString, categoryId, publisherId, typeOfBookId);           

            return View(books);
        }      
        [HttpGet]
        public IActionResult AddBook()
        {
            var model = new NewBookVm();
            _bookService.SetParametersToVm(model);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(NewBookVm newBookVm)
        {                  
                var addedBookId =  _bookService.AddBook(newBookVm);
                return RedirectToAction("DetailsBook", new { id = addedBookId});           
        }

        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }


        public IActionResult DetailsBook(int id)
        {
            var book = _bookService.GetBookDetails(id);
            return View(book);
        }
      
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
                return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBook(NewBookVm model)
        {            
            _bookService.UpdateBook(model);
            return RedirectToAction("DetailsBook", new { model.Id });
        }
   
        
    }
}
