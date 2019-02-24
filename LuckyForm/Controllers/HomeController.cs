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
        public ActionResult SignUp(string gender, string first_name, string last_name, string email, string select_year, string select_month, string select_day, string password, string mobile_number)
        {
            
            DateTime BirthDate = new DateTime(int.Parse(select_year), int.Parse(select_month), int.Parse(select_day));
            User user = new User(gender,first_name,last_name,email,BirthDate.ToShortDateString(),password,mobile_number);
            System.Threading.Thread.Sleep(5000);
            if((DateTime.Now - BirthDate).TotalDays > 18*365)
                this.ViewBag.isOverEigtheen = true;
            else
                this.ViewBag.isOverEigtheen = false;

            if (userDB.IsUserExistByEmail(user.Email))
            {
                this.ViewBag.isUserExist = true;
                return View("MainPageLotteries");
            }
            else
            {
                this.ViewBag.isUserExist = false;
                userDB.SignUser(user);
                return Login(user.Email, user.Password);
            }
            

        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            System.Threading.Thread.Sleep(5000);
            if (!userDB.IsUserExistByEmail(email))
                ViewBag.isUserExistLogin = false;
            else if(!userDB.UserAuthentication(email, password))
                ViewBag.isUserAuthenticated = false;
            else
                Session["user"] = (SessionUser)userDB.GetUserByEmail(email);

            return new RedirectResult("~/Home/MainPageView");
        }
        public ActionResult MainPageView()
        {
            return View("MainPageLotteries");
        }
    }
    
}