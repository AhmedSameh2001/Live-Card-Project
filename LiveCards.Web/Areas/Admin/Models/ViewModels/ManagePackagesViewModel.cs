namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{  
    public class ManagePackagesViewModel
    {
        public ManagePackagesViewModel()
        {
        }

        public int Id { get; set; }
 
        public string CompanyName { get; set; }
        public int? GB { get; set; }
        public string Name { get; set; }
        public int? Months { get; set; }
        public int? OfferId { get; set; }
        public decimal? PriceDealer { get; set; }
        public decimal? PriceShop { get; set; }
        public decimal? OfferCost { get; set; }
        public decimal? PriceOfferCustomer { get; set; }
        public decimal? PriceOfferShop { get; set; }
        public decimal? PriceOfferDealer { get; set; }
        public bool? IsActive { get; set; }
        public bool IsSpecial { get; set; }
        public decimal? PriceCostOffer { get; set; }
        public decimal? Cost { get; set; }
        public bool IsOld { get; internal set; }
        public int? PackageDealerId { get; internal set; }
    }
}