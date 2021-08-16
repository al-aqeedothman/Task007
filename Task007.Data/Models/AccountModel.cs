using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_007.Data.Models
{
    public class AccountModel
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }

        public string WebSiteUrl { get; set; }

        public string Telephone1 { get; set; }

        public string Revenue { get; set; }

        public string IndustryCode { get; set; }

        public string EmailAddress1 { get; set; }

        public string owninguser { get; set; }
    }
}