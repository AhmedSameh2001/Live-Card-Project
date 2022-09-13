using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Models
{
    public class CompanyPaymentData
    {

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public int AmountPaid { get; set; }
    }
}