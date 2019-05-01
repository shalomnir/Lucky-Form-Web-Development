using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class PriceListDB
    {
        DataTable dt;
        SqlHelper sqlHelper;
        
        public PriceListDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public PriceListDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public double GetPriceByFormId(string id)
        {
            string sql = @"SELECT PriceListTablePrice FROM PriceList WHERE Formid=" + id ;
            this.dt = this.sqlHelper.GetData(sql);
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                return (double)dt.Rows[0][0];
            }
            return -1;
        }
    }
}
