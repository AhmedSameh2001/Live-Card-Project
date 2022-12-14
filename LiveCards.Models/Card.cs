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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Card
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Card()
        {
            this.AgentCards = new HashSet<AgentCard>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string? Image { get; set; }
        public int BrandId { get; set; }
        public decimal CostUSD { get; set; }
        public System.DateTime AddedDate { get; set; }
        public bool Active { get; set; }
        public decimal AgentPercent { get; set; }
        public decimal SellerPercent { get; set; }
        public decimal CustomerPercent { get; set; }
 
        public bool IsDeleted { get; set; }
        public string Note { get; set; }

        public bool IsAvailable { get; set; }
        public string? ApiSku { get; set; }
        public string? CustomMapping { get; set; } //Used when map card to multiple cards in api 
        public string? ApiName { get; set; }
        public string? countries { get; set; }
        public string? platforms { get; set; }
        public string? languages { get; set; }

        public string? FaceValueAmount { get; set; }
        public string? FaceValueCurrency { get; set; }
        public string? DefaultPriceAmount { get; set; }
        public string? DefaultPriceCurrency { get; set; }


        [ForeignKey("BrandId")]
        [InverseProperty("Cards")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<AgentCard> AgentCards { get; set; }

    }
}
