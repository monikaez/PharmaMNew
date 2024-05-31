using Microsoft.AspNetCore.Mvc;
using PharmaM.Core.Contracts;
using PharmaM.Core.Models.Category;
using PharmaM.Core.Models.Product;

namespace PharmaM.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await productService.GetAllAsync();
            return View(data);
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    var model = new AddProductViewModel();

        //    return View(model);
        //}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductViewModel();

            var categories = await productService.GetCategories();

            var viewModelCategories = new List<CategoryViewModel>();

            foreach (var item in categories)
            {
                viewModelCategories.Add(new CategoryViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                });

            }
            model.Categories = viewModelCategories;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await productService.AddProductAsync(model);

            TempData["success"] = "A New Product Added";
            return RedirectToAction(nameof(Shop));

        }

        [HttpGet]
        public async Task<IActionResult> SingleProduct(int id)
        {
            var data = await productService.GetProductById(id);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Shop()
        {
            var data = await productService.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            var data = await productService.Search(searchString);
            return View("Shop", data);
        }

        [HttpGet]
        public async Task<IActionResult> Sort(string order)
        {
            var data = await productService.Sort(order);
            return View("Shop", data);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                ModelState.AddModelError(" ", "Invalid product!");
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SingleProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await productService.EditProductAsync(model);

            TempData["success"] = "A Product Edited";
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);

            TempData["success"] = "A Product Deleted";
            return RedirectToAction(nameof(Shop));
        }

    }
}

