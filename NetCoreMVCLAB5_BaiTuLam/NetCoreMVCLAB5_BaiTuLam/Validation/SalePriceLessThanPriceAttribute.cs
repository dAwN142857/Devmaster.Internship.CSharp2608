using System.ComponentModel.DataAnnotations;
using NetCoreMVCLAB5_BaiTuLam.Models;

namespace NetCoreMVCLAB5_BaiTuLam.Validation
{
    /// <summary>
    /// Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất X% (mặc định 10%),
    /// tức là SalePrice &lt;= Price * (1 - X/100).
    /// </summary>
    public class SalePriceLessThanPriceAttribute : ValidationAttribute
    {
        private readonly double _percent;

        public SalePriceLessThanPriceAttribute(double percent = 10)
        {
            _percent = percent;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is not float salePrice) return ValidationResult.Success;
            if (context.ObjectInstance is not Product product) return ValidationResult.Success;
            if (product.Price <= 0) return ValidationResult.Success; // lỗi của Price sẽ báo riêng

            double max = product.Price * (1 - _percent / 100.0);
            if (salePrice > max + 0.01)
            {
                return new ValidationResult(
                    $"Giá khuyến mãi phải nhỏ hơn giá chuẩn {_percent}% " +
                    $"(tối đa {max:#,##0} khi giá chuẩn là {product.Price:#,##0}).",
                    new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}
