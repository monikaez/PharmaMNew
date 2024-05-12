using Microsoft.AspNetCore.Mvc;
using PharmaM.Core.Contracts;
using PharmaM.Core.Models.Category;
using PharmaM.Core.Services;

namespace PharmaM.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await categoryService.AddCategoryAsync(model);
            return View(model);
        }
    }
}
