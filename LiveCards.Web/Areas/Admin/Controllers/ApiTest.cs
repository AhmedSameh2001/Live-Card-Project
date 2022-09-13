using LiveCards.Data;
using LiveCards.Models;
using LiveCards.Web.Models.TalTelecom;
using Microsoft.AspNetCore.Mvc;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiTest : Controller
    {

        private readonly ApplicationDbContext _context;
        public ApiTest(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index ()
        {
            //await SaveProductsResponseAsync(1);

            CheckPrepaidForgeBrands();
            return View();
        }

        private void CheckPrepaidForgeBrands()
        {
            var brands = _context.Brands.Where(x => !x.Cards.Any(x => x.Active));
          
            foreach (var item in brands)
            {
                item.IsActive = false;
                item.ShowInMenu = false;
            }

            _context.Brands.UpdateRange(brands); 
            _context.SaveChanges();
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
                    Details =item.NameAr + "<br>" + item.DescAr1 + "<br>" + item.DescAr2 + "<br>" +   item.DescAr3  ,
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

               _context. Cards.Add(card);   

            }


            _context.SaveChanges(); 
        }
    }
}
