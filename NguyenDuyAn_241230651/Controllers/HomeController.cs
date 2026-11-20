using Microsoft.AspNetCore.Mvc;
using NguyenDuyAn_241230651.Models;

namespace NguyenDuyAn_241230651.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext db;

        public HomeController(QLNhaSachContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            ViewBag.TheLoais = db.TheLoais.ToList();
            var sach = db.Saches
        .Where(s => s.Gia >= 100)
        .ToList();
            return View(sach);
        }
        public IActionResult LocSach(int maTL)
        {
            var sach = db.Saches
                .Where(s => s.Gia >= 100 &&
                            (maTL == 0 || s.MaTl == maTL))
                .ToList();

            return PartialView("~/Views/Shared/_DanhSachSach.cshtml", sach);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TheLoais = db.TheLoais.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TheLoais = db.TheLoais.ToList();
            return View(sach);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}