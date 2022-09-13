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
    public class DelearsAdvertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DelearsAdvertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DelearsAdverties
        public async Task<IActionResult> Index()
        {
              return _context.DelearsAdvertys != null ? 
                          View(await _context.DelearsAdvertys.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DelearsAdvertys'  is null.");
        }

        // GET: Admin/DelearsAdverties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DelearsAdvertys == null)
            {
                return NotFound();
            }

            var delearsAdverty = await _context.DelearsAdvertys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delearsAdverty == null)
            {
                return NotFound();
            }

            return View(delearsAdverty);
        }

        // GET: Admin/DelearsAdverties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DelearsAdverties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdvertysId,DelearsId")] DelearsAdverty delearsAdverty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delearsAdverty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(delearsAdverty);
        }

        // GET: Admin/DelearsAdverties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DelearsAdvertys == null)
            {
                return NotFound();
            }

            var delearsAdverty = await _context.DelearsAdvertys.FindAsync(id);
            if (delearsAdverty == null)
            {
                return NotFound();
            }
            return View(delearsAdverty);
        }

        // POST: Admin/DelearsAdverties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdvertysId,DelearsId")] DelearsAdverty delearsAdverty)
        {
            if (id != delearsAdverty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delearsAdverty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelearsAdvertyExists(delearsAdverty.Id))
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
            return View(delearsAdverty);
        }

        // GET: Admin/DelearsAdverties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DelearsAdvertys == null)
            {
                return NotFound();
            }

            var delearsAdverty = await _context.DelearsAdvertys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delearsAdverty == null)
            {
                return NotFound();
            }

            return View(delearsAdverty);
        }

        // POST: Admin/DelearsAdverties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DelearsAdvertys == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DelearsAdvertys'  is null.");
            }
            var delearsAdverty = await _context.DelearsAdvertys.FindAsync(id);
            if (delearsAdverty != null)
            {
                _context.DelearsAdvertys.Remove(delearsAdverty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelearsAdvertyExists(int id)
        {
          return (_context.DelearsAdvertys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
