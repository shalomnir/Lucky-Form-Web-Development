using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCompany.Models
{
    public class Deal
    {
        public string ID { get; set; }
        public string CardID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int Payments { get; set; }
    }
}