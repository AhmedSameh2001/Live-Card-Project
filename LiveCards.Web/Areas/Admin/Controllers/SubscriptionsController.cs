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
    public class SubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Subscriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subscriptions.Include(s => s.Customer).Include(s => s.Number) .Include(s => s.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.Customer)
                .Include(s => s.Number)
                //.Include(s => s.Package)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Admin/Subscriptions/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["NumberId"] = new SelectList(_context.Numbers, "Id", "Id");
            //ViewData["PackageId"] = new SelectList(_context.Packages, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
            return View();
        }

        // POST: Admin/Subscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DealerId,NumberId,PhoneNumber,CustomerId,PackageId,CompanyId,GB,ConnectionDate,CutDate,SIMNumber,SIMCar,LastUpdate,DateAdd,StatusId,OpenService,AutomaticRenewal,RenewPackage,Note,SIMCarPrice,OldCompanyId,OldNumber,IsDeleted,SimStatus,IsOffer")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", subscription.CustomerId);
            ViewData["NumberId"] = new SelectList(_context.Numbers, "Id", "Id", subscription.NumberId);
            //ViewData["PackageId"] = new SelectList(_context.Packages, "Id", "Id", subscription.PackageId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", subscription.StatusId);
            return View(subscription);
        }

        // GET: Admin/Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", subscription.CustomerId);
            ViewData["NumberId"] = new SelectList(_context.Numbers, "Id", "Id", subscription.NumberId);
            //ViewData["PackageId"] = new SelectList(_context.Packages, "Id", "Id", subscription.PackageId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", subscription.StatusId);
            return View(subscription);
        }

        // POST: Admin/Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DealerId,NumberId,PhoneNumber,CustomerId,PackageId,CompanyId,GB,ConnectionDate,CutDate,SIMNumber,SIMCar,LastUpdate,DateAdd,StatusId,OpenService,AutomaticRenewal,RenewPackage,Note,SIMCarPrice,OldCompanyId,OldNumber,IsDeleted,SimStatus,IsOffer")] Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", subscription.CustomerId);
            ViewData["NumberId"] = new SelectList(_context.Numbers, "Id", "Id", subscription.NumberId);
            //ViewData["PackageId"] = new SelectList(_context.Packages, "Id", "Id", subscription.PackageId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", subscription.StatusId);
            return View(subscription);
        }

        // GET: Admin/Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.Customer)
                .Include(s => s.Number)
                //.Include(s => s.Package)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Admin/Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subscriptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
            }
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
          return (_context.Subscriptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
