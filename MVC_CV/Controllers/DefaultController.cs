using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_About.ToList();
            return View(values);
        }

        public PartialViewResult SocialMedia()
        {
            var socialmedia = db.Tbl_SocialMedia.Where(x=>x.Situation==true).ToList();
            return PartialView(socialmedia);
        }

        public PartialViewResult Experience()
        {
            var experiences = db.Tbl_Experience.ToList();
            return PartialView(experiences);
        }

        public PartialViewResult Education()
        {
            var educations = db.Tbl_Education.ToList();
            return PartialView(educations);
        }

        public PartialViewResult Skill()
        {
            var skills = db.Tbl_Skill.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Interest()
        {
            var intetersts = db.Tbl_Interest.ToList();
            return PartialView(intetersts);
        }

        public PartialViewResult Certificates()
        {
            var certificates = db.Tbl_Certificates.ToList();
            return PartialView(certificates);
        }

        public PartialViewResult Project()
        {
            var projects = db.Tbl_Project.OrderByDescending(x=>x.Id).ToList();
            return PartialView(projects);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Tbl_Contact t)
        {
            t.Date=DateTime.Now.ToShortDateString();
            db.Tbl_Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }

    }
}