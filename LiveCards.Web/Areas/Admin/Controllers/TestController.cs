using Microsoft.AspNetCore.Mvc;

namespace LiveCards.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        // GET: Admin/Test

        //public ActionResult Index()
        //{

        //    //var day1 = new DateTime(2021, 1, 1);
        //    var logs = new EntitiesLogs();
        //    //var date = DateTime.Now.AddHours(-1);
        //    var subscriptions = logs.SubscriptionStatusLogsReports.OrderByDescending(x => x.Id).ToList();
        //    var ratio = 1;
        //    Entities db = new Entities();

        //    foreach (var item in subscriptions)
        //    {
        //        var subscription = _contextSubscriptions.Find(int.Parse(item.PhoneNumber));

        //        try
        //        {
        //            var package = _contextPackages.Find(subscription.PackageId);

        //            var dealers = getAllDealersIds(subscription);

        //            foreach (var dealerId in dealers)
        //            {
        //                var dealer = _contextDistributors.Find(dealerId);
        //                decimal amount = 0;

        //                var lastPrice = _contextSubscriptionPrices.FirstOrDefault(x => x.SubscriptionId == subscription.Id && x.BillType == (int)BillType.Dealer &&
        //                  x.DealerId == dealer.Id);

        //                if (lastPrice != null)
        //                {
        //                    amount = ratio * (decimal)lastPrice.Price;
        //                }

        //                var dealerbill = new DealerBills2()
        //                {
        //                    SubscriptionId = subscription.Id,
        //                    Amount = amount,
        //                    DateAdded = item.DateAdded,
        //                    DealerFromId = dealer.Id,
        //                    DealerToId = dealer.HeadDelear,
        //                    IsMainDealer = dealer.HeadDelear == null,
        //                    Type = dealer.Id == subscription.DealerId ? (int)BillTypes.LEAD : (int)BillTypes.Supplier,
        //                    IsDeleted = amount == 0,
        //                    IsPaid = false,
        //                    //IsClosed = true,
        //                    //DealerInvoiceId = dealer.DealerInvoices.FirstOrDefault(x => x.DateClosed > day1).Id
        //                };

        //                logs.DealerBills2.Add(dealerbill);
        //            }

        //            _contextSaveChanges();
        //            logs.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            //try
        //            //{
        //            //    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

        //            //    EmailProvider.sendEmailToITSupport("PrepareRenewSubscriptionBills", Newtonsoft.Json.JsonConvert.SerializeObject(ex));
        //            //}
        //            //catch (Exception) { }

        //        }

        //    }
        //    return View();
        //}

        //public List<int> getAllDealersIds(LiveCards.Models.Subscription subscription)
        //{
        //    Entities db = new Entities();

        //    var dealers = new List<int>() { };
        //    var dealer = _contextDistributors.Find(subscription.DealerId);

        //    while (dealer != null)
        //    {
        //        dealers.Add((int)dealer.Id);

        //        dealer = dealer.Distributor1;
        //    }

        //    return dealers;
        //}



    }

}