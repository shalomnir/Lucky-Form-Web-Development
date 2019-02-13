using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class Form
    {
        public string ID { get; set; }
        public int NumOfTables { get; set; }
        public int NumsInTables { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
    }
}