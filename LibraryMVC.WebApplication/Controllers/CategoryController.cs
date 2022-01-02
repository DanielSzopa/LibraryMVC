using LibraryMVC.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVC.WebApplication
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
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
                _logger.LogInformation($"Category with id:{id} has been deleted");
                return RedirectToAction("Index");
            }
            _logger.LogInformation($"Category with id:{id} can not be deleted");
            return RedirectToAction("Index");
        }      
    }
}
