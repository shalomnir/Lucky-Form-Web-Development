using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class User : SessionUser
    {
        public string ID { get; set; }       
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        
        
        public User()
        {

        }
        public User(string gender, string firstName, string lastName, string email, string BirthDate, string password, string phoneNumber, string Permission) :base(firstName, lastName, email, Permission)
        {           
            this.PhoneNumber = phoneNumber;
            this.Sex = gender;
            this.BirthDate = BirthDate;
            this.Password = password;   
        }
            
    }   
}