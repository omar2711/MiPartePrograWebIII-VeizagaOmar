using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Integrador.Controllers
{
    public class ServiceController : Controller
    {
        //post submitservice controller
        [HttpPost]
        public IActionResult SubmitService(IFormCollection form)
        {
            //get the form data
            string serviceName = form["serviceName"];
            string description = form["description"];
            string descriptionDetails = form["descriptionDetails"];
            string contactService = form["contactService"];
            string price = form["price"];
            string email = form["email"];
            string serviceType = form["serviceType"];
            string status = form["status"];
            //create a new service object
            Models.Service service = new Models.Service();
            service.serviceName = serviceName;
            service.description = description;
            service.descriptionDetails = descriptionDetails;
            service.contactService = int.Parse(contactService);
            service.price = decimal.Parse(price);
            service.email = email;
            service.serviceType = serviceType;
            service.status = 1;
            //add the service to the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //add the service to mongodb
            db.ServiceSubmit.InsertOne(service);
            //redirect to the index page
            return RedirectToAction("Index", "ServiceList");
        }

        // GET: ServiceController
        public ActionResult Index()
        {
            return View();
        }

        //get in table submitservice controller
        public IActionResult TableSubmitService()
        {
            //get the list of services from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the list of services from mongodb
            List<Models.Service> ServiceList = db.ServiceSubmit.Find(_ => true).ToList();
            //pass /the list to the view            
            return View(ServiceList);
        }


        
        // GET: Service/Edit
        public ActionResult Edit(string id)
        {
            //get the service from the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //get the service from mongodb
            Models.Service service = db.ServiceSubmit.Find(_ => _.id == Guid.Parse(id)).FirstOrDefault();
            //pass the service to the view
            //redirect to the index page
            return RedirectToAction("Edit", "ServiceList");
           
        }

        //POST : Service/image
       

    }
}
