using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
    public class InvoceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
