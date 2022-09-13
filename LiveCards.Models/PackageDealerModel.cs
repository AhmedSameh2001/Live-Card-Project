using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Models
{
    public class PackageDealerModel
    {
        public int Id { get; set; }
        public int? PackageId { get; set; }
        public int? DealerId { get; set; }
        public decimal? PriceDealer { get; set; }
        public decimal? PriceReseller { get; set; }
        public decimal? PriceCustomer { get; set; }
        public bool? IsUpdated { get; set; }
        public bool? IsActive { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? Cost { get; set; }
        public decimal? PriceCustomerOffer { get; set; }
        public decimal? PriceDealerOffer { get; set; }
        public decimal? PriceCostOffer { get; set; }

        public string ErrorMessage { get; set; }


    }
}