using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
    }   
}