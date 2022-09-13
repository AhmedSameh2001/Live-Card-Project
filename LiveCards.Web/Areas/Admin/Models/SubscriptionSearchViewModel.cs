namespace LiveCards.Areas.Admin.Models
{
    public class SubscriptionSearchViewModel
    {
        //public List<SubscriptionViewModel> SubscriptionList { set; get; }
        public IDictionary<string, int> CompanyData { set; get; }
        public IDictionary<string, int> StatusData { set; get; }
        public IDictionary<string, int> PackageData { set; get; }
        public IDictionary<string, int> DealerData { set; get; }


        public SubscriptionSearchViewModel()
        {
            //SubscriptionList = new List<SubscriptionViewModel>(new List<SubscriptionViewModel>(), 1, 100);
            CompanyData = new Dictionary<string, int>();
            StatusData = new Dictionary<string, int>();
            DealerData = new Dictionary<string, int>();
            PackageData = new Dictionary<string, int>();
        }
    }


}