using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCLAB5_BaiTuLam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToAction("Index", "Products");

        public IActionResult Error() => View();
    }
}
