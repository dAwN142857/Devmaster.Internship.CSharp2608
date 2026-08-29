using Microsoft.AspNetCore.Mvc;

namespace TvcLesson03.Controllers
{
    /// <summary>
    /// Name: TvcAbout
    /// Author: Chung Trịnh
    /// </summary>
    public class TvcAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Trịnh Văn Chung";
            ViewData["class"]="K65CNT2-LTW";
            TempData["module"] = "Lập trình web 1 -1";
            return View();
        }
    }
}
