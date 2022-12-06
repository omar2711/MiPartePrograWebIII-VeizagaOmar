using Integrador.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Integrador.Controllers
{
    public class MyServiceController : Controller
    {
        //load service from database by id
        public IActionResult Index()
        {
            //get the list of services from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the list of services from mongodb
            List<Models.Service> ServiceList = db.ServiceSubmit.Find(_ => true).ToList();
            //pass /the list to the view
            return View(ServiceList);
        }
        // GET: Service/Edit
        public IActionResult Edit(string id)
        {
            //get the service from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the service from mongodb
            Models.Service Edit = db.ServiceSubmit.Find(_ => _.id == Guid.Parse(id)).FirstOrDefault();
            //pass the service to the view
            return View(Edit);
        }

        //POST: Service/Edit
        [HttpPost]
        public IActionResult Edit(string id, IFormCollection form)
        {
            //get the service from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the service from mongodb
            Models.Service Edit = db.ServiceSubmit.Find(_ => _.id == Guid.Parse(id)).FirstOrDefault();
            //get the form data
            string serviceName = form["serviceName"];
            string description = form["description"];
            string descriptionDetails = form["descriptionDetails"];
            string contactService = form["contactService"];
            string price = form["price"];
            string email = form["email"];
            string serviceType = form["serviceType"];
            //update the service
            Edit.serviceName = serviceName;
            Edit.description = description;
            Edit.descriptionDetails = descriptionDetails;
            Edit.contactService = int.Parse(contactService);
            Edit.price = decimal.Parse(price);
            Edit.email = email;
            Edit.serviceType = serviceType;

            //update the service in the database
            db.ServiceSubmit.ReplaceOne(_ => _.id == Guid.Parse(id), Edit);
            //redirect to the index page
            return RedirectToAction("Index", "MyService");

        }

        //GET: Service/Delete
        //public IActionResult Delete(string id)
        //{
        //    //get the service from the database
        //    Models.ContextMongoDB db = new Models.ContextMongoDB();
        //    //get the service from mongodb
        //    Models.Service Delete = db.ServiceSubmit.Find(_ => _.id == Guid.Parse(id)).FirstOrDefault();
        //    //pass the service to the view
        //    return View(Delete);
        //}

        //POST: Service/Delete
        [HttpPost]
        public IActionResult Delete(string id)
        {
            //get the service from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the service from mongodb
            Models.Service idDelete = db.ServiceSubmit.Find(_ => _.id == Guid.Parse(id)).FirstOrDefault();

            //idDelete.status = 1;
            //db.ServiceSubmit.ReplaceOne(_ => _.id == Guid.Parse(idDelete.id.ToString()), idDelete);
            //delete the service from the database
            db.ServiceSubmit.DeleteOne(_ => _.id == Guid.Parse(idDelete.id.ToString()));
            //redirect to the index page
            return RedirectToAction("Index", "Home");
        }
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
