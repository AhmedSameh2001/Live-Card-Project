using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCards.Models
{
    public class CardSearchModel
    {
        public string? Keyword { get; set; }
        public List<int>? Brands { get; set; }
        public int? Category { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAvailable { get; set; }

    }
}
