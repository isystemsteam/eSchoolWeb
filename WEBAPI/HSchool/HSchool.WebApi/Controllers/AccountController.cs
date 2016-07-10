using HSchool.Authentication;
using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSchool.WebApi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name)
        {
            AuthenticationHelper.CreateUser("pariventhan1984@gmail.com","Enter321");
            AuthenticationHelper.GetUserByEmail("pariventhan1984@gmail.com", "pariventhan1984@gmail.com");
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}