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
    public class HKHStudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HKHStudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HKHStudent
        public async Task<IActionResult> Index()
        {
              return _context.HKHStudent != null ? 
                          View(await _context.HKHStudent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HKHStudent'  is null.");
        }

        // GET: HKHStudent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HKHStudent == null)
            {
                return NotFound();
            }

            var hKHStudent = await _context.HKHStudent
                .FirstOrDefaultAsync(m => m.HKHStudentName == id);
            if (hKHStudent == null)
            {
                return NotFound();
            }

            return View(hKHStudent);
        }

        // GET: HKHStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HKHStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HKHStudentName,HKHStudentAddress,HKHStudentPhone")] HKHStudent hKHStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hKHStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hKHStudent);
        }

        // GET: HKHStudent/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HKHStudent == null)
            {
                return NotFound();
            }

            var hKHStudent = await _context.HKHStudent.FindAsync(id);
            if (hKHStudent == null)
            {
                return NotFound();
            }
            return View(hKHStudent);
        }

        // POST: HKHStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HKHStudentName,HKHStudentAddress,HKHStudentPhone")] HKHStudent hKHStudent)
        {
            if (id != hKHStudent.HKHStudentName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hKHStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HKHStudentExists(hKHStudent.HKHStudentName))
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
            return View(hKHStudent);
        }

        // GET: HKHStudent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HKHStudent == null)
            {
                return NotFound();
            }

            var hKHStudent = await _context.HKHStudent
                .FirstOrDefaultAsync(m => m.HKHStudentName == id);
            if (hKHStudent == null)
            {
                return NotFound();
            }

            return View(hKHStudent);
        }

        // POST: HKHStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HKHStudent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HKHStudent'  is null.");
            }
            var hKHStudent = await _context.HKHStudent.FindAsync(id);
            if (hKHStudent != null)
            {
                _context.HKHStudent.Remove(hKHStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HKHStudentExists(string id)
        {
          return (_context.HKHStudent?.Any(e => e.HKHStudentName == id)).GetValueOrDefault();
        }
    }
}
