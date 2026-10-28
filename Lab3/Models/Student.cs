
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4,
            ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8,
            ErrorMessage = "Mật khẩu phải từ 8 đến 100 ký tự")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,100}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [Range(typeof(DateTime), "01/01/1963", "12/31/2005",
            ErrorMessage = "Ngày sinh phải từ năm 1963 đến năm 2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        [Range(0.0, 10.0,
            ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double? Mark { get; set; }
    }
}
