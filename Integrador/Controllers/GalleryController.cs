using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class GalleryController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
