using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    // Basic controller to render home page
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
