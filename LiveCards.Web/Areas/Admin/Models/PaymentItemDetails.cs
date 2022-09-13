using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class PaymentItemDetails
    {
        [JsonProperty("payment_item_tax_type")]
        public int TaxType { get; set; }
        
        [JsonProperty("payment_item_amount")]
        public decimal? Amount { get; set; }
 

        [JsonProperty("payment_item_details")]
        public string Details { get; set; }
        
    }
}
