﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.Models
{
    public class SessionUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PermissionType { get; set; }
        
        public SessionUser() { }
        public SessionUser(string firstName, string lastName, string email, string PermissionType)
        {
           
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PermissionType = PermissionType;
        }
    }
    
}