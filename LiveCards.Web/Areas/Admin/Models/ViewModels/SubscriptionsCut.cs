using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveCards.Models;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class SubscriptionsCut
    {
        public List<SubscriptionCutData> SubscriptionList { set; get; } 
    }


    public class SubscriptionCutData
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CutDate { get; set; }
        public string Status1 { get; set; }
        public string Status2 { get; set; }
        public string Action { get; set; }
        public bool AutoRenewal { get; set; }
    }
}