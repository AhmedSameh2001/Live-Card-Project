using LiveCards.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LiveCards.Data;

namespace LiveCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.CategoriesCards = _context.Categories.Where(x => x.IsActive == true).Select(
              x => new CategoryCardsViewModel()
              {
                  Title = x.Name,
                  TitleEn = x.NameEn,
                  TitleHe = x.NameHe,
                  CategoryId = x.Id,
                  Cards = x.Brands.SelectMany(x => x.Cards).Where(x => x.Active == true && x.IsAvailable == true).Select(card => new CardModel()
                  {
                      Id = card.Id,
                      Name = card.Name,
                      Image = card.Image,
                      Price = card.CostUSD + (card.CustomerPercent * card.CostUSD),
                  }).Take(6)
              }).Skip(1) .Take(3).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string redirectUrl)
        {
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }
            return LocalRedirect(redirectUrl);
        }
    }
}