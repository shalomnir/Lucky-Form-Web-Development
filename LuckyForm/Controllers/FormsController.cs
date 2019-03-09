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
                return PartialView("Chance", formDB.GetFormById(formID));
            else
                return PartialView("_123", formDB.GetFormById(formID));

        }
        [HttpPost]
        public ActionResult SubmitForm(string[] number)
        {
            return null;
        }

    }
}