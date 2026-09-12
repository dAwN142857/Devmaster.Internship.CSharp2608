using Bai4Views.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bai4Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
    {
        new Product
        {
            Name = "Nồi cơm điện cao tần Nagakawa NAG0102"
        },
        new Product
        {
            Name = "Nồi cơm điện cao tần Nagakawa NAG0102"
        },
        new Product
        {
            Name = "Nồi cơm điện cao tần Nagakawa NAG0102"
        }
    };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
