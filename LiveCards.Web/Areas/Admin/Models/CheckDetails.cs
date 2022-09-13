using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class CheckDetails
    {
        //[JsonProperty("check_date")]
        //public string CheckDate { get; set; }

        [JsonProperty("check_number")]
        public string CheckNumber { get; set; }

        [JsonProperty("bank_name")]
        public string Bank { get; set; }

        [JsonProperty("bank_name_other")]
        public string BankNameOther { get; set; }
      
        [JsonProperty("bank_branch")]
        public string Branch { get; set; }

        [JsonProperty("bank_account")]
        public string BankAccount { get; set; }

        [JsonProperty("check_summery")]
        public string Summery { get; set; }

    }
}
