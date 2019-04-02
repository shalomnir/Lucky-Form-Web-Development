using LuckyForm.BLL;
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
        TransactionDB tranDB = new TransactionDB();
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
            Session["formID"] = formID;
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

        public ActionResult SubmitLottoForm(string[] numbers, string reg_numbers, string strong_numbers)
        {
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            tranDB.ExecuteTransactionAddOrder("1", Session["formID"].ToString(), userID,
                false, CalculatePrices.GetLottoPrice(Session["formID"].ToString()),
                FormProtocolHandler.CreateProtocolString(numbers, int.Parse(reg_numbers),
                int.Parse(strong_numbers)));
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