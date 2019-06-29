using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Lottery
    {
        public string ID { get; set; }        
        public string Name { get; set; }        
        public DateTime Date { get; set; }
        public string Bets { get; set; }
        public string TypeID { get; set; }

    }
}