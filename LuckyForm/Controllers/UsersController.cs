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
            DateTime BirthDate = new DateTime(int.Parse(select_year), int.Parse(select_month), int.Parse(select_day));
            User user = new User(gender, first_name, last_name, email, BirthDate.ToShortDateString(), password, mobile_number);
            System.Threading.Thread.Sleep(5000);
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
            
            System.Threading.Thread.Sleep(5000);
            
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
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}