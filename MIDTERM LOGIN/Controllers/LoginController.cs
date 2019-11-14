using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIDTERM_LOGIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.UserModel model)
        {
            Database1Entities cbe = new Database1Entities();
            var s = cbe.GetCBLoginInfo(model.UserName, model.Password);

            var item = s.ToString();
            if (item == "Success")
            {

                return View("UserLandingView");
            }
            else if (item == "User Does not Exists")

            {
                ViewBag.NotValidUser = item;

            }
            else
            {
                ViewBag.Failedcount = item;
            }

            return View("Index");
        }
        public ActionResult UserLandingView()
        {
            return View();
        }
    }
}