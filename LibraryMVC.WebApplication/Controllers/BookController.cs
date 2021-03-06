using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly ITypeOfBookService _typeOfBookService;
        private readonly IAuthorService _authorService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ICategoryService categoryService, 
            IPublisherService publisherService, 
            ITypeOfBookService typeOfBookService, 
            IAuthorService authorService,
            ILogger<BookController> logger)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _typeOfBookService = typeOfBookService;
            _authorService = authorService;
            _logger = logger;
        }

        [Route("book/all")]
        public IActionResult Index(int pageNumber, int filterId, string filter, string searchString)
        {        
            if (pageNumber == 0)
                pageNumber = 1;

            if(searchString is null)
                searchString = String.Empty;

            int pageSize = 8;
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
        [Route("book/new")]
        public IActionResult AddBook()
        {
            var model = new NewBookVm();
            _bookService.SetParametersToVm(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        [Route("book/new")]
        public IActionResult AddBook(NewBookVm newBookVm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var addedBookId = _bookService.AddBook(newBookVm);
            return RedirectToAction("DetailsBook", new { id = addedBookId });            
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            _logger.LogInformation($"Book with id:{id} has been deleted");
            return RedirectToAction("Index");
        }

        [Route("book/details/{id}")]
        public IActionResult DetailsBook(int id)
        {
            var book = _bookService.GetBookDetails(id);
            return View(book);
        }
      
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("book/edit/{id}")]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        [Route("book/edit/{id}")]
        public IActionResult EditBook(NewBookVm model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _bookService.UpdateBook(model);
            return RedirectToAction("DetailsBook", new { model.Id });
        }         
    }
}
