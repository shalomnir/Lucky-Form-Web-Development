using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class OrderDetailsDB
    {
        DataTable dt;
        SqlHelper sqlHelper;
        FormDB formDB;
        LotteryDB lotteryDB;
        public OrderDetailsDB()
        {
            formDB = new FormDB();
            lotteryDB = new LotteryDB();
            this.sqlHelper = new SqlHelper();
        }

        public OrderDetailsDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public void UpdateWinningStatus(bool won, string OrderDetailsID)
        {
            string sql = @"UPDATE OrderDetails
                        SET OrderDetailsWon = " + won + "WHERE  OrderDetailsID = " + 1;//TO FIX
            this.sqlHelper.UpdateData(sql);
        }
        public void AddOrderDetails(string orderID, string formID, string lotteryID, string bets, double price)
        {
            string sql = @"INSERT INTO OrderDetails(OrderID, FormID, LotteryID, OrderDetailsBets, OrderDetailsPrice, orderDetailsDate)
                            VALUES(" + orderID + ", " + formID + ", " + lotteryID + ", '" + bets + "'," + price + ", '" + DateTime.Now.ToShortDateString() + "')";
            this.sqlHelper.UpdateData(sql);
        }
        public List<OrderDetails> GetDetailsByOrderId(string id)
        {
            string sql = @"SELECT * FROM OrderDetails WHERE OrderID = " + id;
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                List<OrderDetails> allDetails = new List<OrderDetails>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ID = dr["orderDetailsID"].ToString();
                    orderDetails.Form = formDB.GetFormById(dr["FormID"].ToString());
                    orderDetails.OrderID = dr["OrderID"].ToString();
                    orderDetails.Lottery =lotteryDB.GetLotteryById(dr["LotteryID"].ToString());
                    orderDetails.Bets = dr["OrderDetailsBets"].ToString();
                    orderDetails.Price = double.Parse(dr["OrderDetailsPrice"].ToString());//TO FIX DOUBLE
                    orderDetails.Date = DateTime.Parse(dr["orderDetailsDate"].ToString());

                    allDetails.Add(orderDetails);
                }
                return allDetails;
            }
            return null;
        }
        public double GetOrderSumById(string id)
        {
            string sql = @"SELECT SUM(OrderDetailsPrice) AS TotalItemsOrdered FROM OrderDetails 
                            WHERE OrderID=" + id;
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return double.Parse(dt.Rows[0][0].ToString());
            }
            return -1;
        }
        public double CountOrdersByID(string id)
        {
            string sql = @"SELECT OrderDetailsID FROM OrderDetails WHERE OrderID=" + id;
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            return 0;
        }
        
        public bool RemoveFormByID(string id)
        {
            string sql = @"DELETE FROM OrderDetails WHERE OrderDetailsID=" + id;
            if (this.sqlHelper.UpdateData(sql) != -1)
                return true;
            return false;
        }
        public string GetDetailsBetsById(string id)
        {
            string sql = @"SELECT OrderDetailsBets FROM OrderDetails
                            WHERE (((OrderDetails.OrderDetailsID)=" + id + "));";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return null;

        }
    }
}