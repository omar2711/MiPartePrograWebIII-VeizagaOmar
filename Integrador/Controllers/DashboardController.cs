using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class DashboardController : Controller
  {
    public IActionResult Index()
    {
          
      return View();
            
    }
  }
}
