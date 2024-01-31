using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobAppSystem.Data;
using JobAppSystem.Models;

namespace JobAppSystem.Controllers
{
    public class KonkursiController : Controller
    {
        private readonly JobAppSystemDbContext _context;

        public KonkursiController(JobAppSystemDbContext context)
        {
            _context = context;
        }

        // GET: Konkursi
        public async Task<IActionResult> Index()
        {
            return _context.Konkurset != null ?
                        View(await _context.Konkurset.ToListAsync()) :
                        Problem("Entity set 'JobAppSystemDbContext.Konkurset'  is null.");
        }

        // GET: Konkursi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Konkurset == null)
            {
                return NotFound();
            }

            var konkursi = await _context.Konkurset
                .FirstOrDefaultAsync(m => m.KonkursiId == id);
            if (konkursi == null)
            {
                return NotFound();
            }

            return View(konkursi);
        }

        // POST: Konkursi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KonkursiId,Titulli,Pozicioni,EksperiencaENevojshme,DataEHapjes,DataEMbylljes")] Konkursi konkursi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konkursi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konkursi);
        }

        // GET: Konkursi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Konkurset == null)
            {
                return NotFound();
            }

            var konkursi = await _context.Konkurset.FindAsync(id);
            if (konkursi == null)
            {
                return NotFound();
            }
            return View(konkursi);
        }

        // POST: Konkursi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KonkursiId,Titulli,Pozicioni,EksperiencaENevojshme,DataEHapjes,DataEMbylljes")] Konkursi konkursi)
        {
            if (id != konkursi.KonkursiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konkursi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonkursiExists(konkursi.KonkursiId))
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
            return View(konkursi);
        }

        // GET: Konkursi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Konkurset == null)
            {
                return NotFound();
            }

            var konkursi = await _context.Konkurset
                .FirstOrDefaultAsync(m => m.KonkursiId == id);
            if (konkursi == null)
            {
                return NotFound();
            }

            return View(konkursi);
        }

        // POST: Konkursi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Konkurset == null)
            {
                return Problem("Entity set 'JobAppSystemDbContext.Konkurset'  is null.");
            }
            var konkursi = await _context.Konkurset.FindAsync(id);
            if (konkursi != null)
            {
                _context.Konkurset.Remove(konkursi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonkursiExists(int id)
        {
            return (_context.Konkurset?.Any(e => e.KonkursiId == id)).GetValueOrDefault();
        }
    }
}
