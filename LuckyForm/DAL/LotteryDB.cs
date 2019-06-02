using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LuckyForm.DAL
{
    public class LotteryDB
    {
        DataTable dt;
        SqlHelper sqlHelper;

        public LotteryDB()
        {
            this.sqlHelper = new SqlHelper();
        }

        public LotteryDB(string path)
        {
            this.sqlHelper = new SqlHelper(path);
        }
        public Lottery GetLotteryById(string id)
        {
            string sql = @"SELECT Lotterys.LotterysID, Lotterys.LotterysDate, Lotterys.LotterysBets, Type.TypeName
                        FROM Type INNER JOIN Lotterys ON Type.TypeID = Lotterys.TypeID
                        WHERE (((Lotterys.LotterysID)=" + id + "));";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                Lottery lottery = new Lottery();
                lottery.ID = dt.Rows[0]["LotterysID"].ToString();
                lottery.Name = dt.Rows[0]["TypeName"].ToString();
                lottery.Date =DateTime.Parse(dt.Rows[0]["LotterysDate"].ToString());
                lottery.Bets = dt.Rows[0]["LotterysBets"].ToString();
                return lottery;
            }
            return null;
        }
        public String GetClosestLotteryByTypeID(string typeID)
        {
            string sql = @"SELECT TOP 1 * FROM Lotterys WHERE LotterysDate < " + DateTime.Now.ToShortDateString() + " AND " +
                "TypeID='" + typeID + "'ORDER BY LotterysDate DESC";
            this.dt = this.sqlHelper.GetData(sql);
            if (dt != null && dt.Rows.Count > 0)
            {              
                return dt.Rows[0]["LotterysID"].ToString();              
            }
            return null;
        }
        public void UpdateResults(string bets, string typeID)
        {
            string sql = @"UPDATE Lotterys
                            SET LotterysBets = '" + bets +
                            "' WHERE LotterysID = " + GetClosestLotteryByTypeID(typeID) + ";";
            this.sqlHelper.UpdateData(sql);
        }
    }
}