using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class OrderDetails
    {
        public string OrderDetailsID { get; set; }              
        public Form Form { get; set; }
        public Lottery Lottery { get; set; }
        public string OrderDetailsBets { get; set; }
    }
}