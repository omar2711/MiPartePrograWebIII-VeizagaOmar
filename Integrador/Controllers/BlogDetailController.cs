using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class BlogDetailController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
