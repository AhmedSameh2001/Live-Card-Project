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
    
    public partial class DelearsAdverty
    {
        public int Id { get; set; }
        public Nullable<int> AdvertysId { get; set; }
        public Nullable<int> DelearsId { get; set; }
    
        public virtual Adverty Adverty { get; set; }
        public virtual Agent Distributor { get; set; }
    }
}
