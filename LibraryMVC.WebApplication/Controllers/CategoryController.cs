using LibraryMVC.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC.WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.Category = _categoryService.GetAllCategoriesToList().CategoriesOfBooks;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(CategoryVm category)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            if (id != 1)
            {
                _categoryService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
