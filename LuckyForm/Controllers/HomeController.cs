using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyForm.Controllers
{
    public class HomeController : Controller
    {
        FormDB formDB = new FormDB();
        LotteryDB lotteryDB = new LotteryDB();
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
        [HttpPost]
        public ActionResult UpdateResults(string lottery_type, string result)
        {
            lotteryDB.UpdateResults(result, lottery_type);
            
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