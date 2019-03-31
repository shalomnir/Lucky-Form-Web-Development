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
        bool toCloseConnection;


        public void OpenTransaction()
        {

            this.con.Open();
            this.com.Transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
            this.com.Transaction.Begin();
        }
        public void CommitTransaction()
        {
            this.com.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            this.com.Transaction.Rollback();
        }


        public bool ToCloseConnection
        {
            set
            {
                this.toCloseConnection = value;
            }
        }

        public SqlHelper()
        {
            this.con = new OleDbConnection();
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\nir\Lucky-Form-Web-Development\LuckyForm\App_Data\DatabaseLotto.accdb;Persist Security Info=True";
            //this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nirsh\Desktop\Lucky-Form-Web-Development\LuckyForm\App_Data\DatabaseLotto.accdb;Persist Security Info=True";
            this.com = new OleDbCommand();           
            this.com.Connection = this.con;
            this.ToCloseConnection = true;

        }

        public SqlHelper(string path)
        {
            this.con = new OleDbConnection();
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Persist Security Info=True";
            this.com = new OleDbCommand();
            this.com.Connection = this.con;

        }

        public object GetValue(string sql)
        {

            this.com.CommandText = sql;
            try
            {
                if (this.con.State == ConnectionState.Closed)
                    this.con.Open();
                return com.ExecuteScalar();

            }
            catch (Exception ex)
            {
                string estring = ex.Message;
                return null;
            }
            finally
            {
                if (this.toCloseConnection)
                    this.con.Close();
            }

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


        public int UpdateData(string sql)
        {
            int rows = 0;
            this.com.CommandText = sql;
            try
            {
                if (this.con.State == ConnectionState.Closed)
                    this.con.Open();
                rows = this.com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string estring = e.Message;
                return -1;
            }
            finally
            {
                if (this.toCloseConnection)
                    this.con.Close();
            }
            return rows;
        }
       

        public void CloseConnection()
        {
            if (this.con.State == ConnectionState.Open)
                this.con.Close();
        }
    }
}