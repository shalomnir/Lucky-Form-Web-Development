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
    public class Credit : ICredit
    {
        DealDB dealDB = new DealDB();
        CardDB cardDB = new CardDB();
        public bool GetDealVerification(CreditCard card, double amount, int payments, string businessID)
        {
            double frame = cardDB.GetCardFrame(card);
            double sum = dealDB.GetDealsSum(card.ID);
            if (frame == -1 || DateTime.Compare(DateTime.Now, card.ExpiryDate) >= 0)
                return false;
            else if (frame + sum - amount / payments > 0)
            {
                return dealDB.AddDeals(card.ID, amount, payments, businessID);

            }
            return false;
        }
        public List<Deal> GetDealsReport(DateTime start, DateTime end, string businessID)
        {
            return dealDB.GetDealsByTimeRange(start, end, businessID);
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
