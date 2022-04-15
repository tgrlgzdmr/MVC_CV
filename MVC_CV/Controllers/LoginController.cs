using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using System.Web.Security;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DbCVEntities db = new DbCVEntities();
            var info=db.Tbl_Admin.FirstOrDefault(x => x.UserName==p.UserName && x.Password==p.Password);
            if(info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["UserName"]=info.UserName.ToString();
                return RedirectToAction("Index","Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }


}