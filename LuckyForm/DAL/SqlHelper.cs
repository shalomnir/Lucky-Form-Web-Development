using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class SqlHelper
    {
        OleDbConnection con; // 
        OleDbCommand com; //
        OleDbDataReader reader;


        
        public SqlHelper()
        {
            this.con = new OleDbConnection();
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\Lucky-Form-Web-Development\LuckyForm\App_Data\DatabaseLotto.accdb;Persist Security Info=True";
            this.com = new OleDbCommand();
            this.com.Connection = this.con;

        }
        public SqlHelper(string path)
        {
            this.con = new OleDbConnection();
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Persist Security Info=True";
            this.com = new OleDbCommand();
            this.com.Connection = this.con;

        }

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            this.com.CommandText = sql;
            try
            {
                this.con.Open();
                this.reader = this.com.ExecuteReader();
                dt.Load(this.reader);
            }
            catch (Exception ex)
            {
                string estring = ex.Message;
                return null;
            }
            finally
            {
                this.con.Close();
            }
            return dt;
        }

    }
}