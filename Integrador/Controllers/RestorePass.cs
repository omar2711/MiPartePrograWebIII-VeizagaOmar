using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Integrador.Controllers
{
  public class RestorePass : Controller
  {
    // GET: RestorePass
    public ActionResult Index()
    {
      return View();
    }

    // GET: RestorePass/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: RestorePass/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: RestorePass/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: RestorePass/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: RestorePass/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: RestorePass/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: RestorePass/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
