﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Order
    {
        public string ID { get; set; }
        public DateTime Date { get; set; }
        public List<OrderDetails> Orders { get; set; }
        public User User { get; set; }
        public string Paid { get; set; }
        public double Sum { get; set; }

    }
}