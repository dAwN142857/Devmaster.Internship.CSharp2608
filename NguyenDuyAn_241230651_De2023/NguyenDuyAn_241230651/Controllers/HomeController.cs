using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenDuyAn_241230651.Models;

namespace NguyenDuyAn_241230651.Controllers
{
    public class HomeController : Controller
    {
        private const string HoTen = "Nguyễn Duy An";

        private readonly QLHangHoaContext _context;

        public HomeController(QLHangHoaContext context)
        {
            _context = context;
        }

        // Nạp LoaiHang cho thanh điều hướng (Header)
        private async Task NapLoaiHang()
        {
            ViewBag.LoaiHang = await _context.LoaiHangs
                .OrderBy(x => x.MaLoai)
                .ToListAsync();
        }

        // Nạp danh sách LoaiHang cho ô DropDownList ở form Thêm hàng hóa
        private async Task NapDropDownLoai(int? maLoaiDangChon = null)
        {
            var dsLoai = await _context.LoaiHangs
                .OrderBy(x => x.MaLoai)
                .ToListAsync();

            ViewBag.DsLoai = new SelectList(dsLoai, "MaLoai", "TenLoai", maLoaiDangChon);
        }

        // ===== Câu 3: danh sách HangHoa có gia >= 100 =====
        public async Task<IActionResult> Index()
        {
            await NapLoaiHang();
            ViewBag.TieuDe = HoTen;

            var ds = await _context.HangHoas
                .Where(x => x.Gia >= 100)
                .OrderBy(x => x.MaHang)
                .ToListAsync();

            return View(ds);
        }

        // ===== Câu 4: lọc theo LoaiHang bằng AJAX =====
        public async Task<IActionResult> Filter(int id)
        {
            await NapLoaiHang();
            ViewBag.TieuDe = HoTen;

            var ds = await _context.HangHoas
                .Where(x => x.MaLoai == id && x.Gia >= 100)
                .OrderBy(x => x.MaHang)
                .ToListAsync();

            // Request AJAX -> chỉ trả về phần MainContent
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("NguyenDuyAn_MainContent", ds);
            }

            // Mở trực tiếp bằng URL -> trả về cả trang
            return View("Index", ds);
        }

        // ===== Câu 5.1: thêm hàng hóa =====
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await NapLoaiHang();
            await NapDropDownLoai();
            return View(new HangHoa());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangHoa hangHoa)
        {
            // Không nhận thuộc tính điều hướng từ form
            ModelState.Remove(nameof(HangHoa.MaLoaiNavigation));

            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await NapLoaiHang();
            await NapDropDownLoai(hangHoa.MaLoai);
            return View(hangHoa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
