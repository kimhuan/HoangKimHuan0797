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
    public class HKHEmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HKHEmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HKHEmployee
        public async Task<IActionResult> Index()
        {
              return _context.HKHEmployee != null ? 
                          View(await _context.HKHEmployee.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HKHEmployee'  is null.");
        }

        // GET: HKHEmployee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HKHEmployee == null)
            {
                return NotFound();
            }

            var hKHEmployee = await _context.HKHEmployee
                .FirstOrDefaultAsync(m => m.HKHEmployeeID == id);
            if (hKHEmployee == null)
            {
                return NotFound();
            }

            return View(hKHEmployee);
        }

        // GET: HKHEmployee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HKHEmployee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HKHEmployeeID,HKHEmployeeName,HKHEmployeeAddress")] HKHEmployee hKHEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hKHEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hKHEmployee);
        }

        // GET: HKHEmployee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HKHEmployee == null)
            {
                return NotFound();
            }

            var hKHEmployee = await _context.HKHEmployee.FindAsync(id);
            if (hKHEmployee == null)
            {
                return NotFound();
            }
            return View(hKHEmployee);
        }

        // POST: HKHEmployee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HKHEmployeeID,HKHEmployeeName,HKHEmployeeAddress")] HKHEmployee hKHEmployee)
        {
            if (id != hKHEmployee.HKHEmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hKHEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HKHEmployeeExists(hKHEmployee.HKHEmployeeID))
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
            return View(hKHEmployee);
        }

        // GET: HKHEmployee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HKHEmployee == null)
            {
                return NotFound();
            }

            var hKHEmployee = await _context.HKHEmployee
                .FirstOrDefaultAsync(m => m.HKHEmployeeID == id);
            if (hKHEmployee == null)
            {
                return NotFound();
            }

            return View(hKHEmployee);
        }

        // POST: HKHEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HKHEmployee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HKHEmployee'  is null.");
            }
            var hKHEmployee = await _context.HKHEmployee.FindAsync(id);
            if (hKHEmployee != null)
            {
                _context.HKHEmployee.Remove(hKHEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HKHEmployeeExists(string id)
        {
          return (_context.HKHEmployee?.Any(e => e.HKHEmployeeID == id)).GetValueOrDefault();
        }
    }
}
