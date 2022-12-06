using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    public class MyPropertiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
