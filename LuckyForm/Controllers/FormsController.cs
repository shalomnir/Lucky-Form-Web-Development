using LuckyForm.DAL;
using LuckyForm.Models;
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
        OrderDB orderDB = new OrderDB();
        UserDB userDB = new UserDB();
        // GET: Forms
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetViewByType(string formID)
        {
            Form form = formDB.GetFormById(formID);
            string type = form.Type;
            if (type == "1" || type == "3")
                return PartialView("LottoAnd777", form);
            else if (type == "2")
            {
                ViewBag.PlayCards = playCardDB.GetAllPlayCards();
                return PartialView("Chance", form);
            }
            else
                return PartialView("_123", form);

        }

        public ActionResult SubmitLottoForm(string[] number)
        {

            //orderDB.CreateNewOrder(DateTime.Now.ToShortDateString, "1", userDB.GetUserIdByEmail(Session["user"].l), false, 12);
            return null;
        }
        public ActionResult Submit777Form(string[] number)
        {
            return null;
        }
        public ActionResult SubmitChanceForm(string[] selected_cards)
        {
            return null;
        }
        public ActionResult Submit123Form(string[] number)
        {
            return null;
        }


    }
}