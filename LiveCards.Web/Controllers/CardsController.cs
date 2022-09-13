using AutoMapper;
using LiveCards.Data;
using LiveCards.Models;
using LiveCards.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveCards.Web.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CardsService _cardsService;
        public readonly IMapper _mapper;

        public CardsController(ApplicationDbContext context, CardsService cardsService, IMapper mapper)
        {
            _context = context;
            _cardsService = cardsService;
            _mapper = mapper;
        }

        // GET: CardsController

        public async Task<IActionResult> Index(CardSearchModel model)
        {
            var data = new List<CardModel>();
            var userId = "";


            if (User.IsInRole("Agent"))
            {
                data = _cardsService.GetCardsForAgent(model, userId);

            }
            else
            {
                data = _cardsService.GetCardsForCustomer(model);
            }

            

            //var dd = _mapper.Map<CardModel>(_context.Cards.FirstOrDefault()); 
            return View(data.Take(20));
        }

        // GET: CardsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CardsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CardsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CardsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
