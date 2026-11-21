
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenDuyAn_241230651.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var taiSan = await _context.TaiSans.FindAsync(id);

            if (taiSan == null)
                return NotFound();

            ViewBag.MaLoai = new SelectList(
                await _context.LoaiTaiSans.ToListAsync(),
                "MaLoai",
                "TenLoai",
                taiSan.MaLoai
            );

            return View(taiSan);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaiSan taiSan)
        {
            if (id != taiSan.MaTs)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.TaiSans.Update(taiSan);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
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
