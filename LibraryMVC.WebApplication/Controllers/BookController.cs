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
        
        public IActionResult Index(int pageNumber, int categoryId, int publisherId, int typeOfBookId, int authorId, string searchString)
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
            var books = _bookService.GetAllBooksToList(pageNumber, pageSize, searchString, categoryId, publisherId, typeOfBookId, authorId);
            if(categoryId != 0)
            {
                ViewBag.Title = _categoryService.GetCategoryById(categoryId).Name;
                return View(books);
            }
            else if(publisherId != 0) 
            {
                ViewBag.Title = _publisherService.GetPublisherById(publisherId).Name;
                return View(books);
            }
            else if(typeOfBookId != 0)
            {
                ViewBag.Title = _typeOfBookService.GetTypeOfBookById(typeOfBookId).Name;
                return View(books);
            }
            else if (authorId != 0)
            {
                var author = _authorService.GetAuthorById(authorId);
                ViewBag.Title = $"{author.FirstName} {author.LastName}";
                return View(books);
            }
            ViewBag.Title = "Books";
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
