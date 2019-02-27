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
        
        // GET: Home
        public ActionResult MainPageLotteries()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetFormsInType(string Type)
        {
            return PartialView("Lotteries",formDB.GetAllForms(Type));
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            CountryDB countryDB = new CountryDB();
            return View(countryDB.GetAllCountries());
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