using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class table
    {
        public List<string> regularNums{ get; set; }
        public List<string> strongNums { get; set; }
        public table()
        {
            this.regularNums = new List<string>();
            this.strongNums = new List<string>();
        }
    }
}