using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspDotNetCoreApp.Data;
using AspDotNetCoreApp.Models;

namespace AspDotNetCoreApp.Controllers
{
    public class FiliereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiliereController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filiere
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filieres.ToListAsync());
        }

        // GET: Filiere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filiere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filiere/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiliereId,nom")] Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiere);
        }

        // GET: Filiere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filiere/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiliereId,nom")] Filiere filiere)
        {
            if (id != filiere.FiliereId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.FiliereId))
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
            return View(filiere);
        }

        // GET: Filiere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filieres
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filiere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiere = await _context.Filieres.FindAsync(id);
            _context.Filieres.Remove(filiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
            return _context.Filieres.Any(e => e.FiliereId == id);
        }
    }
}
