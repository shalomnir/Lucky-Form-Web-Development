using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyForm.BLL
{  
    public class WinTest
    {
        OrderDB orderDB = new OrderDB();
        OrderDetailsDB orderDetailsDB = new OrderDetailsDB();
        public void ItarateOrderDetails(string results, string type)
        {
           
            List<Order> orders = orderDB.GetAllOrders();
            foreach(Order order in orders)
            {
                foreach(OrderDetails orderDetails in order.Orders)
                {
                    if(orderDetails.Form.Type == type)
                    {
                        orderDetailsDB.UpdateWinningStatus(CompareBetsToResult(type, orderDetails.Form.ID, orderDetails.Bets, results), orderDetails.ID);
                    }
                   
                }
            }
        }
        public bool CompareBetsToResult(string type, string formID, string bets, string results)
        {
            if (type == "1")
            {
               
            }
            else if (type == "2")
            {

            }
            else if (type == "3")
            {

            }
            else if (type == "4")
            {

            }
            switch (formID)
            {
                case "1":
                    Console.WriteLine("Case 1");
                    break;
                case "2":
                    Console.WriteLine("Case 2");
                    break;
                case "3":
                    Console.WriteLine("Case 2");
                    break;
                case "4":
                    Console.WriteLine("Case 2");
                    break;
                case "5":
                    Console.WriteLine("Case 2");
                    break;
                case "6":
                    Console.WriteLine("Case 2");
                    break;
                case "7":
                    Console.WriteLine("Case 2");
                    break;
                case "8":
                    Console.WriteLine("Case 2");
                    break;
                case "9":
                    Console.WriteLine("Case 2");
                    break;
                case "10":
                    Console.WriteLine("Case 2");
                    break;
                case "11":
                    Console.WriteLine("Case 2");
                    break;
                case "12":
                    Console.WriteLine("Case 2");
                    break;                
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            return true;
        }
    }
}