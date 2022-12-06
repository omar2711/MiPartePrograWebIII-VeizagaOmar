using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
