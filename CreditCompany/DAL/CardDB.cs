using CreditCompany.Models;
using LuckyForm.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreditCompany.DAL
{
    public class CardDB
    {
        DataTable dt;
        SqlHelper sqlHelper;

        public CardDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public CardDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public double GetCardFrame(CreditCard card)
        {
            string sql = @"SELECT CardFrame WHERE CardID = '" + card.ID + "' AND CardCVV = '"
                          + card.CVV + "' AND CardExpiryDate ='" + card.ExpiryDate + "';";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return double.Parse(dt.Rows[0][0].ToString());
            }
            return -1;
        }
    }
}