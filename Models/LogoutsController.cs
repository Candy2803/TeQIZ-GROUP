using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeQIZ_WEBSITE.Data;

namespace TeQIZ_WEBSITE.Models
{
    public class LogoutsController : Controller
    {
        private readonly TeQIZ_WEBSITEContext _context;

        public LogoutsController(TeQIZ_WEBSITEContext context)
        {
            _context = context;
        }

        // GET: Logouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logout.ToListAsync());
        }

        // GET: Logouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logout = await _context.Logout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logout == null)
            {
                return NotFound();
            }

            return View(logout);
        }

        // GET: Logouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password")] Logout logout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logout);
        }

        // GET: Logouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logout = await _context.Logout.FindAsync(id);
            if (logout == null)
            {
                return NotFound();
            }
            return View(logout);
        }

        // POST: Logouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password")] Logout logout)
        {
            if (id != logout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogoutExists(logout.Id))
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
            return View(logout);
        }

        // GET: Logouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logout = await _context.Logout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logout == null)
            {
                return NotFound();
            }

            return View(logout);
        }

        // POST: Logouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logout = await _context.Logout.FindAsync(id);
            if (logout != null)
            {
                _context.Logout.Remove(logout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogoutExists(int id)
        {
            return _context.Logout.Any(e => e.Id == id);
        }
    }
}
