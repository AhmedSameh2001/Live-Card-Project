using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Models.APIModels
{
    public class APIResponse
    {
        public long Status { get; set; }
        public int SubscriptionId { get; set; }
        public string Desc { get; set; }
    }
}