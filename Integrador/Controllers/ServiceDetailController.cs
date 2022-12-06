using Integrador.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Integrador.Controllers
{
    public class ServiceDetailController : Controller
    {
        // GET: Service/Details/5
        public ActionResult Details(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Integrador");
            var collection = database.GetCollection<Service>("Service");
            var filter = Builders<Service>.Filter.Eq("Id", id);
            var service = collection.Find(filter).FirstOrDefault();
            return View(service);
        }
    }
}
