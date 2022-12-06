using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class ErrorController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
