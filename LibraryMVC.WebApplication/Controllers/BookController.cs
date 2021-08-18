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
        
        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            var books = _bookService.GetAllBooksToList(pageNumber, pageSize);

            return View(books);
        }
        [HttpGet]
        public IActionResult AddNewBook()
        {
            var model = new NewBookVm();
            _bookService.SetParametersToVm(model);

            return View(model);
        }
        [HttpPost]
        public IActionResult AddNewBook(NewBookVm newBookVm)
        {
          var addedBookId =  _bookService.AddBook(newBookVm);
          var newBookId = _bookService.GetBookById(addedBookId);        

            return RedirectToAction("Details", newBookId);
        }

        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookDetails(id);


            return View(book);
        }

        public IActionResult DisplayAuthorDetails(int id)
        {
            var author = _bookService.GetAuthorDetailsByBookId(id);
            return View(author);
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


            return RedirectToAction("Details", new { model.Id });
        }

        public IActionResult DisplayListOfAuthors()
        {
            var authors = _bookService.GetAllAuthorToList();
            return View(authors);
        }

    }
}
