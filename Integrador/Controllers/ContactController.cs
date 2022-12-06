using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class ContactController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
