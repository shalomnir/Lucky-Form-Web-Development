using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class TransactionDB
    {
        OleDbConnection con; // 
        OleDbCommand com; //
        OleDbDataReader reader;
        public TransactionDB()
        {
            this.con = new OleDbConnection();
            //this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\nir\Lucky-Form-Web-Development\LuckyForm\App_Data\DatabaseLotto.accdb;Persist Security Info=True";
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nirsh\Desktop\Lucky-Form-Web-Development\LuckyForm\App_Data\DatabaseLotto.accdb;Persist Security Info=True";
            this.com = new OleDbCommand();
            this.com.Connection = this.con;
        }

        public TransactionDB(string path)
        {
            this.con = new OleDbConnection();
            this.con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Persist Security Info=True";
            this.com = new OleDbCommand();
            this.com.Connection = this.con;

        }
        public void ExecuteTransactionAddOrder(string lotteryID, string formID, string userID, bool paid, double sum, string bets)
        {
            using (OleDbConnection connection = this.con)
            {
                connection.Open();

                this.com = connection.CreateCommand();
                OleDbTransaction transaction;
                DataTable dt = new DataTable();
                // Start a local transaction.
                transaction = connection.BeginTransaction();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                this.com.Connection = connection;
                this.com.Transaction = transaction;

                try
                {
                    string date = DateTime.Now.ToShortDateString();
                    this.com.CommandText = @"INSERT INTO Orders(OrderDate, UserID, OrderPaid, OrderSum) 
                           VALUES('" + date + "'," + userID + "," + paid + "," + sum + ");";
                    this.com.ExecuteNonQuery();

                    this.com.CommandText = @"SELECT MAX(OrderID) FROM Orders";
                    dt.Load(this.com.ExecuteReader());
                    string orderId = dt.Rows[0][0].ToString();

                    this.com.CommandText = "INSERT INTO OrderDetails(OrderID, FormID, LotteryID, OrderDetailsBets)" +
                             "VALUES(" + orderId + "," + formID + "," + lotteryID + ",'" + bets+"')";
                    this.com.ExecuteNonQuery();                  
                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
    }
}