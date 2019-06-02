using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class OrderDB
    {
        SqlHelper sqlHelper;
        DataTable dt;
        LotteryDB lotteryDB;
        UserDB userDB;
        OrderDetailsDB orderDetailsDB;
        public OrderDB()
        {
            orderDetailsDB = new OrderDetailsDB();
            lotteryDB = new LotteryDB();
            userDB = new UserDB();
            this.sqlHelper = new SqlHelper();
        }
        public string GetOrderIdByUserID(string ID)
        {
            string sql = @"SELECT * FROM Orders WHERE UserID=" + ID;
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                return dt.Rows[0]["OrderID"].ToString();
            }
            return "-1";
        }
        public List<Order> GetAllOrders()
        {
            string sql = @"SELECT * FROM Orders";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Order> allOrders = new List<Order>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Order order = new Order();
                    order.ID = dt.Rows[0]["OrderID"].ToString();
                    order.Orders = orderDetailsDB.GetDetailsByOrderId(order.ID);
                    order.User = userDB.GetUserById(dt.Rows[0]["UserID"].ToString());
                    order.Paid = (bool)dt.Rows[0]["OrderPaid"];

                    allOrders.Add(order);
                }
                return allOrders;
            }
            return null;
        }
    
        public Order GetOrderByUserID(string ID)
        {
            string sql = @"SELECT Orders.OrderID, Orders.OrderPaid, Lotterys.LotterysID, OrderDetails.FormID, Orders.UserID
                            FROM Users INNER JOIN (Orders INNER JOIN (Lotterys INNER JOIN (Forms INNER JOIN OrderDetails ON Forms.FormsID = OrderDetails.FormID) ON Lotterys.LotterysID = OrderDetails.LotteryID) ON Orders.OrderID = OrderDetails.OrderID) ON Users.UsersID = Orders.UserID
                            WHERE (((Orders.OrderPaid)=False) AND ((Orders.UserID)=" + ID +"));";

            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {     
                Order order = new Order();
                order.ID = dt.Rows[0]["OrderID"].ToString();
                order.Orders = orderDetailsDB.GetDetailsByOrderId(order.ID);
                order.User = userDB.GetUserById(ID);
                order.Paid = (bool)dt.Rows[0]["OrderPaid"];
                //order.Sum = (int)dt.Rows[0]["OrderSum"];//FIX
                return order;
            }
            return null;
        }


    }
}
