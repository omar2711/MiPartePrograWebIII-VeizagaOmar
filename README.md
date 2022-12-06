# Proyecto Integrador

# Resumen
Es un proyecto de software en donde se basa en la creacion y vista de servicios para una pagina web de un salon de eventos.
El software cuenta con diferentes modulos, siendo ellos:
El login
CRUD de los servicios
CRUD de los usuarios
Reoles personalizados

La parte que se me fue asignada fue el registro de usuario, login y update del perfil de usuario

# BackGround Research

Para este proyecto tomamos como referencia los anteriores ejemplos de MVC explicados y desarrollados durante todo el semestre.
Ademas de eso, ya que no estoy cursando la materia de Base de Datos 3 tuve la necesidad de investigacion del software "MongoDB" para el correcto funcionamiento y pruebas del proyecto.

# Diseño e implementacion

En mi parte del proyecto implemente el login, register e implementacion de actualizacion del perfil

Para eso tuve que modificar las siguientes clases:
    En la parte del Modelo:
       User.cs
       
``` using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    [Table("users")]
    public class User
    {
        //[Column("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //[Column("firstname")]
        [BsonElement("firstname")]
        [Display(Name = "firstname")]
        public string FirstName { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("confirmPassword")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
```

En la parte de controladores:
# El LoginController
```using Integrador.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MongoDB.Driver;
using Integrador.Data;


namespace Integrador.Controllers
{
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //ContextMongoDB mongoDB = new ContextMongoDB();
            //return View(await mongoDB.User.Find(u => true).ToListAsync());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User userForm)
        {
           
            ContextMongoDB mongoDB = new ContextMongoDB();
            var userLogin = await mongoDB.User.Find(u => u.Email == userForm.Email && u.Password == userForm.Password).FirstOrDefaultAsync();

            if (userLogin != null)
            {
                var claims = new List<Claim>
                    {
                    //claim with the id
                        new Claim(ClaimTypes.NameIdentifier, userLogin.Id),
                        new Claim(ClaimTypes.Name, userLogin.FirstName),
                        new Claim(ClaimTypes.Email, userLogin.Email),
                        
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Usuario o contraseña incorrectos";
                ViewData["Error"] = "Usuario o contraseña incorrectos";
                return View();
            }
            

        }
        //Logout
        public async Task<IActionResult> Logout()
        {
            //SignOutAsync
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
```
# El RegisterController con los metodos update y register

```using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using MongoDB.Driver;

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
            db.User.UpdateOne(u => u.Id == userId, Builders<Models.User>.Update.Set("FirstName", name).Set("UserName", userName).Set("LastName", lastName).Set("Email", email).Set("Password", password).Set("ConfirmPassword", confirmPassword));
            //redirect to the index page
            return RedirectToAction("Index", "Login");
        }


    }
} ```

# En la parte de las vistas:
La vista del registro de usuario:

