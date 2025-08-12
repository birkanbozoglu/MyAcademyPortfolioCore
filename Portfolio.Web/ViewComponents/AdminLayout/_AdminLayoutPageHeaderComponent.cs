using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutPageHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
