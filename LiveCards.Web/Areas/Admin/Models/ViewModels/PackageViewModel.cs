using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class PackageViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        //public string VoiceMinutes { get; set; }
        public string DataSize { get; set; }
       // public string PalestineMinutes { get; set; }
        public string Cost { get; set; }
       // public string SellingPrice { get; set; }
        public System.DateTime? StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public  bool? Enable { get; set; }
        public string UserId { get; set; }
        public System.DateTime? AddedDate { get; set; }
        public bool? Prepaid { get; set; }
        public decimal? PriceDealer { get; set; }
        public decimal? PriceClient { get; set; }
        public decimal? PriceShopping { get; set; }
        public int? PriceId { get; set; }

        public int OfferId { get; set; }
        public decimal? OfferPriceDealer { get; set; }
        public decimal? OfferPriceClient { get; set; }
        public decimal? OfferPriceOperator { get; set; }
        public int? OfferMonths { get; set; }

    }
}