``` @*
    For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
*@
@{
    Layout = "";
}

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Integrador</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />

    <link rel="stylesheet" type="text/css" href="~/css/bootstrap.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/animate.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/bootstrap-submenu.css" asp-append-version="true">

    <link rel="stylesheet" type="text/css" href="~/css/bootstrap-select.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/magnific-popup.css" asp-append-version="true">
    <link rel="stylesheet" href="~/css/leaflet.css" type="/text/css" asp-append-version="true">
    <link rel="stylesheet" href="~/css/map.css" type="text/css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/font-awesome/css/font-awesome.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/flaticon/font/flaticon.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/linearicons/style.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/jquery.mCustomScrollbar.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/dropzone.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/slick.css" asp-append-version="true">

    <!-- Custom stylesheet -->
    <link rel="stylesheet" type="text/css" href="~/css/style.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" id="style_sheet" href="~/skins/default.css" asp-append-version="true">

    <!-- Favicon icon -->
    <link rel="shortcut icon" href="~/img/favicon.ico" type="image/x-icon" asp-append-version="true">

    <!-- Google fonts -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Raleway:300,400,500,600,300,700">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link rel="stylesheet" type="text/css" href="~/css/ie10-viewport-bug-workaround.css" asp-append-version="true">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script  src="js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="~/js/ie-emulation-modes-warning.js" asp-append-version="true"></script>

    <link rel="stylesheet" href="~/Integrador.styles.css" asp-append-version="true" />


</head>
<body>
    <!-- Contact section start -->
    <div class="contact-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <!-- Form content box start -->
                    <div class="form-content-box">
                        <!-- details -->
                        <div class="details">
                            <!-- Logo-->
                            <a href="index.html">
                                <img src="img/black-logo.png" class="cm-logo" alt="black-logo">
                            </a>
                            <!-- Name -->
                            <h3>Create an account</h3>
                            
                            <!-- Form start-->
                            <form action="Register/RegisterClient" method="post">
                                <div class="form-group">
                                    <input type="text" name="firstname" class="input-text" placeholder="First Name" autofocus required>
                                </div>
                                <div class="form-group">
                                    <input type="text" name="lastName" class="input-text" placeholder="Last Name" autofocus required>
                                </div>
                                <div class="form-group">
                                    <input type="text" name="userName" class="input-text" placeholder="User Name" autofocus required>
                                </div>
                                <div class="form-group">
                                    <input type="email" name="email" class="input-text" placeholder="Email Address" autofocus required>
                                </div>
                                <div class="form-group">
                                    <input type="password" name="password" class="input-text" placeholder="Password" autofocus required>
                                </div>
                                <div class="form-group">
                                    <input type="password" name="confirmPassword" class="input-text" placeholder="Confirm Password" autofocus required>
                                </div>
                                
                                <div class="form-group mb-0">
                                    <button type="submit" class="btn-md button-theme btn-block">Signup</button>
                                </div>
                            </form>
                            <!-- Social List -->
                            <ul class="social-list clearfix">
                                <li><a href="#" class="facebook-bg"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#" class="twitter-bg"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#" class="google-bg"><i class="fa fa-google-plus"></i></a></li>
                                <li><a href="#" class="linkedin-bg"><i class="fa fa-linkedin"></i></a></li>
                            </ul>
                        </div>
                        <!-- Footer -->
                        <div class="footer">
                            <span>Already a member? <a asp-controller="Login" asp-action="Index">Login here</a></span>
                        </div>
                    </div>
                    <!-- Form content box end -->
                </div>
            </div>
        </div>
    </div>
    <!-- Contact section end -->

    <script src="~/js/jquery-2.2.0.min.js" asp-append-version="true"></script>
    <script src="~/js/popper.min.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap.min.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap-submenu.js" asp-append-version="true"></script>
    <script src="~/js/rangeslider.js" asp-append-version="true"></script>
    <script src="~/js/jquery.mb.YTPlayer.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap-select.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.easing.1.3.js" asp-append-version="true"></script>
    <script src="~/js/jquery.scrollUp.js" asp-append-version="true"></script>
    <script src="~/js/jquery.mCustomScrollbar.concat.min.js" asp-append-version="true"></script>
    <script src="~/js/leaflet.js" asp-append-version="true"></script>
    <script src="~/js/leaflet-providers.js" asp-append-version="true"></script>
    <script src="~/js/leaflet.markercluster.js" asp-append-version="true"></script>
    <script src="~/js/dropzone.js" asp-append-version="true"></script>
    <script src="~/js/slick.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.filterizr.js" asp-append-version="true"></script>
    <script src="~/js/jquery.magnific-popup.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.countdown.js" asp-append-version="true"></script>
    <script src="~/js/maps.js" asp-append-version="true"></script>
    <script src="~/js/app.js" asp-append-version="true"></script>
    <script src="~/js/collapse.js"></script>


    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="~/js/ie10-viewport-bug-workaround.js" asp-append-version="true"></script>
    <!-- Custom javascript -->
    <script src="~/js/ie10-viewport-bug-workaround.js" asp-append-version="true"></script>

</body> ```

