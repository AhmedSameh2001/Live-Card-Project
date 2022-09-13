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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

            webHostEnvironment = hostEnvironment;
        }



        // GET: Admin/Companies
        public ActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            //var categoryCount = _context.Categories.Count(x => x.Name == category.Name);
            //if (categoryCount == 0)
            //{

                if (ModelState.IsValid)
                {
                    category.IsActive = true;
                    _context.Categories.Add(category);
                    _context.SaveChanges();

                return Redirect("/Admin/categories");
            }

            return View(category);
            //}
            //else
            //{
            //    TempData["msg"] = "e: Category  " + category.Name + " already exist";
            //}


        }

        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                TempData["Message"] = "Not Found";
                return Redirect("/Admin/categories");
            }

            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                TempData["Message"] = "Not Found";
                return Redirect("/Admin/categories");
            }

            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CategoryExists(category.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }




        public ActionResult IsActive(int id)
        {

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                TempData["msg"] = "e: Category Not Found  ";

                return RedirectToAction(nameof(Index));
            }


            if (category.IsActive == false)
            {
                category.IsActive = true;
                TempData["msg"] = "s: Category is InActive successfully";
            }
            else
            {
                category.IsActive = false;
                TempData["msg"] = "s: Category is InActive successfully";
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
         
     
        //public ActionResult Delete(int id)
        //{

        //    var category = _context.Categories.Find(id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //        _context.SaveChanges();
        //    }

        //    TempData["msg"] = "s: Category is deleted successfully";

        //    return RedirectToAction(nameof(Index));
        //}




        //// POST: Admin/Categories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Id,Name,LogoUrl,Color,IsActive")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        // GET: Admin/Categories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Companies == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Companies.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

       


    }
}
