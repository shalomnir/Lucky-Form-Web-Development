using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Data
    {
       public Order order { get; set; }
       public int NumOfTabels { get; set; }
       public int NumsInTable { get; set; }
       public string Bets { get; set; }
       public string StrongBets { get; set; }
       public double price { get; set; }
     
    } 
}