using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveCards.Data;
using LiveCards.Models;
using LiveCards.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FileUpload _fileUpload;
        public BrandsController(ApplicationDbContext context, FileUpload  fileUpload)
        {
            _context = context;
            _fileUpload =  fileUpload;

        }
         
        // GET: Admin/Brands
        public async Task<IActionResult> Index(int? categoryId, string? name  )
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name",categoryId);


            var data =  _context.Brands.Include(x => x.Category).AsQueryable();

            if (categoryId != null)
            {
                data = data.Where(x => x.CategoryId == categoryId); 
            }

            if(name != null)
            {
                data = data.Where(x => x.Name.Contains(name) || x.NameEn.Contains(name) || x.NameHe.Contains(name) );
            }

            return  View(data.ToList()  )  ;
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var Brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Brand == null)
            {
                return NotFound();
            }

            return View(Brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name"); 
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(  Brand Brand, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    Brand.Image = _fileUpload.SaveImage(Image,"brands");
                }

                _context.Add(Brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");

            return View(Brand);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var Brand = await _context.Brands.FindAsync(id);
            if (Brand == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(Brand);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Brand Brand, IFormFile Image)
        {
            if (id != Brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        Brand.Image = _fileUpload.SaveImage(Image, "brands");
                    }

                    _context.Update(Brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(Brand.Id))
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
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(Brand);
        }

        // GET: Admin/Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var Brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Brand == null)
            {
                return NotFound();
            }

            return View(Brand);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Brands'  is null.");
            }
            var Brand = await _context.Brands.FindAsync(id);
            if (Brand != null)
            {
                _context.Brands.Remove(Brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return (_context.Brands?.Any(e => e.Id == id)).GetValueOrDefault();
        }


   
    }
}
