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
    public class ManagementsController : Controller
    {
        private readonly ContextoMongodb _context;

        public ManagementsController()
        {
            _context = new();
        }

        // GET: Managements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managements.Find(u => true && u.Status == 1).ToListAsync());
        }

        // GET: Managements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var management = await _context.Managements.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (management == null)
            {
                return NotFound();
            }

            return View(management);
        }

        // GET: Managements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Managements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameManager,Description,Status,RegisterDate,UpdateDate")] Management management)
        {
            if (ModelState.IsValid)
            {
                management.Id = Guid.NewGuid();
                management.Status =1;
                management.RegisterDate = DateTime.Now;
                management.UpdateDate = DateTime.Now;
                await _context.Managements.InsertOneAsync(management);
                return RedirectToAction(nameof(Index));
            }
            return View(management);
        }

        // GET: Managements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var management = await _context.Managements.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (management == null)
            {
                return NotFound();
            }
            return View(management);
        }

        // POST: Managements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NameManager,Description,Status,RegisterDate,UpdateDate")] Management management)
        {
            if (id != management.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    management.UpdateDate = DateTime.Now;
                    await _context.Managements.ReplaceOneAsync(m => m.Id == management.Id, management);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagementExists(management.Id))
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
            return View(management);
        }

        // GET: Managements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var management = await _context.Managements.Find(u => u.Id == id).FirstOrDefaultAsync();
            if (management == null)
            {
                return NotFound();
            }

            return View(management);
        }

        // POST: Managements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var management = await _context.Managements.Find(u => u.Id == id).FirstOrDefaultAsync();
            management.Status = 0;
            management.UpdateDate = DateTime.Now;
            await _context.Managements.ReplaceOneAsync(m => m.Id == management.Id, management);

            return RedirectToAction(nameof(Index));
        }

        private bool ManagementExists(Guid id)
        {
          return _context.Managements.Find(u => u.Id == id).Any();
        }
    }
}
