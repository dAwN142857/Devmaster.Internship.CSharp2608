using NetCoreMVCLAB5_BaiTuLam.Models;

namespace NetCoreMVCLAB5_BaiTuLam.Services
{
    /// <summary>
    /// Kho dữ liệu trong bộ nhớ cho Category và Product (không cần database).
    /// Dữ liệu sẽ mất khi tắt ứng dụng.
    /// </summary>
    public class DataStore
    {
        private readonly object _lock = new();
        private readonly List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" },
            new Category { Id = 4, Name = "Máy tính bảng" },
        };
        private readonly List<Product> _products = new();
        private int _nextProductId = 1;

        // ---------- Category ----------
        public List<Category> GetCategories()
        {
            lock (_lock) return _categories.OrderBy(c => c.Id).ToList();
        }

        public bool CategoryExists(int id)
        {
            lock (_lock) return _categories.Any(c => c.Id == id);
        }

        // ---------- Product ----------
        public List<Product> GetProducts()
        {
            lock (_lock)
            {
                _products.ForEach(AttachCategory);
                return _products.OrderByDescending(p => p.Id).ToList();
            }
        }

        public Product GetProduct(int id)
        {
            lock (_lock)
            {
                var p = _products.FirstOrDefault(x => x.Id == id);
                if (p != null) AttachCategory(p);
                return p;
            }
        }

        public void Add(Product p)
        {
            lock (_lock)
            {
                p.Id = _nextProductId++;
                _products.Add(p);
            }
        }

        public bool Update(Product p)
        {
            lock (_lock)
            {
                var old = _products.FirstOrDefault(x => x.Id == p.Id);
                if (old == null) return false;
                old.Name = p.Name;
                old.Image = p.Image;
                old.Price = p.Price;
                old.SalePrice = p.SalePrice;
                old.Description = p.Description;
                old.CategoryId = p.CategoryId;
                return true;
            }
        }

        public bool Remove(int id)
        {
            lock (_lock)
            {
                var p = _products.FirstOrDefault(x => x.Id == id);
                return p != null && _products.Remove(p);
            }
        }

        private void AttachCategory(Product p)
        {
            p.Category = _categories.FirstOrDefault(c => c.Id == p.CategoryId);
        }
    }
}
