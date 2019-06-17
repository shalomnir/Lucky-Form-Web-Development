using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCompany.Models
{
    public class CreditCard
    {
        public string ID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }        
    }
}