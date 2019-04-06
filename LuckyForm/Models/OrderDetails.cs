using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class OrderDetails
    {
        public string ID { get; set; }              
        public Form Form { get; set; }
        public string OrderID { get; set; }
        public Lottery Lottery { get; set; }
        public string Bets { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}