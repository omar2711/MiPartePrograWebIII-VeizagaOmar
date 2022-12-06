using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Integrador.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterClient(IFormCollection form)
        {
            {
                //get the form data
                string name = form["firstname"];
                string userName = form["username"];
                string lastName = form["lastName"];
                string email = form["email"];
                string password = form["password"];
                string confirmPassword = form["confirmPassword"];
                
                

                //create a new client object
                Models.User user = new Models.User();
                user.FirstName = name;
                user.UserName = userName;
                user.LastName = lastName;
                user.Email = email;
                user.Password = password;
                user.ConfirmPassword = confirmPassword;
                //add the client to the database
                Models.ContextMongoDB db = new Models.ContextMongoDB();
                //add the client to mongodb
                db.User.InsertOne(user);
                //redirect to the index page
                return RedirectToAction("Index", "Login");

            }

        }

        //update a client
        public IActionResult UpdateClient(IFormCollection form)

        {
            //get the form data

            string name = form["firstname"];
            string userName = form["username"];
            string lastName = form["lastName"];
            string email = form["email"];
            string password = form["password"];
            string confirmPassword = form["confirmPassword"];
            //create a new client object
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Models.User user = new Models.User();

            user.FirstName = name;
            user.UserName = userName;
            user.LastName = lastName;
            user.Email = email;
            user.Password = password;
            user.ConfirmPassword = confirmPassword;
            //add the client to the database
            Models.ContextMongoDB db = new Models.ContextMongoDB();
            //add the client to mongodb
            Console.WriteLine(userId);
            db.User.UpdateOne(userId, user.ToString());
            //redirect to the index page
            return RedirectToAction("Index", "Login");
        }


    }
}
