using CreditCompany.Models;
using LuckyForm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreditCompany.DAL
{
    public class DealDB
    {
        DataTable dt;
        SqlHelper sqlHelper;

        public DealDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public DealDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }

        public List<Deal> GetDealsByTimeRange(DateTime start, DateTime end)
        {
            string sql = @"SELECT * FROM Deals WHERE DealsDate > '" + start.ToShortDateString() +
                "' AND DealsDate < '" + end.ToShortDateString() + "';";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Deal> allDeals = new List<Deal>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Deal deal = new Deal();
                    deal.ID = dr["DealsID"].ToString();
                    deal.CardID = dr["Deals"].ToString();
                    deal.Date = DateTime.Parse(dr["DealsDate"].ToString());
                    deal.Amount =(double)(dr["DealsAmount"]);
                    deal.Payments = int.Parse(dr["DealsPayments"].ToString());
                    allDeals.Add(deal);
                }
                return allDeals;
            }
            return null;
        }
    }
}