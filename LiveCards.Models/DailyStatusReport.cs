using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Models
{
    public class DailyStatusReport
    {
        public DateTime? DateAdded { get; set; }
        public int? SubscriptionId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        //public  int? CurrentStatus { get; set; }
        public string CurrentStatusText { get; set; }
        //public int? APIStatus { get; set; }
        public string APIStatusText { get; set; }
        public string Description { get; set; }

    }
}