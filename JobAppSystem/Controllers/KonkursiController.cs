﻿using System;
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
    }
}