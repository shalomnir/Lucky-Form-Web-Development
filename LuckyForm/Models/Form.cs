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

        public Form(string ID, int NumOfTables, int NumsInTables, string Name, string Type, string ImagePath)
        {
            this.ID = ID;
            this.NumOfTables = NumOfTables;
            this.NumsInTables = NumsInTables;
            this.Name = Name;
            this.Type = Type;
            this.ImagePath = ImagePath;
        }
    }
}