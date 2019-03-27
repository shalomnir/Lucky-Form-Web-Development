using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCompany.Models
{
    public class CreditCard
    {
        public string Number { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public string cvv { get; set; }
    }
}