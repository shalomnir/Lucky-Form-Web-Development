using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class OrderDB
    {
        SqlHelper sqlHelper;

        public OrderDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public bool AddOrder(string lotteryID, string formID, string userID, bool paid, double sum, string bets)
        {        
            this.sqlHelper.ToCloseConnection = false; //In the transaction, the connection not need to be closed
            try
            {
                // Start a transaction with the database
                //this.sqlHelper.OpenTransaction();
               
                //Load the insert statement into the string variable, with all of the passed info
                string date = DateTime.Now.ToShortDateString();
                string strSQL = @"INSERT INTO Orders(OrderDate, LotteryID, UserID, OrderPaid, OrderSum) 
                           VALUES('" + date + "','" + lotteryID + "'," + userID + "," + paid + "," + sum + ");";
                sqlHelper.UpdateData(strSQL);

                strSQL = @"SELECT MAX(OrdersID) FROM Orders";
                string orderId = this.sqlHelper.GetValue(strSQL).ToString();

                strSQL = @"INSERT INTO Data(DataBets) VALUES('" + bets + "');";
                sqlHelper.UpdateData(strSQL);

                strSQL = @"SELECT MAX(DataID) FROM Data";
                string DataId = this.sqlHelper.GetValue(strSQL).ToString();

                strSQL = "INSERT INTO OrderDetails(OrderID, FormID, DataID)" +
                         "VALUES('" + orderId + "','" + formID + "'," + DataId + "')";
                sqlHelper.UpdateData(strSQL);

                //this.sqlHelper.CommitTransaction();//End the Transaction


                return true;
            }
            catch (Exception ex)
            {
                //this.sqlHelper.RollbackTransaction(); 
                return false;
            }
            finally
            {
                //this.sqlHelper.CloseConnection();
            }
        }
      
    }
}