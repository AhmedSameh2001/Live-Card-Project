
using LiveCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class DailyReportViewModel
    {
        public int RevenueToday { get; set; }
        public int DisconnectionsToday { get; set; }
        public int AutomaticRenewalToday { get; set; }
        public int NewSubscriptionsToday { get; set; }
        public List<CompanyStatisticViewModel> CompanyNewSubscriptionsToday { get; set; }
        public List<CompanyStatisticViewModel> CompanyDisconnectionsToday { get; set; }
        public List<CompanyStatisticViewModel> CompanyAutomaticRenewalToday { get; set; }
        public List<Agent> ActiveDealersToday { get; set; }
    }

    public class CompanyStatisticViewModel
    {
        public int Value { get; set; }
        public string  Name { get; set; }
        public string  Image { get; set; }
        

        public CompanyStatisticViewModel(string name, string image, int value)
        {
            this.Name = name;
            this.Value = value;
            this.Image = image;
        }

    }

}