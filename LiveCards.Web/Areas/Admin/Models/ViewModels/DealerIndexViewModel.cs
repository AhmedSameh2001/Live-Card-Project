using System;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class DealerIndexViewModel
    {
        public DealerIndexViewModel()
        {
        }

        public int Id { get; set; }
        public int? HeadDealer { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public decimal? Credit { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string MainDealerName { get; set; }
        public int SubDealerCount { get; set; }
        public int NumbersCount { get; set; }
        public decimal? TotalBills { get; set; }
        public bool? NegativeCredit { get; internal set; }
    }
}