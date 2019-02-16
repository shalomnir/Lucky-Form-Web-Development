using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class UserDB
    {
        DataTable dt;
        SqlHelper sqlHelper;
        public User GetUserByEmail(string email)
        {
            string sql = @"SELECT * FROM Users WHERE UsersEmail='" + email + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if(dt != null && dt.Rows.Count > 0)
            {
                User user = new User(
                    dt.Rows[0]["UsersSex"].ToString(),
                    dt.Rows[0]["UsersFirstName"].ToString(),
                    dt.Rows[0]["UsersLastName"].ToString(),
                    dt.Rows[0]["UsersEmail"].ToString(),
                    dt.Rows[0]["UsersBirthDate"].ToString(),
                    dt.Rows[0]["UsersPassword"].ToString(),
                    dt.Rows[0]["UsersPhoneNumber"].ToString());
              
                return user;
            }
            return null;
        }
        public bool IsUserExist(User user)
        {
            string sql = @"SELECT * FROM Users WHERE UsersEmail='" + user.Email + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            return false;
        }
        public void SignUser(User user)
        {
            string sql = @"INSERT INTO Users (UsersFirstName, UsersLastName, UsersEmail, UsersPhoneNumber, UsersSex, UsersBirthDate) 
                            VALUES('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.PhoneNumber + "','"
                            + user.Sex + "','" + user.BirthDate + "');";
            this.sqlHelper.GetData(sql);
        }
    }
}