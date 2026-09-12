using Microsoft.AspNetCore.Mvc;

namespace Bai4Views.Components
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}