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
    public class VstopnicaController : Controller
    {
        private readonly ApplicationContext _context;

        public VstopnicaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Vstopnica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vstopnice.ToListAsync());
        }

        // GET: Vstopnica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vstopnica = await _context.Vstopnice
                .FirstOrDefaultAsync(m => m.id == id);
            if (vstopnica == null)
            {
                return NotFound();
            }

            return View(vstopnica);
        }

        // GET: Vstopnica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vstopnica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,stVstopnic,kupljena,terminFilmaId")] Vstopnica vstopnica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vstopnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vstopnica);
        }

        // GET: Vstopnica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vstopnica = await _context.Vstopnice.FindAsync(id);
            if (vstopnica == null)
            {
                return NotFound();
            }
            return View(vstopnica);
        }

        // POST: Vstopnica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,stVstopnic,kupljena,terminFilmaId")] Vstopnica vstopnica)
        {
            if (id != vstopnica.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vstopnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VstopnicaExists(vstopnica.id))
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
            return View(vstopnica);
        }

        // GET: Vstopnica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vstopnica = await _context.Vstopnice
                .FirstOrDefaultAsync(m => m.id == id);
            if (vstopnica == null)
            {
                return NotFound();
            }

            return View(vstopnica);
        }

        // POST: Vstopnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vstopnica = await _context.Vstopnice.FindAsync(id);
            if (vstopnica != null)
            {
                _context.Vstopnice.Remove(vstopnica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VstopnicaExists(int id)
        {
            return _context.Vstopnice.Any(e => e.id == id);
        }
    }
}
