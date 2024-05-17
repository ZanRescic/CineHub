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
    public class DvoranaController : Controller
    {
        private readonly ApplicationContext _context;

        public DvoranaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Dvorana
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dvorane.ToListAsync());
        }

        // GET: Dvorana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorane
                .FirstOrDefaultAsync(m => m.id == id);
            if (dvorana == null)
            {
                return NotFound();
            }

            return View(dvorana);
        }

        // GET: Dvorana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dvorana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tipDvorane,kapaciteta")] Dvorana dvorana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvorana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dvorana);
        }

        // GET: Dvorana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorane.FindAsync(id);
            if (dvorana == null)
            {
                return NotFound();
            }
            return View(dvorana);
        }

        // POST: Dvorana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tipDvorane,kapaciteta")] Dvorana dvorana)
        {
            if (id != dvorana.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvorana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DvoranaExists(dvorana.id))
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
            return View(dvorana);
        }

        // GET: Dvorana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvorana = await _context.Dvorane
                .FirstOrDefaultAsync(m => m.id == id);
            if (dvorana == null)
            {
                return NotFound();
            }

            return View(dvorana);
        }

        // POST: Dvorana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dvorana = await _context.Dvorane.FindAsync(id);
            if (dvorana != null)
            {
                _context.Dvorane.Remove(dvorana);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DvoranaExists(int id)
        {
            return _context.Dvorane.Any(e => e.id == id);
        }
    }
}
