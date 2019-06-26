using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyForm.BLL;
using LuckyForm.CreditCompanyReference;
namespace LuckyForm.Controllers
{
    public class HomeController : Controller
    {
        FormDB formDB = new FormDB();
        LotteryDB lotteryDB = new LotteryDB();
        WinTest winTest = new WinTest();
        // GET: Home
        public ActionResult MainPageLotteries()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetFormsInType(string Type)
        {
            if (Type == "0")
                return PartialView("Index");
            return PartialView("Lotteries",formDB.GetAllForms(Type));
        }
        [HttpGet]
        public ActionResult AddForm(string formID)
        {
            Form form = formDB.GetFormById(formID);
            string type = form.Type;
            formDB.ShowFormByID(formID, true);
            return GetFormsInType(type);

        }
        [HttpGet]
        public ActionResult HideForm(string formID)
        {
            Form form = formDB.GetFormById(formID);
            string type = form.Type;
            formDB.ShowFormByID(formID, false);
            return GetFormsInType(type);

        }
        
        [HttpGet]
        public ActionResult ContactUs()
        {
            CountryDB countryDB = new CountryDB();
            return View(countryDB.GetAllCountries());
        }
        [HttpGet]
        public ActionResult UpdateBetsResults()
        {         
            return View();
        }
        [HttpGet]
        public ActionResult GetDeals()
        {
            return View("GetDealsByTimeRange");
        }
        [HttpPost]
        public ActionResult GetDealsByTimeRange(string start, string end)
        {            
            CreditCompanyReference.CreditClient creditClient = new CreditClient();
            List<Deal> deals = creditClient.GetDealsReport(DateTime.Parse(start), DateTime.Parse(end), "1").OfType<Deal>().ToList();            
            return View(deals);
        }
        [HttpPost]
        public ActionResult UpdateResults(string lottery_type, string result)
        {
            lotteryDB.UpdateResults(result, lottery_type);
            try
            {
                winTest.ItarateOrderDetails(result, lottery_type);
            }
            catch(Exception e)
            {
                ViewBag.error = "Incorrect format or content. Note the type of lottery!";
                return View("UpdateBetsResults");
            }
            return MainPageView();
        }
        
        public ActionResult MainPageView()
        {
            
            if(TempData["isUserAuthenticated"] != null)
                ViewBag.isUserAuthenticated = bool.Parse(TempData["isUserAuthenticated"].ToString());
            if(TempData["isUserExist"] != null)
                ViewBag.isUserExist = bool.Parse(TempData["isUserExist"].ToString());
            if(TempData["isOverEigtheen"] != null)
                ViewBag.isOverEigtheen = bool.Parse(TempData["isOverEigtheen"].ToString());
            return View("MainPageLotteries");
        }
    }
    
}