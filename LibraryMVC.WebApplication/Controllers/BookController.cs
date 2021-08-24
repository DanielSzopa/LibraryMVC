﻿using LibraryMVC.Application;
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
        [ValidateAntiForgeryToken]
        public IActionResult AddNewBook(NewBookVm newBookVm)
        {                  
                var addedBookId =  _bookService.AddBook(newBookVm);
                return RedirectToAction("Details", new { id = addedBookId});           
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
            return RedirectToAction("Details", new { model.Id });
        }

        public IActionResult DisplayListOfAuthors(int pageNumber = 1, int pageSize = 6)
        {
            var authors = _bookService.GetAllAuthorToList(pageNumber, pageSize);
            return View(authors);
        }
        public IActionResult DisplayAuthorDetails(int id)
        {                   
            var author = _bookService.GetAuthorDetailsByBookId(id);
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
            var newAuthor = _bookService.AddAuthor(newAuthorVm);
            return RedirectToAction("DisplayListOfAuthors");
        }

        public IActionResult DeleteAuthor(int id)
        {
            _bookService.DeleteAuthor(id);
            return RedirectToAction("DisplayListOfAuthors");
        }
      
        public IActionResult DisplayListOfCategories()
        {
            var categories = _bookService.GetAllCategoriesToList();
            return View(categories);
        }
        public IActionResult DisplayListOfTypeOfBooks()
        {
            var typeOfBooks = _bookService.GetAllTypeOfBooksToList();
            return View(typeOfBooks);
        }
        public IActionResult DisplayListOfPublishers()
        {
            var publishers = _bookService.GetAllPublishersToList();
            return View(publishers);
        }
    }
}
