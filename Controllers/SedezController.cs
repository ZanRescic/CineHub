using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineHub.Data;
using CineHub.Models;

namespace CineHub.Controllers
{
    public class SedezController : Controller
    {
        private readonly ApplicationContext _context;

        public SedezController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Sedez
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sedezi.ToListAsync());
        }

        // GET: Sedez/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedez = await _context.Sedezi
                .FirstOrDefaultAsync(m => m.id == id);
            if (sedez == null)
            {
                return NotFound();
            }

            return View(sedez);
        }

        // GET: Sedez/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedez/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,vrsta,stevilka,dvoranaId")] Sedez sedez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sedez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sedez);
        }

        // GET: Sedez/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedez = await _context.Sedezi.FindAsync(id);
            if (sedez == null)
            {
                return NotFound();
            }
            return View(sedez);
        }

        // POST: Sedez/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,vrsta,stevilka,dvoranaId")] Sedez sedez)
        {
            if (id != sedez.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedezExists(sedez.id))
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
            return View(sedez);
        }

        // GET: Sedez/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedez = await _context.Sedezi
                .FirstOrDefaultAsync(m => m.id == id);
            if (sedez == null)
            {
                return NotFound();
            }

            return View(sedez);
        }

        // POST: Sedez/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sedez = await _context.Sedezi.FindAsync(id);
            if (sedez != null)
            {
                _context.Sedezi.Remove(sedez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedezExists(int id)
        {
            return _context.Sedezi.Any(e => e.id == id);
        }
    }
}
