using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Tbl_Education> repo = new GenericRepository<Tbl_Education>();
        // GET: Education

        
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Tbl_Education p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            Tbl_Education t =repo.Find(x=>x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            Tbl_Education t = repo.Find(x=>x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Tbl_Education p)
        {
            Tbl_Education t =repo.Find(x=>x.Id==p.Id);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Subtitle2=p.Subtitle2;
            t.GPA = p.GPA;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }


    }
}