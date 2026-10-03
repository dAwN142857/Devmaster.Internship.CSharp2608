using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NetCoreMVCLAB5_BaiTuLam.Validation;

namespace NetCoreMVCLAB5_BaiTuLam.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(150, MinimumLength = 6,
            ErrorMessage = "Tên sản phẩm phải có từ 6 đến 150 ký tự.")]
        public string Name { get; set; }

        // Tên file ảnh đã upload (lưu trong wwwroot/products).
        // Việc bắt buộc chọn ảnh được kiểm tra ở Controller thông qua ImageFile.
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá không được để trống.")]
        [Range(100000, 1000000000,
            ErrorMessage = "Giá phải từ 100.000 trở lên (và không quá 1.000.000.000).")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống.")]
        [Range(0, 1000000000, ErrorMessage = "Giá khuyến mãi không được là số âm.")]
        [SalePriceLessThanPrice(10, ErrorMessage = "")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống.")]
        [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự.")]
        [NoBadWords]
        public string Description { get; set; }

        [Display(Name = "Danh mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục.")]
        public int CategoryId { get; set; }

        // File ảnh người dùng chọn trên form (không lưu vào kho dữ liệu)
        [Display(Name = "Hình ảnh")]
        public IFormFile ImageFile { get; set; }

        [BindNever, ValidateNever]
        public Category Category { get; set; }
    }
}
