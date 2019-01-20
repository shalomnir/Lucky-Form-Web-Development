using LuckyForm.DAL;
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
        // GET: Home
        public ActionResult Index()
        {
            return View(formDB.GetAllForms());
        }
    }
}