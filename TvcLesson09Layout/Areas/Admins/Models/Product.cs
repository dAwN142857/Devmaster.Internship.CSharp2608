
namespace TvcLesson09Layout.Areas.Admins.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public float SalePrice { get; set; } = 0;
        public byte Status { get; set; } = 1;
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
