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
        public double GetDealsSum(string cardId)
        {
            string sql = @"SELECT SUM(DealsAmount)
                            FROM Deals
                            WHERE cardID = '" + cardId + "'" +
                            "AND MONTH(DealsDate) = " + DateTime.Now.Month + 
                            "AND YEAR(DealsDate) = " + DateTime.Now.Year;
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                return double.Parse(dt.Rows[0][0].ToString());
            }
            return -999999.99;
        }
        public bool AddDeals(string cardId, double amount, int payments, string businessID)
        {
            amount = -amount;
            for(int i = 0; i < payments; i++)
            {
                string sql = @"INSERT INTO Deals(CardID, DealsDate, DealsAmount, BusinessID) VALUES(" + cardId + ", #" +
                (DateTime.Now.AddMonths(i)).ToShortDateString() + "#, " + amount / payments + ", " + businessID + ");";
                if (this.sqlHelper.UpdateData(sql) == -1)
                    return false;
            }
            return true;
        }
        public List<Deal> GetDealsByTimeRange(DateTime start, DateTime end, string businessID)
        {
            string sql = @"SELECT * FROM Deals WHERE BusinessID = " + businessID + " AND DealsDate >= #" + start.ToShortDateString() +
                "# AND DealsDate <= #" + end.ToShortDateString() + "#;";
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                List<Deal> allDeals = new List<Deal>();
                foreach (DataRow dr in this.dt.Rows)
                {
                    Deal deal = new Deal();
                    deal.ID = dr["DealsID"].ToString();
                    deal.CardID = dr["CardID"].ToString();
                    deal.Date = DateTime.Parse(dr["DealsDate"].ToString());
                    deal.Amount =double.Parse(dr["DealsAmount"].ToString());                   
                    allDeals.Add(deal);
                }
                return allDeals;
            }
            return null;
        }
    }
}