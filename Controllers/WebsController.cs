using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeQIZ_WEBSITE.Data;
using TeQIZ_WEBSITE.Models;

namespace TeQIZ_WEBSITE.Controllers
{
    public class WebsController : Controller
    {
        private readonly TeQIZ_WEBSITEContext _context;

        public WebsController(TeQIZ_WEBSITEContext context)
        {
            _context = context;
        }

        // GET: Webs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Web.ToListAsync());
        }

        // GET: Webs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var web = await _context.Web
                .FirstOrDefaultAsync(m => m.Id == id);
            if (web == null)
            {
                return NotFound();
            }

            return View(web);
        }

        // GET: Webs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Webs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Project_Name,Client_Name,Description,Email,Phone_number,Created_by")] Web web)
        {
            if (ModelState.IsValid)
            {
                _context.Add(web);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(web);
        }

        // GET: Webs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var web = await _context.Web.FindAsync(id);
            if (web == null)
            {
                return NotFound();
            }
            return View(web);
        }

        // POST: Webs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Project_Name,Client_Name,Description,Email,Phone_number,Created_by")] Web web)
        {
            if (id != web.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(web);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebExists(web.Id))
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
            return View(web);
        }

        // GET: Webs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var web = await _context.Web
                .FirstOrDefaultAsync(m => m.Id == id);
            if (web == null)
            {
                return NotFound();
            }

            return View(web);
        }

        // POST: Webs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var web = await _context.Web.FindAsync(id);
            if (web != null)
            {
                _context.Web.Remove(web);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebExists(int id)
        {
            return _context.Web.Any(e => e.Id == id);
        }
    }
}
