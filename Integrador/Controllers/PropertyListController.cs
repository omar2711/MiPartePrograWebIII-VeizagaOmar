using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class PropertyListController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
