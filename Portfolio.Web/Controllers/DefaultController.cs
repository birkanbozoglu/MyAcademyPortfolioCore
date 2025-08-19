using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
