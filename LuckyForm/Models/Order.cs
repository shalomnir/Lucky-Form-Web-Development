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
        public Lottery Lottery { get; set; }
        public User User { get; set; }
        public Data Data { get; set; }
        public string Paid { get; set; }
        public double Sum { get; set; }

    }
}