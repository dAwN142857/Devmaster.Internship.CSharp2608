using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NguyenDuyAn_241230651.Models;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên hàng")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
    public string TenHang { get; set; } = null!;

    // Câu 5.2: Giá phải là số và nằm trong khoảng 100 đến 5000
    // ("phải là số" được báo bởi kiểu decimal? + thông báo cấu hình trong Program.cs)
    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Gia { get; set; }

    // Câu 5.2: Tên file ảnh phải có đuôi .jpg | .png | .gif | .tiff
    [Required(ErrorMessage = "Vui lòng nhập tên file ảnh")]
    [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
    [RegularExpression(@"^.+\.(jpg|png|gif|tiff|JPG|PNG|GIF|TIFF)$",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
    public string? Anh { get; set; }

    [ForeignKey("MaLoai")]
    [InverseProperty("HangHoas")]
    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
