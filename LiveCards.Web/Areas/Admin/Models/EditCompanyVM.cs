using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Areas.Admin.Models
{
    public class EditCompanyVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ExistingLogoPath { get; set; }
        public string PostalCode { get; set; }
        public string Color { get; set; }
        public int? SIMLength { get; set; }
    }
}