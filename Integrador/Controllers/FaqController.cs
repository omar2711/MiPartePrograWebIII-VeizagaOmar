using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class FaqController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
