using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<Tbl_About> repo=new GenericRepository<Tbl_About>();
        // GET: About

        [HttpGet]
        public ActionResult Index()
        {
            var about=repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(Tbl_About p)
        {
            Tbl_About t = repo.Find(x => x.Id == 1);
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Explanation=p.Explanation;
            t.Picture = p.Picture;
            t.Mail = p.Mail;
            t.Name=p.Name;
            t.Phone = p.Phone;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}