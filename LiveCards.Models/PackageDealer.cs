//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveCards.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PackageDealer
    {
        public int Id { get; set; }
        public Nullable<int> PackageId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<decimal> PriceDealer { get; set; }
        public Nullable<decimal> PriceReseller { get; set; }
        public Nullable<decimal> PriceCustomer { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> CurrentPrice { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> PriceCustomerOffer { get; set; }
        public Nullable<decimal> PriceDealerOffer { get; set; }
        public Nullable<decimal> PriceCostOffer { get; set; }
    
        public virtual Agent Distributor { get; set; }
        public virtual Package Package { get; set; }
    }
}