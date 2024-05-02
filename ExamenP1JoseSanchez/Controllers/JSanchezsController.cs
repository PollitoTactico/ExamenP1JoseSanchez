using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenP1JoseSanchez.Data;
using ExamenP1JoseSanchez.Models;

namespace ExamenP1JoseSanchez.Controllers
{
    public class JSanchezsController : Controller
    {
        private readonly ExamenP1JoseSanchezContext _context;

        public JSanchezsController(ExamenP1JoseSanchezContext context)
        {
            _context = context;
        }

        // GET: JSanchezs
        public async Task<IActionResult> Index()
        {
            var examenP1JoseSanchezContext = _context.JSanchez.Include(j => j.Carrera);
            return View(await examenP1JoseSanchezContext.ToListAsync());
        }

        // GET: JSanchezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSanchez = await _context.JSanchez
                .Include(j => j.Carrera)
                .FirstOrDefaultAsync(m => m.IdSanchez == id);
            if (jSanchez == null)
            {
                return NotFound();
            }

            return View(jSanchez);
        }

        // GET: JSanchezs/Create
        public IActionResult Create()
        {
            ViewData["CarreraIdCarrera"] = new SelectList(_context.Carrera, "IdCarrera", "NombreCarrera");
            return View();
        }

        // POST: JSanchezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanchez,Nombre,EsdelaUdla,FechaNacimeinto,CarreraIdCarrera")] JSanchez jSanchez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jSanchez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraIdCarrera"] = new SelectList(_context.Carrera, "IdCarrera", "NombreCarrera", jSanchez.CarreraIdCarrera);
            return View(jSanchez);
        }

        // GET: JSanchezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSanchez = await _context.JSanchez.FindAsync(id);
            if (jSanchez == null)
            {
                return NotFound();
            }
            ViewData["CarreraIdCarrera"] = new SelectList(_context.Carrera, "IdCarrera", "NombreCarrera", jSanchez.CarreraIdCarrera);
            return View(jSanchez);
        }

        // POST: JSanchezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSanchez,Nombre,EsdelaUdla,FechaNacimeinto,CarreraIdCarrera")] JSanchez jSanchez)
        {
            if (id != jSanchez.IdSanchez)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jSanchez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JSanchezExists(jSanchez.IdSanchez))
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
            ViewData["CarreraIdCarrera"] = new SelectList(_context.Carrera, "IdCarrera", "NombreCarrera", jSanchez.CarreraIdCarrera);
            return View(jSanchez);
        }

        // GET: JSanchezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSanchez = await _context.JSanchez
                .Include(j => j.Carrera)
                .FirstOrDefaultAsync(m => m.IdSanchez == id);
            if (jSanchez == null)
            {
                return NotFound();
            }

            return View(jSanchez);
        }

        // POST: JSanchezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jSanchez = await _context.JSanchez.FindAsync(id);
            if (jSanchez != null)
            {
                _context.JSanchez.Remove(jSanchez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JSanchezExists(int id)
        {
            return _context.JSanchez.Any(e => e.IdSanchez == id);
        }
    }
}
