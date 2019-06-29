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
        public ActionResult GetLotteryByType(string Type)
        {
            return PartialView(lotteryDB.GetLotteriesByTypeID((int.Parse(Type) + 1).ToString()));
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
        public ActionResult UpdateLotteries()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddLotteryInType(string Type)
        {
            ViewBag.lotteryType = Type;
            return View();
        }
        [HttpPost]
        public ActionResult AddLottery(string date, string type)
        {
            lotteryDB.AddLotteryInType((int.Parse(type) + 1).ToString(), DateTime.Parse(DateTime.Parse(date).ToString("MM-dd-yyyy")));
            return View("~/Views/Home/UpdateLotteries.cshtml");
        }
        [HttpGet]
        public ActionResult InsertBets(string lotteryId)
        {
            ViewBag.lotteryId = lotteryId;
            return View();
        }
        [HttpPost]
         public ActionResult InsertBetsToLottery(string lotteryId, string bets)
        {
            try
            {
                winTest.ItarateOrderDetails(bets, lotteryDB.GetLotteryById(lotteryId).TypeID);
            }
            catch (Exception e)
            {
                ViewBag.error = "Incorrect format or content. Note the type of lottery!";
                return InsertBets(lotteryId);
            }
            lotteryDB.UpdateResults(bets, lotteryId);
            return View("~/Views/Home/UpdateLotteries.cshtml");
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

            Deal[] deals = creditClient.GetDealsReport(DateTime.Parse(DateTime.Parse(start).ToString("MM-dd-yyyy")), DateTime.Parse(DateTime.Parse(end).ToString("MM-dd-yyyy")), "1");
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