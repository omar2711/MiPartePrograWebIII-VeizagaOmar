using Integrador.Models;
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
            //var userLogin = from usr in _context.Users
            //                join rolesx in _context.Rols
            //                on usr.RolID equals rolesx.RolID
            //                where (usr.Email == userForm.Email && usr.Password == userForm.Password)
            //                select new
            //                {
            //                    UserId = usr.UserID,
            //                    Name = usr.Name,
            //                    Email = usr.Email,
            //                    Password = usr.Password,
            //                    RolName = rolesx.RolName
            //                };
            //mongodb login
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
            //if (userLogin.Count() != 0)
            //{
            //    //add cookie
            //    string rol = userLogin.First().RolName;
            //    string email = userLogin.First().Email;
            //    string name = userLogin.First().Name;
            //    //Cookie
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, name),
            //        new Claim("Email",email),
            //        new Claim(ClaimTypes.Role, rol)
            //    };
            //    //Claim Identity 
            //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //    //Logeo con SignInAsync
            //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewData["Error"] = "Not Register";
            //    return View();
            //}

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
