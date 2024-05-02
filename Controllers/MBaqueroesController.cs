using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluacionP1.Data;
using EvaluacionP1.Models;

namespace EvaluacionP1.Controllers
{
    public class MBaqueroesController : Controller
    {
        private readonly EvaluacionP1Context _context;

        public MBaqueroesController(EvaluacionP1Context context)
        {
            _context = context;
        }

        // GET: MBaqueroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MBaquero.ToListAsync());
        }

        // GET: MBaqueroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBaquero = await _context.MBaquero
                .FirstOrDefaultAsync(m => m.id == id);
            if (mBaquero == null)
            {
                return NotFound();
            }

            return View(mBaquero);
        }

        // GET: MBaqueroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MBaqueroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,edad,mensualidad,anio,reprobo,CarreraId")] MBaquero mBaquero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mBaquero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mBaquero);
        }

        // GET: MBaqueroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBaquero = await _context.MBaquero.FindAsync(id);
            if (mBaquero == null)
            {
                return NotFound();
            }
            return View(mBaquero);
        }

        // POST: MBaqueroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,edad,mensualidad,anio,reprobo,CarreraId")] MBaquero mBaquero)
        {
            if (id != mBaquero.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mBaquero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MBaqueroExists(mBaquero.id))
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
            return View(mBaquero);
        }

        // GET: MBaqueroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBaquero = await _context.MBaquero
                .FirstOrDefaultAsync(m => m.id == id);
            if (mBaquero == null)
            {
                return NotFound();
            }

            return View(mBaquero);
        }

        // POST: MBaqueroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mBaquero = await _context.MBaquero.FindAsync(id);
            if (mBaquero != null)
            {
                _context.MBaquero.Remove(mBaquero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MBaqueroExists(string id)
        {
            return _context.MBaquero.Any(e => e.id == id);
        }
    }
}
