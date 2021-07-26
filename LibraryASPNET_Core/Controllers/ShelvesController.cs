using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryASPNET_Core.Models;

namespace LibraryASPNET_Core.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly LibraryContext _context;

        public ShelvesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Shelves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shelves_.ToListAsync());
        }

        // GET: Shelves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelves = await _context.Shelves_
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shelves == null)
            {
                return NotFound();
            }

            return View(shelves);
        }

        // GET: Shelves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Shelves shelves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shelves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shelves);
        }

        // GET: Shelves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelves = await _context.Shelves_.FindAsync(id);
            if (shelves == null)
            {
                return NotFound();
            }
            return View(shelves);
        }

        // POST: Shelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Shelves shelves)
        {
            if (id != shelves.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelvesExists(shelves.Id))
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
            return View(shelves);
        }

        // GET: Shelves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelves = await _context.Shelves_
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shelves == null)
            {
                return NotFound();
            }

            return View(shelves);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelves = await _context.Shelves_.FindAsync(id);
            _context.Shelves_.Remove(shelves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelvesExists(int id)
        {
            return _context.Shelves_.Any(e => e.Id == id);
        }
    }
}
