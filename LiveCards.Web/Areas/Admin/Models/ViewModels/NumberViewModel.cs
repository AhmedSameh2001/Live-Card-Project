using System;
using System.Collections.Generic;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class NumberViewModel
    {
        public NumberViewModel()
        {
        }

        public int Id { get; set; }
        public string DealerName { get; set; }
        public string CompanyName { get; set; }
        public int? Size { get; set; }
        public string CustomerName { get; set; }
        public bool? Used { get; set; }
        public string Phone { get; set; }
        public DateTime? DateAdd { get; set; }
     
    }
}