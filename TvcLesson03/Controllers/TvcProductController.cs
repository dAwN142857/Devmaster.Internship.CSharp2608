using Microsoft.AspNetCore.Mvc;
using TvcLesson03.Models;

namespace TvcLesson03.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("san-pham")]
        public IActionResult GetAllProducts()
        {
            List<TvcCategory> categories = new List<TvcCategory>
            {
                new TvcCategory { Id = 1, Name = "Quần áo" },
                new TvcCategory { Id = 2, Name = "Túi xách" },
                new TvcCategory { Id = 3, Name = "Đồng hồ" },
                new TvcCategory { Id = 4, Name = "Ti vi" },
                new TvcCategory { Id = 5, Name = "Tủ lạnh" },
                new TvcCategory { Id = 6, Name = "Máy bơm" },
                new TvcCategory { Id = 7, Name = "Quạt điện" },
                new TvcCategory { Id = 8, Name = "Lò sưởi" }
            };

            List<TvcProduct> products = new List<TvcProduct>
            {
                new TvcProduct
                {
                    Id = 1,
                    Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = "product1.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nam",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 2,
                    Name = "Bộ đồ bơi cho trẻ em nữ",
                    Image = "product2.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nữ",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 3,
                    Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Image = "product3.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 4,
                    Name = "Bộ đồ bơi cho trẻ em thời trang",
                    Image = "product4.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi thời trang",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 5,
                    Name = "Túi thời trang mẫu mới 2021",
                    Image = "product5.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang nữ",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 6,
                    Name = "Túi thời trang da cá sấu",
                    Image = "product6.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi da cá sấu thời trang",
                    Status = true,
                    CreatedAt = DateTime.Now
                }
            };

            ViewData["products"] = products;
            ViewData["categories"] = categories;

            return View("Products");
        }

        [Route("san-pham/chi-tiet/{id}")]
        public IActionResult Details(int id)
        {
            List<TvcProduct> products = new List<TvcProduct>
    {
        new TvcProduct
        {
            Id = 1,
            Name = "Bộ đồ bơi cho trẻ em nam",
            Image = "product1.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 1,
            Description = "Bộ đồ bơi cho trẻ em nam",
            Status = true,
            CreatedAt = DateTime.Now
        },

        new TvcProduct
        {
            Id = 2,
            Name = "Bộ đồ bơi cho trẻ em nữ",
            Image = "product2.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 1,
            Description = "Bộ đồ bơi cho trẻ em nữ",
            Status = true,
            CreatedAt = DateTime.Now
        },

        new TvcProduct
        {
            Id = 3,
            Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
            Image = "product3.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 1,
            Description = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
            Status = true,
            CreatedAt = DateTime.Now
        },

        new TvcProduct
        {
            Id = 4,
            Name = "Bộ đồ bơi cho trẻ em thời trang",
            Image = "product4.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 1,
            Description = "Bộ đồ bơi thời trang",
            Status = true,
            CreatedAt = DateTime.Now
        },

        new TvcProduct
        {
            Id = 5,
            Name = "Túi thời trang mẫu mới 2021",
            Image = "product5.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 2,
            Description = "Túi thời trang nữ",
            Status = true,
            CreatedAt = DateTime.Now
        },

        new TvcProduct
        {
            Id = 6,
            Name = "Túi thời trang da cá sấu",
            Image = "product6.jpg",
            Price = 50000,
            SalePrice = 35000,
            CategoryId = 2,
            Description = "Túi da cá sấu thời trang",
            Status = true,
            CreatedAt = DateTime.Now
        }
    };

            var product = products.FirstOrDefault(x => x.Id == id);

            return View(product);
        }

        public IActionResult ProductsByCategory(int id)
        {
            List<TvcCategory> categories = new List<TvcCategory>
            {
                new TvcCategory { Id = 1, Name = "Quần áo" },
                new TvcCategory { Id = 2, Name = "Túi xách" },
                new TvcCategory { Id = 3, Name = "Đồng hồ" },
                new TvcCategory { Id = 4, Name = "Ti vi" },
                new TvcCategory { Id = 5, Name = "Tủ lạnh" },
                new TvcCategory { Id = 6, Name = "Máy bơm" },
                new TvcCategory { Id = 7, Name = "Quạt điện" },
                new TvcCategory { Id = 8, Name = "Lò sưởi" }
            };

            List<TvcProduct> products = new List<TvcProduct>
            {
                new TvcProduct
                {
                    Id = 1,
                    Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = "product1.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nam",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 2,
                    Name = "Bộ đồ bơi cho trẻ em nữ",
                    Image = "product2.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nữ",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 3,
                    Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Image = "product3.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 4,
                    Name = "Bộ đồ bơi cho trẻ em thời trang",
                    Image = "product4.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi thời trang",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 5,
                    Name = "Túi thời trang mẫu mới 2021",
                    Image = "product5.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang nữ",
                    Status = true,
                    CreatedAt = DateTime.Now
                },

                new TvcProduct
                {
                    Id = 6,
                    Name = "Túi thời trang da cá sấu",
                    Image = "product6.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi da cá sấu thời trang",
                    Status = true,
                    CreatedAt = DateTime.Now
                }
            };

            var result = products.Where(x => x.CategoryId == id).ToList();

            ViewData["products"] = result;
            ViewData["categories"] = categories;

            return View("Products");
        }
    }
}