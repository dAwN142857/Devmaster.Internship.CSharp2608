using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreMVCLAB5_BaiTuLam.Models;
using NetCoreMVCLAB5_BaiTuLam.Services;

namespace NetCoreMVCLAB5_BaiTuLam.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private const long MaxFileSize = 2 * 1024 * 1024; // 2 MB

        private readonly DataStore _store;
        private readonly IWebHostEnvironment _env;

        public ProductsController(DataStore store, IWebHostEnvironment env)
        {
            _store = store;
            _env = env;
        }

        // GET: /Products
        public IActionResult Index()
        {
            return View(_store.GetProducts());
        }

        // GET: /Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var product = _store.GetProduct(id.Value);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            LoadCategories();
            return View(new Product());
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Price,SalePrice,Description,CategoryId,ImageFile")] Product product)
        {
            // Create: bắt buộc phải chọn ảnh
            if (product.ImageFile == null || product.ImageFile.Length == 0)
                ModelState.AddModelError(nameof(Product.ImageFile), "Vui lòng chọn hình ảnh cho sản phẩm.");
            else
                ValidateImage(product.ImageFile);

            ValidateCategory(product);

            if (!ModelState.IsValid)
            {
                LoadCategories(product.CategoryId);
                return View(product);
            }

            product.Image = await SaveImageAsync(product.ImageFile);
            _store.Add(product);

            TempData["Success"] = "Thêm sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = _store.GetProduct(id.Value);
            if (product == null) return NotFound();

            LoadCategories(product.CategoryId);
            return View(product);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,Price,SalePrice,Description,CategoryId,ImageFile")] Product product)
        {
            if (id != product.Id) return NotFound();

            var existing = _store.GetProduct(id);
            if (existing == null) return NotFound();

            // Edit: ảnh mới là tùy chọn (không chọn thì giữ ảnh cũ)
            bool hasNewImage = product.ImageFile != null && product.ImageFile.Length > 0;
            if (hasNewImage) ValidateImage(product.ImageFile);

            ValidateCategory(product);

            if (!ModelState.IsValid)
            {
                product.Image = existing.Image; // để view vẫn hiển thị ảnh hiện tại
                LoadCategories(product.CategoryId);
                return View(product);
            }

            if (hasNewImage)
            {
                var newName = await SaveImageAsync(product.ImageFile);
                DeleteImage(existing.Image);
                product.Image = newName;
            }
            else
            {
                product.Image = existing.Image;
            }

            _store.Update(product);

            TempData["Success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var product = _store.GetProduct(id.Value);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _store.GetProduct(id);
            if (product != null)
            {
                DeleteImage(product.Image);
                _store.Remove(id);
                TempData["Success"] = "Đã xóa sản phẩm.";
            }
            return RedirectToAction(nameof(Index));
        }

        // ================= Helpers =================

        private void LoadCategories(int selectedId = 0)
        {
            ViewBag.Categories = new SelectList(_store.GetCategories(), "Id", "Name", selectedId);
        }

        // CategoryId phải nằm trong danh sách Category
        private void ValidateCategory(Product product)
        {
            if (product.CategoryId > 0 && !_store.CategoryExists(product.CategoryId))
                ModelState.AddModelError(nameof(Product.CategoryId),
                    "Danh mục đã chọn không tồn tại trong danh sách.");
        }

        private void ValidateImage(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
                ModelState.AddModelError(nameof(Product.ImageFile),
                    "Chỉ chấp nhận file ảnh: .jpg, .jpeg, .png, .gif, .webp.");
            else if (file.Length > MaxFileSize)
                ModelState.AddModelError(nameof(Product.ImageFile),
                    "Dung lượng ảnh không được vượt quá 2MB.");
        }

        // Lưu ảnh vào wwwroot/products, trả về tên file
        private async Task<string> SaveImageAsync(IFormFile file)
        {
            var folder = Path.Combine(_env.WebRootPath, "products");
            Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName).ToLowerInvariant();
            var fullPath = Path.Combine(folder, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }

        private void DeleteImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            var path = Path.Combine(_env.WebRootPath, "products", fileName);
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
        }
    }
}
