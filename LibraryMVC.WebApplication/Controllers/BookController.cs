using LibraryMVC.Application;
using LibraryMVC.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly ITypeOfBookService _typeOfBookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, ICategoryService categoryService, 
            IPublisherService publisherService, 
            ITypeOfBookService typeOfBookService, 
            IAuthorService authorService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _typeOfBookService = typeOfBookService;
            _authorService = authorService;
        }  
        
        public IActionResult Index(int pageNumber, int filterId, string filter, string searchString)
        {        
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            int pageSize = 10;
            var books = _bookService.GetAllBooksToList(pageNumber, pageSize, searchString, filter, filterId);

            switch(filter)
            {
                case "Category":
                    ViewBag.Title = _categoryService.GetCategoryById(filterId).Name;
                    return View(books);
                case "Publisher":
                    ViewBag.Title = _publisherService.GetPublisherById(filterId).Name;
                    return View(books);
                case "TypeOfBook":
                    ViewBag.Title = _typeOfBookService.GetTypeOfBookById(filterId).Name;
                    return View(books);
                case "Author":
                    var authorFullName = _authorService.GetAuthorFullName(filterId);
                    ViewBag.Title = authorFullName;
                    return View(books);
            }         
            ViewBag.Title = "Books";
            return View(books);
        }   
        
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AddBook()
        {
            var model = new NewBookVm();
            _bookService.SetParametersToVm(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AddBook(NewBookVm newBookVm)
        {                  
                var addedBookId =  _bookService.AddBook(newBookVm);
                return RedirectToAction("DetailsBook", new { id = addedBookId});           
        }

        [Authorize(Roles = "Admin, Employee")]
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
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
                return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditBook(NewBookVm model)
        {            
            _bookService.UpdateBook(model);
            return RedirectToAction("DetailsBook", new { model.Id });
        }         
    }
}
