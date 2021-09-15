using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 2)
        {
            var authors = _authorService.GetAllAuthorToList(pageNumber, pageSize);
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
