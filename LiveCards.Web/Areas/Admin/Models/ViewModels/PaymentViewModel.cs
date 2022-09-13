using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveCards.Models;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class PaymentViewModel
    { 
        public int InvoiceId { get; set; }
        public int Type { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
          public string DealerNumber { get; set; } 
        
        public string CreateDate { get; set; }
        public int TaxType { get; set; }
        public string Description { get; set; }
        public string PaymentsJson { get; set; }
        public string PaymentsItemsJson { get; set; }
        public string Note { get; set; }
        public string DocumentAction { get; set; }
    }
}
