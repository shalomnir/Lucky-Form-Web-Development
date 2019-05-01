using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyForm.DAL;
namespace LuckyForm.BLL
{
    public class CalculatePrices
    {
        
        PriceListDB priceListDB = new PriceListDB();
        public double GetLottoPrice(string bets,string formID)
        {
            int tablesCount = bets.Split('#').Length;
            double pricePerTable = priceListDB.GetPriceByFormId(formID);
            if (formID == "1")
            {
                return pricePerTable*tablesCount;
            }
            else if (formID == "2")
            {
                return pricePerTable * tablesCount * 2;
            }
            else if (formID == "3")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "4")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "4")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "5")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "6")
            {
                return pricePerTable * tablesCount;
            }
            return 14.7;

        }

    }
}