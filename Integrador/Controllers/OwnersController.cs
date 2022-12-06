using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Integrador.Data;
using Integrador.Models;

namespace WebMongoDB.Controllers
{
    public class OwnersController : Controller
    {
        private readonly ContextoMongodb _context;

        public OwnersController()
        {
            _context = new();
        }

        // GET: Owners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Owners.Find(u => true && u.Status == 1).ToListAsync());
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Owners == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Status,RegisterDate,UpdateDate")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                owner.Id = Guid.NewGuid();
                owner.Status = 1;
                owner.RegisterDate= DateTime.Now;
                owner.UpdateDate = DateTime.Now;
                await _context.Owners.InsertOneAsync(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Owners == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,Status,RegisterDate,UpdateDate")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    owner.UpdateDate = DateTime.Now;
                    await _context.Owners.ReplaceOneAsync(m => m.Id == owner.Id, owner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Owners == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var owner = await _context.Owners.Find(u => u.Id == id).FirstOrDefaultAsync();
            owner.Status = 0;
            owner.UpdateDate = DateTime.Now;
            await _context.Owners.ReplaceOneAsync(m => m.Id == owner.Id, owner);
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(Guid id)
        {
            return _context.Owners.Find(u => u.Id == id).Any();
        }
    }
}
