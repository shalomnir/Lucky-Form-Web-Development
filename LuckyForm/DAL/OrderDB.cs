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
        public OrderDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public List<OrderDB> GetAllOrders()
        {
            string sql = @"SELECT * FROM Countries";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<OrderDB> allOrders = new List<OrderDB>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Order order = new Order();
                    order.ID = dr["CountriesID"].ToString();
                    order.Date = DateTime.Parse(dr["CountriesName"].ToString());
                    order.Lottery = new Lottery(dr["LotterysID"].ToString(), dr["LotterysResult"].ToString()
                        dr["CountriesTel"].ToString(), dr["CountriesTel"].ToString());
                    order.Fax = dr["CountriesFax"].ToString();
                    order.Img = dr["CountriesImg"].ToString();

                    allOrders.Add(order);
                }
                return allOrders;
            }
            return null;
        }
       
       
      
    }
}