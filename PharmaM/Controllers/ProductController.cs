using Microsoft.AspNetCore.Mvc;
using PharmaM.Core.Contracts;
namespace PharmaM.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> SingleProduct(int id)
        {
            var data = await productService.GetProductById(id);
            return View(data);
        }
        public async Task<IActionResult> Shop()
        {
            var data = await productService.GetAllAsync();
            return View(data);
        }
        
        public async Task<IActionResult> Search(string searchString)
        {
            var data = await productService.Search(searchString);
            return View("Shop", data);
        }

        public async Task<IActionResult> Sort(string order)
        {
            var data = await productService.Sort(order);
            return View("Shop", data);
        }


    }
}