# En la parte del la vista del login: 
``` @model Integrador.Models.User
@{
	ViewData ["Title"] = "Login";
    Layout = "";
}
<!-- head with link  -->

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"]</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />

    <link rel="stylesheet" type="text/css" href="~/css/bootstrap.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/animate.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/bootstrap-submenu.css" asp-append-version="true">

    <link rel="stylesheet" type="text/css" href="~/css/bootstrap-select.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/magnific-popup.css" asp-append-version="true">
    <link rel="stylesheet" href="~/css/leaflet.css" type="/text/css" asp-append-version="true">
    <link rel="stylesheet" href="~/css/map.css" type="text/css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/font-awesome/css/font-awesome.min.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/flaticon/font/flaticon.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/fonts/linearicons/style.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/jquery.mCustomScrollbar.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/dropzone.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" href="~/css/slick.css" asp-append-version="true">

    <!-- Custom stylesheet -->
    <link rel="stylesheet" type="text/css" href="~/css/style.css" asp-append-version="true">
    <link rel="stylesheet" type="text/css" id="style_sheet" href="~/skins/default.css" asp-append-version="true">

    <!-- Favicon icon -->
    <link rel="shortcut icon" href="~/img/favicon.ico" type="image/x-icon" asp-append-version="true">

    <!-- Google fonts -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Raleway:300,400,500,600,300,700">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link rel="stylesheet" type="text/css" href="~/css/ie10-viewport-bug-workaround.css" asp-append-version="true">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script  src="js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="~/js/ie-emulation-modes-warning.js" asp-append-version="true"></script>

    <link rel="stylesheet" href="~/Integrador.styles.css" asp-append-version="true" />


</head>

<body>
    <div class="contact-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <!-- Form content box start -->
                    <div class="form-content-box">
                        <!-- details -->
                        <div class="details">
                            <!-- Logo -->
                            <a href="index.html">
                                <img src="img/black-logo.png" class="cm-logo" alt="black-logo">
                            </a>
                            <!-- Name -->
                            <h3>Sign into your account</h3>
                            <!-- Form start -->
                            <form asp-action="Index">
                                @ViewData["Error"]
                                <div asp-validation-summary="ModelOnly" class="text-danger"></div>

                                <div class="form-group">
                                    <label asp-for="Email" class="control-label"></label>
                                    <input asp-for="Email" class="form-control" />
                                    <span asp-validation-for="Email" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Password" class="control-label"></label>
                                    <input asp-for="Password" class="form-control" />
                                    <span asp-validation-for="Password" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Submit" class="btn btn-primary" />
                                </div>
                            </form>
                            <!-- Social List -->
                            <ul class="social-list clearfix">
                                <li><a href="#" class="facebook-bg"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#" class="twitter-bg"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#" class="google-bg"><i class="fa fa-google-plus"></i></a></li>
                                <li><a href="#" class="linkedin-bg"><i class="fa fa-linkedin"></i></a></li>
                            </ul>
                        </div>
                        <!-- Footer -->
                        <div class="footer">
                            <span>Don't have an account? <a asp-controller="Register" asp-action="Index">Register here</a></span>
                        </div>
                    </div>
                    <!-- Form content box end -->
                </div>
            </div>
        </div>
    </div>
    <!-- Contact section end -->
    <!-- Full Page Search -->
    <div id="full-page-search">
        <button type="button" class="close">×</button>
        <form action="index.html#">
            <input type="search" value="" placeholder="type keyword(s) here" />
            <button type="submit" class="btn btn-sm button-theme">Search</button>
        </form>
    </div>

    <script src="~/js/jquery-2.2.0.min.js" asp-append-version="true"></script>
    <script src="~/js/popper.min.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap.min.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap-submenu.js" asp-append-version="true"></script>
    <script src="~/js/rangeslider.js" asp-append-version="true"></script>
    <script src="~/js/jquery.mb.YTPlayer.js" asp-append-version="true"></script>
    <script src="~/js/bootstrap-select.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.easing.1.3.js" asp-append-version="true"></script>
    <script src="~/js/jquery.scrollUp.js" asp-append-version="true"></script>
    <script src="~/js/jquery.mCustomScrollbar.concat.min.js" asp-append-version="true"></script>
    <script src="~/js/leaflet.js" asp-append-version="true"></script>
    <script src="~/js/leaflet-providers.js" asp-append-version="true"></script>
    <script src="~/js/leaflet.markercluster.js" asp-append-version="true"></script>
    <script src="~/js/dropzone.js" asp-append-version="true"></script>
    <script src="~/js/slick.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.filterizr.js" asp-append-version="true"></script>
    <script src="~/js/jquery.magnific-popup.min.js" asp-append-version="true"></script>
    <script src="~/js/jquery.countdown.js" asp-append-version="true"></script>
    <script src="~/js/maps.js" asp-append-version="true"></script>
    <script src="~/js/app.js" asp-append-version="true"></script>

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="~/js/ie10-viewport-bug-workaround.js" asp-append-version="true"></script>
    <!-- Custom javascript -->
    <script src="~/js/ie10-viewport-bug-workaround.js" asp-append-version="true"></script>
	
</body>
</html> ```

# Conclusion

Pese a que no tenia muchos conocimientos mas que lo que aprendimos en el semestre, esta tecnologia (asp.net.core y mongoDB) fueron bastante intuitivas y con suficiente documentacion como para aprender y buscar algunas partes con las que no contaba con conocimientos



      

         
      

              


 
