using Microsoft.AspNetCore.Mvc;

namespace PharmaM.Controllers
{
    public class ApplicationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
