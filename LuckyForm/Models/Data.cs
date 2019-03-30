using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Data
    {
       public Order Order { get; set; }
       public int NumOfTabels { get; set; }
       public int NumsInTable { get; set; }
       public string Bets { get; set; }      
       public double Price { get; set; }
       public string StrongBets { get; set; }

    } 
}