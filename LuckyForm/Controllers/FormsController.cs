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
        LotteryDB lotteryDB = new LotteryDB();
        OrderDetailsDB orderDetailsDB = new OrderDetailsDB();
        UserDB userDB = new UserDB();
        TransactionDB tranDB = new TransactionDB();
        CalculatePrices calculatePrices = new CalculatePrices();
        // GET: Forms

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetViewByType(string formID)
        {
            Form form = formDB.GetFormById(formID);
            ViewBag.isView = false;
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
            string orderID = orderDB.GetOrderIdByUserID(userID);
            string formID = Session["formID"].ToString();
            string bets = FormProtocolHandler.CreateProtocolString(numbers, int.Parse(reg_numbers), int.Parse(strong_numbers));
            double price = calculatePrices.GetLottoPrice(bets, formID);
            price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            if (orderID == "-1" || orderDB.GetOrderById(orderID).Paid)
                tranDB.ExecuteTransactionAddOrder(lotteryDB.GetClosestNextLotteryByTypeID("1"), formID , userID, false, price, bets);
            else
                orderDetailsDB.AddOrderDetails(orderID, formID, lotteryDB.GetClosestNextLotteryByTypeID("1"), bets, price);

            return RedirectToAction("Cart", "Order");
        }
        public ActionResult Submit777Form(string[] numbers, string reg_numbers)
        {
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            string orderID = orderDB.GetOrderIdByUserID(userID);
            string formID = Session["formID"].ToString();
            string bets = FormProtocolHandler.CreateProtocolString(numbers, int.Parse(reg_numbers));
            double price = calculatePrices.GetLottoPrice(bets, formID);
            price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            if (orderID == "-1" || orderDB.GetOrderById(orderID).Paid)
                tranDB.ExecuteTransactionAddOrder(lotteryDB.GetClosestNextLotteryByTypeID("3"), formID, userID, false, price, bets);
            else
                orderDetailsDB.AddOrderDetails(orderID, formID, lotteryDB.GetClosestNextLotteryByTypeID("3"), bets, price);

            return RedirectToAction("Cart", "Order");
        }
        public ActionResult SubmitChanceForm(string[] cards,string first_row, string second_row, string third_row, string fourth_row)
        {
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            string orderID = orderDB.GetOrderIdByUserID(userID);
            string formID = Session["formID"].ToString();
            int[] counter = { int.Parse(first_row), int.Parse(second_row), int.Parse(third_row), int.Parse(fourth_row) };
            string bets = FormProtocolHandler.CreateChanceProtocolString(cards, counter);
            double price = calculatePrices.GetLottoPrice(bets, formID);
            price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            if (orderID == "-1" || orderDB.GetOrderById(orderID).Paid)
                tranDB.ExecuteTransactionAddOrder(lotteryDB.GetClosestNextLotteryByTypeID("2"), formID, userID, false, price, bets);
            else
                orderDetailsDB.AddOrderDetails(orderID, formID, lotteryDB.GetClosestNextLotteryByTypeID("2"), bets, price);
       
            return RedirectToAction("Cart", "Order");
        }
        public ActionResult Submit123Form(string[] numbers)
        {
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            string orderID = orderDB.GetOrderIdByUserID(userID);
            string formID = Session["formID"].ToString();
            string bets = FormProtocolHandler.CreateProtocolString(numbers, 3);
            double price = calculatePrices.GetLottoPrice(bets, formID);
            price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            if (orderID == "-1" || orderDB.GetOrderById(orderID).Paid)
                tranDB.ExecuteTransactionAddOrder(lotteryDB.GetClosestNextLotteryByTypeID("4"), formID, userID, false, price, bets);
            else
                orderDetailsDB.AddOrderDetails(orderID, formID, lotteryDB.GetClosestNextLotteryByTypeID("4"), bets, price);

            return RedirectToAction("Cart", "Order");
        }


    }
}