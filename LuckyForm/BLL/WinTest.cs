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
            List<Order> orders = orderDB.GetAllOrdersToIterate();
            foreach(Order order in orders)
            {
                //if(order.ID == "30")
                    foreach (OrderDetails orderDetails in order.Orders)
                    {
                        if (orderDetails.Form.Type == type)
                        {
                            orderDetailsDB.UpdateWinningStatus(CompareBetsToResult(type, orderDetails.Form.ID, orderDetails.Bets, results), orderDetails.ID);
                        }

                    }
            }
        }
        public bool CompareBetsToResult(string type, string formID, string bets, string results)
        {
            if (type == "1" || type == "3")
            {
                string regRes = "";
                int baseCount = 0;
                string stgRes = "";
                if (type == "1")
                {
                    baseCount = 6;
                    regRes = results.Split('*')[0];
                    stgRes = results.Split('*')[1];
                }
                else
                {
                    baseCount = 7;
                    regRes = results.Split('#')[0];
                }
                
                foreach (table t in FormProtocolHandler.ProtocolToClass(bets, type))
                {
                    foreach (string bet in FormProtocolHandler.GetCombinations(t.regularNums.ToArray(), baseCount))
                    {
                        string newBet = bet.Remove(bet.Length - 1);
                        if (type == "1")
                        {
                            if (FormProtocolHandler.areEqual(newBet.Split(','), regRes.Split(',')))
                            {
                                foreach (string num in t.strongNums)
                                {
                                    if (num == stgRes.Split(',')[0])
                                        return true;
                                }
                            }
                        }
                        else
                        {
                            if (FormProtocolHandler.isSubset(regRes.Split(','), newBet.Split(','), 17, 7))
                                return true;
                        } 
                    }
                }
                return false;
            }
            else if (type == "2")
            {
                string[] bet = FormProtocolHandler.SplitTabels(bets);
                string[] tables = results.Split('#');
                for (int i = 0; i < 4; i++)
                {
                    if (!bet[i].Split(',').Contains<string>(tables[i]))
                        return false;
                }
                return true;
            }
            else if (type == "4")
            {
                foreach (string t in FormProtocolHandler.SplitTabels(bets))
                {
                    if (FormProtocolHandler.cmpArr(t.Split(','), results.Split(','), 3))
                        return true;
                }
            }
            return false;
        }
    }
}