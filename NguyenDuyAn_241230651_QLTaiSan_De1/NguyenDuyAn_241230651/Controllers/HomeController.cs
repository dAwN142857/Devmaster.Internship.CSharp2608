
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenDuyAn_241230651.Models;

namespace NguyenDuyAn_241230651.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _context;

        public HomeController(QLTaiSanContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.LoaiTaiSan = await _context.LoaiTaiSans.ToListAsync();

            ViewBag.MainTitle = "Nguyễn Duy An";

            var ds = await _context.TaiSans
                .Where(x => x.NguyenGia.HasValue && x.NguyenGia.Value >= 20)
                .ToListAsync();

            return View(ds);
        }

        public async Task<IActionResult> Filter(int id)
        {
            var loai = await _context.LoaiTaiSans
                .FirstOrDefaultAsync(x => x.MaLoai == id);

            if (loai == null)
                return NotFound();

            ViewBag.MainTitle = loai.TenLoai;

            var ds = await _context.TaiSans
                .Where(x => x.MaLoai == id)
                .ToListAsync();

            return PartialView("_TaiSanList", ds);
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            ViewBag.MaLoai = new SelectList(
                await _context.LoaiTaiSans.ToListAsync(),
                "MaLoai",
                "TenLoai"
            );

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                _context.TaiSans.Add(taiSan);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            ViewBag.MaLoai = new SelectList(
                await _context.LoaiTaiSans.ToListAsync(),
                "MaLoai",
                "TenLoai",
                taiSan.MaLoai
            );

            return View(taiSan);
        }
    }
}
