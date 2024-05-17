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
    public class TerminFilmaController : Controller
    {
        private readonly ApplicationContext _context;

        public TerminFilmaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TerminFilma
        public async Task<IActionResult> Index()
        {
            return View(await _context.TerminiFilma.ToListAsync());
        }

        // GET: TerminFilma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminFilma = await _context.TerminiFilma
                .FirstOrDefaultAsync(m => m.id == id);
            if (terminFilma == null)
            {
                return NotFound();
            }

            return View(terminFilma);
        }

        // GET: TerminFilma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TerminFilma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,datumUra,kapaciteta,filmId,dvoranaId")] TerminFilma terminFilma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminFilma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terminFilma);
        }

        // GET: TerminFilma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminFilma = await _context.TerminiFilma.FindAsync(id);
            if (terminFilma == null)
            {
                return NotFound();
            }
            return View(terminFilma);
        }

        // POST: TerminFilma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,datumUra,kapaciteta,filmId,dvoranaId")] TerminFilma terminFilma)
        {
            if (id != terminFilma.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminFilma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminFilmaExists(terminFilma.id))
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
            return View(terminFilma);
        }

        // GET: TerminFilma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminFilma = await _context.TerminiFilma
                .FirstOrDefaultAsync(m => m.id == id);
            if (terminFilma == null)
            {
                return NotFound();
            }

            return View(terminFilma);
        }

        // POST: TerminFilma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terminFilma = await _context.TerminiFilma.FindAsync(id);
            if (terminFilma != null)
            {
                _context.TerminiFilma.Remove(terminFilma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminFilmaExists(int id)
        {
            return _context.TerminiFilma.Any(e => e.id == id);
        }
    }
}
