using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integrador.Data;
using Integrador.Models;
using MongoDB.Driver;

namespace Integrador.Controllers
{
    public class UsersController : Controller
    {
       // GET: Users
       // public async Task<IActionResult> Index()
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     return View(await mongoDB.User.Find(u => true).ToListAsync());
       // }

       // GET: Users/Details/5
       // public async Task<IActionResult> Details(Guid? id)
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     if (id == null || mongoDB.User == null)
       //     {
       //         return NotFound();
       //     }

       //     var user = await mongoDB.User.Find(u => u.Id == id).FirstOrDefaultAsync();
       //     if (user == null)
       //     {
       //         return NotFound();
       //     }

       //     return View(user);
       // }

       // GET: Users/Create
       // public IActionResult Create()
       // {
       //     return View();
       // }

       // POST: Users/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       //[HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Role,BirthDate,UserName,Password")] User user)
       // {
       //     if (ModelState.IsValid)
       //     {
       //         ContextMongoDB mongoDB = new ContextMongoDB();
       //         user.Id = Guid.NewGuid();
       //         await mongoDB.User.InsertOneAsync(user);
       //         return RedirectToAction(nameof(Index));
       //     }
       //     return View(user);
       // }

       // GET: Users/Edit/5
       // public async Task<IActionResult> Edit(Guid? id)
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     if (id == null || mongoDB.User == null)
       //     {
       //         return NotFound();
       //     }

       //     var user = await mongoDB.User.Find(u => u.Id == id).FirstOrDefaultAsync();
       //     if (user == null)
       //     {
       //         return NotFound();
       //     }
       //     return View(user);
       // }

       // POST: Users/Edit/5
       //  To protect from overposting attacks, enable the specific properties you want to bind to.
       //  For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Role,BirthDate,UserName,Password")] User user)
       // {
       //     if (id != user.Id)
       //     {
       //         return NotFound();
       //     }

       //     if (ModelState.IsValid)
       //     {
       //         try
       //         {
       //             ContextMongoDB mongoDB = new ContextMongoDB();
       //             await mongoDB.User.ReplaceOneAsync(m => m.Id == user.Id, user);
       //         }
       //         catch (DbUpdateConcurrencyException)
       //         {
       //             if (!UserExists(user.Id))
       //             {
       //                 return NotFound();
       //             }
       //             else
       //             {
       //                 throw;
       //             }
       //         }
       //         return RedirectToAction(nameof(Index));
       //     }
       //     return View(user);
       // }

       // GET: Users/Delete/5
       // public async Task<IActionResult> Delete(Guid? id)
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     if (id == null || mongoDB.User == null)
       //     {
       //         return NotFound();
       //     }

       //     var user = await mongoDB.User.Find(u => u.Id == id).FirstOrDefaultAsync();
       //     if (user == null)
       //     {
       //         return NotFound();
       //     }

       //     return View(user);
       // }

       // POST: Users/Delete/5
       // [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> DeleteConfirmed(Guid id)
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     await mongoDB.User.DeleteOneAsync(u => u.Id == id);
       //     return RedirectToAction(nameof(Index));
       // }

       // private bool UserExists(Guid id)
       // {
       //     ContextMongoDB mongoDB = new ContextMongoDB();
       //     var user = mongoDB.User.Find(u => u.Id == id).Any();
       //     return user;
       // }
    }
}
