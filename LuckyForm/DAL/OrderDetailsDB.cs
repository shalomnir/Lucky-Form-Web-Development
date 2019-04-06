﻿using LuckyForm.Models;
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
                    orderDetails.Price = int.Parse(dr["OrderDetailsPrice"].ToString());//TO FIX DOUBLE
                    orderDetails.Date = DateTime.Parse(dr["orderDetailsDate"].ToString());

                    allDetails.Add(orderDetails);
                }
                return allDetails;
            }
            return null;
        }
        public double GetOrderSumById(string id)
        {
            string sql = @"SELECT SUM(OrderDetailsPrice) AS TotalItemsOrdered FROM OrderDetails WHERE OrderID=" + id;
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());//FIX
            }
            return -1;
        }
    }
}