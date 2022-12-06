using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
