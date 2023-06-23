using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoangKimHuan0797.Models;

namespace HoangKimHuan0797.Controllers
{
    public class HKHPersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HKHPersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HKHPerson
        public async Task<IActionResult> Index()
        {
              return _context.HKHPerson != null ? 
                          View(await _context.HKHPerson.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HKHPerson'  is null.");
        }

        // GET: HKHPerson/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HKHPerson == null)
            {
                return NotFound();
            }

            var hKHPerson = await _context.HKHPerson
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (hKHPerson == null)
            {
                return NotFound();
            }

            return View(hKHPerson);
        }

        // GET: HKHPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HKHPerson/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonName,PersonPhone")] HKHPerson hKHPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hKHPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hKHPerson);
        }

        // GET: HKHPerson/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HKHPerson == null)
            {
                return NotFound();
            }

            var hKHPerson = await _context.HKHPerson.FindAsync(id);
            if (hKHPerson == null)
            {
                return NotFound();
            }
            return View(hKHPerson);
        }

        // POST: HKHPerson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName,PersonPhone")] HKHPerson hKHPerson)
        {
            if (id != hKHPerson.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hKHPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HKHPersonExists(hKHPerson.PersonID))
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
            return View(hKHPerson);
        }

        // GET: HKHPerson/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HKHPerson == null)
            {
                return NotFound();
            }

            var hKHPerson = await _context.HKHPerson
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (hKHPerson == null)
            {
                return NotFound();
            }

            return View(hKHPerson);
        }

        // POST: HKHPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HKHPerson == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HKHPerson'  is null.");
            }
            var hKHPerson = await _context.HKHPerson.FindAsync(id);
            if (hKHPerson != null)
            {
                _context.HKHPerson.Remove(hKHPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HKHPersonExists(string id)
        {
          return (_context.HKHPerson?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }
    }
}
