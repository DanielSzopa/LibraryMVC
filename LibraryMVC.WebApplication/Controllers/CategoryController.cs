using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("category/all")]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategoriesToList();
            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateCategory()
        {
            var category = new CategoryVm();
            return PartialView("_CategoryModelPartialForCreate", category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult CreateCategory(CategoryVm category)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return PartialView("_CategoryModelPartialForEdit", category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult EditCategory(CategoryVm model)
        {
            _categoryService.UpdateCategory(model);
            return RedirectToAction("Index", new { model.Id });
        }

        [Authorize(Roles = "Admin, Employee")]
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
