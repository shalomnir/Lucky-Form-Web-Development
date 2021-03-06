﻿using LuckyForm.Models;
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
        public UserDB()
        {
            this.sqlHelper = new SqlHelper();
        }
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
                    dt.Rows[0]["UsersPhoneNumber"].ToString(),
                    dt.Rows[0]["PermissionType"].ToString());
                return user;
            }
            return null;
        }
        public User GetUserById(string ID)
        {
            string sql = @"SELECT * FROM Users WHERE UsersID=" + ID + "";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                User user = new User(                    
                    dt.Rows[0]["UsersSex"].ToString(),
                    dt.Rows[0]["UsersFirstName"].ToString(),
                    dt.Rows[0]["UsersLastName"].ToString(),
                    dt.Rows[0]["UsersEmail"].ToString(),
                    dt.Rows[0]["UsersBirthDate"].ToString(),
                    dt.Rows[0]["UsersPassword"].ToString(),
                    dt.Rows[0]["UsersPhoneNumber"].ToString(),
                    dt.Rows[0]["PermissionType"].ToString(),
                    dt.Rows[0]["UsersID"].ToString());
                return user;
            }
            return null;
        }
        public string GetUserIdByEmail(string email)
        {
            string sql = @"SELECT usersID FROM Users WHERE UsersEmail='" + email + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();                
            }
            return null;
        }
        public bool IsUserExistByEmail(string email)
        {
            string sql = @"SELECT * FROM Users WHERE UsersEmail='" + email + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            return false;
        }
        public void SignUser(User user)
        {
            string sql = @"INSERT INTO Users (UsersFirstName, UsersLastName, UsersEmail, UsersPhoneNumber, UsersSex, UsersPassword, UsersBirthDate, PermissionType) 
                            VALUES('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.PhoneNumber + "','"
                            + user.Sex + "','" + user.Password + "','" + user.BirthDate + "', '" + user.PermissionType +"');";
            this.sqlHelper.UpdateData(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UserAuthentication(string email, string password)
        {
            string sql = @"SELECT * FROM Users WHERE UsersEmail = '" + email + "' AND UsersPassword='"+ password + "'";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
                return true;
            return false;

        }
    }
}