using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveCards.Data;
using LiveCards.Models;
using Microsoft.AspNetCore.Authorization;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class AdvertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Adverties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Advertys.Include(a => a.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Adverties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advertys == null)
            {
                return NotFound();
            }

            var adverty = await _context.Advertys
                .Include(a => a.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adverty == null)
            {
                return NotFound();
            }

            return View(adverty);
        }

        // GET: Admin/Adverties/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Admin/Adverties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MessageHe,MessageAr,AddedOn,CompanyId,IsDeleted,Link")] Adverty adverty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adverty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Categories, "Id", "Id", adverty.CompanyId);
            return View(adverty);
        }

        // GET: Admin/Adverties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Advertys == null)
            {
                return NotFound();
            }

            var adverty = await _context.Advertys.FindAsync(id);
            if (adverty == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Categories, "Id", "Id", adverty.CompanyId);
            return View(adverty);
        }

        // POST: Admin/Adverties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MessageHe,MessageAr,AddedOn,CompanyId,IsDeleted,Link")] Adverty adverty)
        {
            if (id != adverty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adverty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertyExists(adverty.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Categories, "Id", "Id", adverty.CompanyId);
            return View(adverty);
        }

        // GET: Admin/Adverties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Advertys == null)
            {
                return NotFound();
            }

            var adverty = await _context.Advertys
                .Include(a => a.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adverty == null)
            {
                return NotFound();
            }

            return View(adverty);
        }

        // POST: Admin/Adverties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Advertys == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Advertys'  is null.");
            }
            var adverty = await _context.Advertys.FindAsync(id);
            if (adverty != null)
            {
                _context.Advertys.Remove(adverty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertyExists(int id)
        {
          return (_context.Advertys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
