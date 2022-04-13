using MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<Tbl_Skill> repo=new GenericRepository<Tbl_Skill>();
        public ActionResult Index()
        {
            var skills=repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Tbl_Skill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            Tbl_Skill t =repo.Find(x=>x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            Tbl_Skill t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Tbl_Skill p)
        {
            Tbl_Skill t =repo.Find(x=>x.Id == p.Id);
            t.Skill = p.Skill;
            t.Level = p.Level;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    
    }

    
}