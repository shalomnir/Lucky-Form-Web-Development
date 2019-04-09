using LuckyForm.DAL;
using LuckyForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyForm.Controllers
{
    public class OrderController : Controller
    {
        UserDB userDB = new UserDB();
        OrderDB orderDB = new OrderDB();
        OrderDetailsDB orderDetailsDB = new OrderDetailsDB();
        [HttpGet]
        public ActionResult Cart()
        {
            string userID = userDB.GetUserIdByEmail((Session["user"] as SessionUser).Email);
            ViewBag.Sum = orderDetailsDB.GetOrderSumById(orderDB.GetOrderIdByUserID(userID));
            ViewBag.ProductsCount = orderDetailsDB.CountOrdersByID(orderDB.GetOrderIdByUserID(userID));
            return View(orderDB.GetOrderByUserID(userDB.GetUserIdByEmail((Session["User"] as SessionUser).Email)));
        }
        [HttpGet]
        public ActionResult RemoveFormByID(string id)
        {
            orderDetailsDB.RemoveFormByID(id);
            return Redirect(Request.UrlReferrer.ToString());//Refreah Page
        }
    }
}