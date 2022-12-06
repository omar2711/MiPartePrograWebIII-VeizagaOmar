using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class BlogController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
