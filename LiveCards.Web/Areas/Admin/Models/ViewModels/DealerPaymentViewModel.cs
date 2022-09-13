using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveCards.Models;

namespace LiveCards.Web.Areas.Admin.Models.ViewModels
{
    public class DealerPaymentViewModel
    {
        public Agent Dealer { set; get; }
        public IEnumerable<DealerBill> DealerBills { set; get; }
        public IEnumerable<DealerInvoice> DealerInvoices { set; get; }
        public List<int?> CompanyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
        public string Sortby;
        public int SortType = 0;


        public DealerPaymentViewModel()
        {
            DealerBills= new List<DealerBill>();
            DealerInvoices = new List<DealerInvoice>();

        }

    }
}