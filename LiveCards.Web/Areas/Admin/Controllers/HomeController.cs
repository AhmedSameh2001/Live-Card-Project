//using LiveCards.Data;
using LiveCards.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Drawing;
using LiveCards.Web.Models.TalTelecom;
using LiveCards.Models;
using LiveCards.Data;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _roleManager = roleManager;
            _webHostEnvironment = hostEnvironment;
        }


        // GET: HomeController
        public async Task<ActionResult> IndexAsync()
        {


           //await SaveProductsResponseAsync(1);



            //var cards = _context.Cards.ToList();
            //var agents = _context.Agents.Where(x => x.IsDeleted != true).ToList();

            //foreach (var card in cards)
            //{
            //    foreach (var agent in agents)
            //    {
            //        var agentCost = card.CostUSD + (card.CostUSD * (card.AgentPercent / 100));
            //        var sellerCost = card.CostUSD + (card.CostUSD * (card.SellerPercent / 100));
            //        var customerCost = card.CostUSD + (card.CostUSD * (card.CustomerPercent / 100));

            //        card.AgentCards.Add(new LiveCards.Models.AgentCard()
            //        {
            //            AgentId = agent.Id,
            //            Cost = agentCost,
            //            IsActive = true,
            //            PriceAgent = sellerCost,
            //            PriceCustomer = customerCost,
            //        });
            //    }
            //}
            //_context.SaveChanges();



            //PrepaidForgeAPI api = new PrepaidForgeAPI(_context);
            // await api.RefreshProductsAsync();




            //ViewBag.temp = _context.Temp_PrepaidForgeStocks.Count();

            TalTelecomBot api = new TalTelecomBot(_context);

            var dd2 = await api.RefreshToken();
            var dd = await api.GetProducts(1);
            ViewBag.temp = dd.Count(); 
            // ViewBag.TalTel
            //
            //
            //
            // ecom_ProductCount = dd.Count();

            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public async Task<ActionResult> TestAsync()
        {
            PrepaidForgeAPI api = new PrepaidForgeAPI(_context);


            await api.SaveProductsandStocks();

            return View();
        }



        public string SaveImage(string imageUrl/*, string filename, ImageFormat format*/)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/cards", imageUrl.Split("/").LastOrDefault());

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(path/*, format*/);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();

            return path;
        }


        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }



        private async Task SaveProductsResponseAsync(int id)
        {
            TalTelecomBot api = new TalTelecomBot(_context);

            var dd2 = await api.RefreshToken();
            var products = await api.GetProducts(id);
            var percent = 0.195M;
            var cards = new List<Card>();


            foreach (var item in products)
            {
                var cost = item.Amount - (percent * item.Amount);
                var card = new Card()
                {

                    Name = item.Name,
                    AddedDate = DateTime.Now,
                    Details = item.NameAr + "<br>" + item.DescAr1 + "<br>" + item.DescAr2 + "<br>" + item.DescAr3,
                    //DetailsHe = "",
                    Image = "https://mtopup.taltelecom.com/assets/images/products/" + item.Picture,
                    BrandId = 387, // should be saved in enum 
                    CostUSD = cost,
                    Active = true,
                    AgentPercent = 10,
                    SellerPercent = 12,
                    CustomerPercent = 15,

                    IsDeleted = false,
                    Note = "auto added from taltelecom bot  ",

                    IsAvailable = true,
                    //CustomMapping = "", //Used when map card to multiple cards in api 

                    ApiName = "TalTelecom",
                    ApiSku = item.ProviderId.ToString(),

                    FaceValueAmount = item.Amount.ToString(),
                    FaceValueCurrency = "NIS",
                    DefaultPriceAmount = cost.ToString(),
                    DefaultPriceCurrency = "NIS",
                };

                _context.Cards.Add(card);

            } 
            _context.SaveChanges();
        }

    }
}
