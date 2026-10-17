
namespace TvcLesson09Layout.Areas.Admins.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Status { get; set; } = 1;
        public int Priority { get; set; } = 0;
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
