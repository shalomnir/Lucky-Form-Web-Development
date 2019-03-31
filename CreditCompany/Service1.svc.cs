using CreditCompany.DAL;
using CreditCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreditCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DealDB dealDB = new DealDB();
        CardDB cardDB = new CardDB();  
        public bool GetDealVerification(CreditCard card, double amount, int payments)
        {
            double frame = cardDB.GetCardFrame(card);
            if(frame == -1)
                return false;
            return true;//TODO

        }
        public List<Deal> GetDealsReport(DateTime start, DateTime end)
        {
            return dealDB.GetDealsByTimeRange(start, end);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
