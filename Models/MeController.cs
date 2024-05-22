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
    public class MeController : Controller
    {
        private readonly TeQIZ_WEBSITEContext _context;

        public MeController(TeQIZ_WEBSITEContext context)
        {
            _context = context;
        }

        // GET: Me
        public async Task<IActionResult> Index()
        {
            return View(await _context.Me.ToListAsync());
        }

        // GET: Me/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.Me
                .FirstOrDefaultAsync(m => m.id == id);
            if (me == null)
            {
                return NotFound();
            }

            return View(me);
        }

        // GET: Me/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Me/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name")] Me me)
        {
            if (ModelState.IsValid)
            {
                _context.Add(me);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(me);
        }

        // GET: Me/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.Me.FindAsync(id);
            if (me == null)
            {
                return NotFound();
            }
            return View(me);
        }

        // POST: Me/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name")] Me me)
        {
            if (id != me.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(me);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeExists(me.id))
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
            return View(me);
        }

        // GET: Me/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.Me
                .FirstOrDefaultAsync(m => m.id == id);
            if (me == null)
            {
                return NotFound();
            }

            return View(me);
        }

        // POST: Me/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var me = await _context.Me.FindAsync(id);
            if (me != null)
            {
                _context.Me.Remove(me);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeExists(int id)
        {
            return _context.Me.Any(e => e.id == id);
        }
    }
}
