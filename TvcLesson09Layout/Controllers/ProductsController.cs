using Microsoft.AspNetCore.Mvc;

namespace TvcLesson09Layout.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
        public IActionResult Hots()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
