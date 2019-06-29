using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckyForm.CreditCompanyReference;

namespace LuckyForm.Controllers
{
    public class OrderController : Controller
    {
        FormDB formDB = new FormDB();
        PlayCardDB playCardDB = new PlayCardDB();
        UserDB userDB = new UserDB();
        OrderDB orderDB = new OrderDB();
        LotteryDB lotteryDB = new LotteryDB();
        OrderDetailsDB orderDetailsDB = new OrderDetailsDB();
        [HttpGet]
        public ActionResult Cart()
        {
            
            if (Session["user"] == null)
                return View("~/Views/_404.cshtml");
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            ViewBag.ProductsCount = orderDetailsDB.CountOrdersByID(orderDB.GetOrderIdByUserID(userID));
            ViewBag.Sum = 0;
            if (ViewBag.ProductsCount != 0)
                ViewBag.Sum = orderDetailsDB.GetOrderSumById(orderDB.GetOrderIdByUserID(userID));
            return View(orderDB.GetOrderByUserID(userDB.GetUserIdByEmail((Session["User"] as SessionUser).Email)));
        }
        [HttpGet]
        public ActionResult RemoveFormByID(string id)
        {
            orderDetailsDB.RemoveFormByID(id);
            return Redirect(Request.UrlReferrer.ToString());//Refreah Page
        }

        [HttpGet]
        public ActionResult ViewFormByID(string detId, string formId)
        {
            Form form = formDB.GetFormById(formId);
            ViewBag.isView = true;
            ViewBag.detId = detId;
            string type = form.Type;
            Session["formID"] = formId;
            if (type == "1" || type == "3")
                return PartialView("~/Views/Forms/LottoAnd777.cshtml", form);
            else if (type == "2")
            {
                ViewBag.PlayCards = playCardDB.GetAllPlayCards();
                return PartialView("~/Views/Forms/Chance.cshtml", form);
            }
            else
                return PartialView("~/Views/Forms/_123.cshtml", form);
        }
        [HttpGet]
        public string GetBetsById(string detId)
        {
            return orderDetailsDB.GetDetailsBetsById(detId);
        }
        [HttpGet]
        public ActionResult GetAllPaidOrdersOffUser()
        {
            Lottery[] lotterys= new Lottery[4];
            for(int i = 0;i<4;i++)
            {
                lotterys[i] = lotteryDB.GetLotteryById(lotteryDB.GetClosestLotteryByTypeID((i + 1).ToString()));
            }
            ViewBag.lotterys = lotterys;
            if (Session["user"] == null)
                return View("~/Views/_404.cshtml");
            return View(orderDB.GetAllPaidOrdersOffUser(userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email)));
        }
        [HttpPost]
        public ActionResult Pay(string name, string card_number, string exp_mm, string exp_yy, string sec_code, string pos_code, string price, string payments)
        {
            
            CreditCompanyReference.CreditCard card = new CreditCard();
            card.ID = card_number;
            card.ExpiryDate = new DateTime(int.Parse(exp_yy), int.Parse(exp_mm), 1);
            card.CVV = sec_code;
            CreditCompanyReference.CreditClient creditClient = new CreditClient();
            if (creditClient.GetDealVerification(card, double.Parse(price), int.Parse(payments), "1"))
            {
                string orderId = orderDB.GetOrderIdByUserID(userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email));
                orderDB.MarkAsPaid(orderId);
                Invoice invoice = new Invoice();
                invoice.Name = name;
                invoice.Payments = payments;
                invoice.Products = orderDetailsDB.GetDetailsByOrderId(orderId);
                invoice.Postcode = pos_code;
                return View(invoice);
            }
            else
            {
                ViewBag.CreditSuccess = false;
                Cart();
                return View("~/Views/Order/Cart.cshtml");
            }
            
        }
    }
}