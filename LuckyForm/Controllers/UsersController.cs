using LuckyForm.Models;
using LuckyForm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyForm.Controllers
{
    public class UsersController : Controller
    {

        UserDB userDB = new UserDB();
        [HttpPost]
        public ActionResult SignUp(string gender, string first_name, string last_name, string email, string select_year, string select_month, string select_day, string password, string mobile_number)
        {
            
           
            first_name = first_name.First().ToString().ToUpper() + first_name.Substring(1);
            last_name = last_name.First().ToString().ToUpper() + last_name.Substring(1);
            DateTime BirthDate = DesignDate(select_year, select_month, select_day);
            User user = new User(gender, first_name, last_name, email, BirthDate.ToShortDateString(), password, mobile_number, "1");
            //System.Threading.Thread.Sleep(3000);
            if ((DateTime.Now - BirthDate).TotalDays > 18 * 365)
                TempData["isOverEigtheen"] = "true";
            else
                TempData["isOverEigtheen"] = "false";

            if (userDB.IsUserExistByEmail(user.Email))
            {
                TempData["isUserExist"] = "true";                
                return RedirectToAction("../Home/MainPageView");
            }
            else
            {
                userDB.SignUser(user);
                return Login(user.Email, user.Password);
            }
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            
            System.Threading.Thread.Sleep(3000);
            
            if (!userDB.UserAuthentication(email, password))
                TempData["isUserAuthenticated"] = "false";
            else
                Session["user"] = (SessionUser)userDB.GetUserByEmail(email);
                       
            return RedirectToAction("../Home/MainPageView");
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("../Home/MainPageView");
        }
        private DateTime DesignDate(string year, string month, string day)
        {
        
            string shortMonth = "4 6 9 11";
            if (shortMonth.Contains(month) && int.Parse(day) > 30)
                day = "30";
            else if (month == "2" && int.Parse(day) > 28)
                day = "28";
            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }
        // GET: Users
        public ActionResult PersonalArea(string email)
        {
            SessionUser sessionUser = Session["user"] as SessionUser;
            return View(userDB.GetUserByEmail(sessionUser.Email));
        }
    }
}