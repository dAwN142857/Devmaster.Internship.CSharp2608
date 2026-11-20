using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NguyenDuyAn_241230651.Models;

[Table("Sach")]
public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    [Column("MaTL")]
    public int MaTl { get; set; }


    [Required(ErrorMessage = "Tên sách không được để trống")]
    [StringLength(100)]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(typeof(decimal), "50", "1000",
        ErrorMessage = "Giá phải từ 50 đến 1000")]
    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên ảnh")]
    [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$",
        ErrorMessage = "Ảnh phải có đuôi jpg, jpeg, png hoặc webp")]
    [StringLength(100)]
    public string? Anh { get; set; }


    [ForeignKey("MaTl")]
    [InverseProperty("Saches")]
    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
