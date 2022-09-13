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
    
    public partial class SubscriptionPrice
    {
        public int Id { get; set; }
        public Nullable<int> SubscriptionId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> DealerLevel { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<int> DealerBillId { get; set; }
        public Nullable<int> BillType { get; set; }
        public Nullable<int> SubscriptionBillId { get; set; }
        public Nullable<int> DealerToId { get; set; }
    
        public virtual DealerBill DealerBill { get; set; }
        public virtual Agent Distributor { get; set; }
        public virtual SubscriptionBill SubscriptionBill { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}