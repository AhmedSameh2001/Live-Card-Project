using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveCards.Data;
using LiveCards.Models;
using Microsoft.AspNetCore.Identity;
using LiveCards.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class AgentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AgentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Agents
        public async Task<IActionResult> Index()
        {
            return _context.Agents != null ?
                        View(await _context.Agents.Where(x => !x.IsDeleted).Include(x => x.ApplicationUser).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Dealers'  is null.");
        }

        public async Task<IActionResult> IndexD()
        {
            var p = _context.Payments.Include(x => x.Agent).Where(x => !x.IsDelete).ToList();
            return View(p);
        }

        // GET: Admin/Agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Agent a = new Agent();
            Payment p = new Payment();

            if (id == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .Include(x => x.ApplicationUser)
                .Include(x => x.Agents)
                .Include(x => x.Payments).Where(w => !w.IsDeleted)
                .Include(x => x.AgentCards)
                .ThenInclude(c => c.Card.Brand)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            //ViewBag.AllCards = _context.Cards.Where(x=>!x.IsDeleted && x.Active  ).ToList(); 
            if (agent == null || agent.IsDeleted == true)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Admin/Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgentModel model, string? password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Agent");
                    var agent = new Agent();
                    agent.Name = model.Name;
                    agent.Credit = model.Credit;
                    agent.City = model.City;
                    agent.DateAdded = DateTime.Now;
                    agent.IsDeleted = false;
                    agent.UserId = user.Id;
                    agent.Address = model.Address;
                    agent.Phone = model.Phone;
                    agent.Mobile = model.Mobile;
                    agent.Active = model.Active;
                    agent.AllowSub = model.AllowSub;
                    agent.AllowLoan = model.AllowLoan;

                    ///TODO check this

                    //DealerBill bill = new DealerBill();
                    //bill.DateAdded = DateTime.Now;
                    //bill.Amount = -1 * model.Credit ?? 0;
                    //bill.IsDeleted = bill.Amount == 0;
                    //bill.IsPaid = model.Credit < 0 ? false : true;
                    //bill.IsClosed = false;
                    //bill.IsMainDealer = true;
                    //bill.Type = (int)BillTypes.Initial;
                    //bill.Sign = 1;

                    //distributor.DealerBills.Add(bill);

                    _context.Agents.Add(agent);
                    _context.SaveChanges();

                    //var packagesIds = _context.Packages.Where(x => x.IsDeleted != true).Select(x => x.Id).ToList();
                    //if (model.HeadDelear != null)
                    //{
                    //    packagesIds = _context.PackageDealers.Where(x => x.DealerId == model.HeadDelear)
                    //        .Select(x => (int)x.PackageId).ToList();
                    //}

                    //_dealerService.addPackagesToDealer(packagesIds, distributor.Id);

                    //TempData["msg"] = "s: " + Resources.General.SuccessMessage;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    result.Errors.ToList().ForEach(i => ModelState.AddModelError(i.Code, i.Description));

                    TempData["msg"] = "w: " + result.Errors.FirstOrDefault();
                }
            }
            return View(model);
        }

        // GET: Admin/Agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Admin/Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone2,City,HeadDelear,UserId,Active,DateAdded,Credit,AllowSub,IsDeleted,PaymentCycle,NegativeCredit,Address,Phone,Level,LastLogin,CreditChanges,LogoUrl,IsCompany,CompanyGUID,DataBaseName,Old_Id,CompanyEmail,MaxNegativeCredit,ShowAPIData")] Agent agent)
        {
            if (id != agent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.Id))
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
            return View(agent);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCardPrice(AgentCard model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var agentCard = _context.AgentCards.FirstOrDefault(x => x.Id == model.Id);
                    if (agentCard == null)
                    {
                        return NotFound();
                    }

                    agentCard.Cost = model.Cost;
                    agentCard.IsActive = model.IsActive;

                    _context.AgentCards.Update(agentCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!AgentExists(agent.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            return RedirectToAction(nameof(Details), new { id = model.AgentId });
        }
        //// GET: Admin/Agents/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Agents == null)
        //    {
        //        return NotFound();
        //    }

        //    var agent = await _context.Agents
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (agent == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(agent);
        //}

        // POST: Admin/Agents/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Agents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dealers'  is null.");
            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent != null)
            {
                agent.IsDeleted = true;
                //_context.Agents.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id)
        {
            return (_context.Agents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
