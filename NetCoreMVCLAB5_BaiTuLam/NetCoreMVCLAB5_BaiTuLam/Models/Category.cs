using System.ComponentModel.DataAnnotations;

namespace NetCoreMVCLAB5_BaiTuLam.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống.")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
    }
}
