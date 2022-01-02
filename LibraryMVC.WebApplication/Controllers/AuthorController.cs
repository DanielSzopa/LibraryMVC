using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [Route("author/all")]
        public IActionResult Index(int pageNumber, string searchString)
        {
            if (pageNumber == 0)
                pageNumber = 1;

            if (searchString is null)
                searchString = String.Empty;

            int pageSize = 10;
            var authors = _authorService.GetAllAuthorToList(pageNumber, pageSize, searchString);
            return View(authors);
        }

        [Route("author/details/{id}/{isAuthorDetailsByBookId}")]
        public IActionResult AuthorDetails(int id, bool isAuthorDetailsByBookId)
        {
            if (isAuthorDetailsByBookId == true)
            {
                var authorByBookId = _authorService.GetAuthorDetailsByBookId(id);
                return View(authorByBookId);
            }
            var author = _authorService.GetAuthorDetailsByAuthorId(id);
            return View(author);
        }
    
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("author/new")]
        public IActionResult AddAuthor()
        {
            return View(new NewAuthorVm());
        }      
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AddAuthor(NewAuthorVm newAuthorVm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var newAuthorId = _authorService.AddAuthor(newAuthorVm);
            return RedirectToAction("AuthorDetails", new { id = newAuthorId });
        }

        [Authorize(Roles = "Admin, Employee")]
        public IActionResult DeleteAuthor(int id)
        {
            if (id != 1)
            {
                _authorService.DeleteAuthor(id);
                _logger.LogInformation($"Author with id:{id} has been deleted");
                return RedirectToAction("Index");
            }
            _logger.LogInformation($"Author with id:{id} can not be deleted");
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("author/edit{id}")]
        public IActionResult EditAuthor(int id)
        {
            var author = _authorService.GetAuthorForEdit(id);
            return View(author);
        }

      
        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        [Route("author/edit{id}")]
        public IActionResult EditAuthor(AuthorDetailsVm model)
        {
           var authorId =  _authorService.EditAuthor(model);
            return RedirectToAction("Index");
        }

    }
}
