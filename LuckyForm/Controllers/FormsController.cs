using LuckyForm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyForm.Controllers
{
    public class FormsController : Controller
    {
        FormDB formDB = new FormDB();
        PlayCardDB playCardDB = new PlayCardDB();
        // GET: Forms
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetViewByType(string Type, string formID)
        {
            if (Type == "1" || Type == "3")
                return PartialView("LottoAnd777", formDB.GetFormById(formID));
            else if (Type == "2")
            {
                ViewBag.PlayCards = playCardDB.GetAllPlayCards();
                return PartialView("Chance", formDB.GetFormById(formID));
            }
            else
                return PartialView("_123", formDB.GetFormById(formID));

        }
        [HttpPost]
        public ActionResult SubmitLottoForm(string[] number)
        {
            return null;
        }
        public ActionResult Submit777Form(string[] number)
        {
            return null;
        }
        public ActionResult SubmitChanceForm(string[] number)
        {
            return null;
        }
        public ActionResult Submit123Form(string[] number)
        {
            return null;
        }


    }
}