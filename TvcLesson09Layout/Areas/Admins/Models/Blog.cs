
namespace TvcLesson09Layout.Areas.Admins.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Status { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
