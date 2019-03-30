using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class OrderDB
    {
        public void CreateNewOrder(DateTime date, string lotteryID, string userID, bool paid, double sum)
        {
            string sql = @"INSERT INTO Orders(OrderDate, LotteryID, UserID, OrderPaid, OrderSum) 
                           VALUES('" + date + "','" + lotteryID + "','" + userID + "','" + paid + "','" + sum + "');";
        }
    }
}