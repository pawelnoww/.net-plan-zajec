using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plan_zajec.Data;
using Plan_zajec.Models;
using Microsoft.AspNetCore.Authorization;

namespace Plan_zajec.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lecturer
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Lecturer != null ? 
                          View(await _context.Lecturer.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Lecturer'  is null.");
        }

        // GET: Lecturer/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // GET: Lecturer/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,FirstName,SecondName,Title")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturer);
        }

        // GET: Lecturer/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        // POST: Lecturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,SecondName,Title")] Lecturer lecturer)
        {
            if (id != lecturer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturerExists(lecturer.ID))
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
            return View(lecturer);
        }

        // GET: Lecturer/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lecturer == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // POST: Lecturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lecturer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lecturer'  is null.");
            }
            var lecturer = await _context.Lecturer.FindAsync(id);
            if (lecturer != null)
            {
                _context.Lecturer.Remove(lecturer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturerExists(int id)
        {
          return (_context.Lecturer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
