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

        [HttpGet]
        public IActionResult CreateCategory()
        {
            var category = new CategoryVm();
            return PartialView("_CategoryModelPartialForCreate", category);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryVm category)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View("_CategoryModelPartialForEdit", category);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryVm model)
        {
            _categoryService.UpdateCategory(model);
            return RedirectToAction("Index", new { model.Id });
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
