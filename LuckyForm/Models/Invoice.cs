using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Invoice
    {
        public string Payments { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public List<OrderDetails> Products { get; set; }
    }
}