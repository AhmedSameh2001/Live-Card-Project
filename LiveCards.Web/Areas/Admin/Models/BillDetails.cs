using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class BillDetails
    {
       
        public string BillId { get; set; }
        
 
        public decimal? Amount { get; set; }

        public decimal? AmountPaid { get; set; }


    }
}
