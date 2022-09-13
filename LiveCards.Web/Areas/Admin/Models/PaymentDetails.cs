using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class PaymentDetails 
    {
        [JsonProperty("payment_type")]
        public int Type { get; set; }
        
        [JsonProperty("payment_amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("payment_date")]
        public string Date { get; set; }

        [JsonProperty("payment_note")]
        public string Note { get; set; }

        [JsonProperty("credit_card_details")]
        public CreditCardDetails CeditCard { get; set; }

        [JsonProperty("check_details")]
        public CheckDetails Check { get; set; }
    }
}
