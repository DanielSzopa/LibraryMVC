using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryMVC.WebApplication.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index(int pageNumber, string searchString)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            int pageSize = 2;
            var authors = _authorService.GetAllAuthorToList(pageNumber, pageSize, searchString);
            return View(authors);
        }

        public IActionResult AuthorDetails(int id, bool isAuthorDetailsByBookID)
        {
            if (isAuthorDetailsByBookID == true)
            {
                var authorByBookId = _authorService.GetAuthorDetailsByBookId(id);
                return View(authorByBookId);
            }
            var author = _authorService.GetAuthorDetailsByAuthorId(id);
            return View(author);
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View(new NewAuthorVm());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddAuthor(NewAuthorVm newAuthorVm)
        {
            var newAuthor = _authorService.AddAuthor(newAuthorVm);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAuthor(int id)
        {
            if (id != 1)
            {
                _authorService.DeleteAuthor(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = _authorService.GetAuthorForEdit(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult EditAuthor(AuthorDetailsVm model)
        {
           var authorId =  _authorService.EditAuthor(model);
            return RedirectToAction("Index");
        }

    }
}
