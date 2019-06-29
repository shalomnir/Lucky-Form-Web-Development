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
            int tablesCount = bets.Split('#').Length - 1;
            double pricePerTable = priceListDB.GetPriceByFormId(formID);
            if (formID == "1" || formID == "2")
            {
                return pricePerTable*tablesCount;
            }
            else if (formID == "3" || formID == "4")
            {
                return FormProtocolHandler.nCk(FormProtocolHandler.NumOfBets(bets) - 1, 6) * pricePerTable;
                
            }    
            else if (formID == "5" || formID == "6")
            {
                return FormProtocolHandler.nCk(7, 6) * pricePerTable * FormProtocolHandler.NumOfStrongBets(bets);
            }           
            else if (formID == "7")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "8")
            {
                return FormProtocolHandler.nCk(FormProtocolHandler.NumOfBets(bets), 7) * pricePerTable;
            }
            else if (formID == "9")
            {
                return pricePerTable * tablesCount;
            }
            else if (formID == "10" || formID == "11")
            {
                return pricePerTable;
            }
            
            else if (formID == "12")
            {
                int seq = 1;
                foreach(string row in FormProtocolHandler.SplitTabels(bets))
                {
                    if(row.Length > 0)
                        seq *= row.Split(',').Length - 1;
                }
                return pricePerTable * seq;
            }
            
            return 14.7;

        }

    }
}