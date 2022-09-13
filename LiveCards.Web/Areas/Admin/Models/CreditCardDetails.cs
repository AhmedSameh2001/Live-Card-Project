using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class CreditCardDetails
    {
        [JsonProperty("credit_card_number")]
        public string CreditCardNumber { get; set; }

        [JsonProperty("credit_card_type")]
        public string CardType { get; set; }

        [JsonProperty("credit_transaction_type")]
        public string TransactionType { get; set; }
 
        [JsonProperty("credit_card_payments")]
        public string Payments { get; set; }

        [JsonProperty("credit_card_summery")]
        public string Summery { get; set; }

    }
}
