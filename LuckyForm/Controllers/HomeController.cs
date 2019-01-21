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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetFormsInType(string Type)
        {
            return PartialView("Lotteries",formDB.GetAllForms(Type));
        }
    }
    
}