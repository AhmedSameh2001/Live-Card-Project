using LiveCards.Data;
using LiveCards.Models;
using LiveCards.Services;
using LiveCards.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CardsService _cardsService;
        private readonly FileUpload _fileUpload;

        public CardsController(ApplicationDbContext context, CardsService cardsService
            , FileUpload fileUpload)
        {
            _context = context;
            _cardsService = cardsService;
            _fileUpload = fileUpload;
        }

        // GET: Admin/Cards
        public async Task<IActionResult> Index(int? categoryId, int? brandId,bool? active = true, string keyword = "" , int pageSize = 50, int pageId = 1)
        {
            var data = _cardsService.GetCards(categoryId, brandId, keyword,active, pageSize, pageId).ToList();

            ViewData["Brands"] = new SelectList( _context.Brands.Where(x => x.IsActive).ToList(),"Id","Name" , brandId) ;
            ViewData["Categories"] = new SelectList( _context.Categories.Where(x => x.IsActive).ToList(),"Id","Name" , categoryId);
             

            return View(data);
        }

        // GET: Admin/Cards/Create
        public IActionResult Create()
        {
            ViewData["Brands"] = _context.Brands.Where(x => x.IsActive).ToList();
            ViewData["Categories"] = _context.Categories.Where(x => x.IsActive).ToList();

            ViewBag.AgentPercent = SettingsManager.GetSetting(_context, SettingsKeys.AgentPercent);
            ViewBag.DealerPercent = SettingsManager.GetSetting(_context, SettingsKeys.DealerPercent);
            ViewBag.CustomerPercent = SettingsManager.GetSetting(_context, SettingsKeys.CustomerPercent);

            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card, IFormFile Image, bool addCardToAllAgents = false)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    card.Image = _fileUpload.SaveImage(Image, "cards");
                }

                if (addCardToAllAgents)
                {
                    var agents = _context.Agents.Where(x => x.IsDeleted != true).ToList();

                    foreach (var agent in agents)
                    {
                        var agentCost = card.CostUSD + (card.CostUSD * (card.AgentPercent / 100));
                        var sellerCost = card.CostUSD + (card.CostUSD * (card.SellerPercent / 100));
                        var customerCost = card.CostUSD + (card.CostUSD * (card.CustomerPercent / 100));

                        card.AgentCards.Add(new AgentCard()
                        {
                            AgentId = agent.Id,
                            Cost = agentCost,
                            IsActive = true,
                            PriceAgent = sellerCost,
                            PriceCustomer = customerCost,
                        });
                    }
                }

                _context.Add(card);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = card.Id });
            }

            ViewData["Brands"] = _context.Brands.Where(x => x.IsActive).ToList();
            ViewData["Categories"] = _context.Categories.Where(x => x.IsActive).ToList();

            ViewBag.AgentPercent = SettingsManager.GetSetting(_context, SettingsKeys.AgentPercent);
            ViewBag.DealerPercent = SettingsManager.GetSetting(_context, SettingsKeys.DealerPercent);
            ViewBag.CustomerPercent = SettingsManager.GetSetting(_context, SettingsKeys.CustomerPercent);

            return View(card);
        }

        // GET: Admin/Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var Card = await _context.Cards.Include(x => x.AgentCards).ThenInclude(x=>x.Agent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Card == null)
            {
                return NotFound();
            }

            ViewData["Brands"] = _context.Brands.Where(x => x.IsActive).ToList();
            ViewData["Categories"] = _context.Categories.Where(x => x.IsActive).ToList();
            //var agentList = _context.Agents.Where(x => x.IsDeleted != true && x.Active && x.ParentAgentId == null).OrderBy(x => x.Name).ToList();

            var dealerTest = Card.AgentCards.Select(x => new
            {
                x.Id,
                x.Card.Name,
                //x.HeadDelear,
                //SubCount = x.Distributors1.Count(),
                //status = 0,
                x.IsActive,// Model.PackageDealers.Count(p => p.DealerId == x.Id && p.IsActive == true) > 0 ? "checked" : ""
                x.Cost
            }).ToList();

            ViewBag.agentData = Newtonsoft.Json.JsonConvert.SerializeObject(dealerTest);



            return View(Card);
        }


        // GET: Admin/Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var Card = await _context.Cards.FindAsync(id);
            if (Card == null)
            {
                return NotFound();
            }
            return View(Card);
        }

        // POST: Admin/Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Card Card, IFormFile Image)
        {
            if (id != Card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        Card.Image = _fileUpload.SaveImage(Image, "cards");
                    }

                    _context.Update(Card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(Card.Id))
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
            return View(Card);
        }

        // GET: Admin/Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var Card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Card == null)
            {
                return NotFound();
            }

            return View(Card);
        }

        // POST: Admin/Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cards'  is null.");
            }
            var Card = await _context.Cards.FindAsync(id);
            if (Card != null)
            {
                _context.Cards.Remove(Card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return (_context.Cards?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
