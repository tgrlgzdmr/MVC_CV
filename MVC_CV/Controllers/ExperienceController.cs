using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var experiences = repo.List();
            return View(experiences);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Tbl_Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Tbl_Experience t =repo.Find(x=>x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Tbl_Experience t =repo.Find(x=>x.Id==id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Tbl_Experience p)
        {
            Tbl_Experience t = repo.Find(x => x.Id == p.Id);
            t.Subtitle = p.Subtitle;
            t.Title = p.Title;
            t.Explanation=p.Explanation;
            t.Date=p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}