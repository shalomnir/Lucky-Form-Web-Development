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
        UserDB userDB = new UserDB();
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
        [HttpPost]
        public bool SignUp(string gender, string first_name, string last_name, string email, string select_year, string select_month, string select_day, string password, string mobile_number)
        {
            DateTime BirthDate = new DateTime(int.Parse(select_year), int.Parse(select_month), int.Parse(select_day));
            User user = new User(gender,first_name,last_name,email,BirthDate.ToString(),password,mobile_number);

            if (userDB.IsUserExist(user))
                return false;
            else
            {
                userDB.SignUser(user);
                return true;
            }
               

        }
    }
    
}