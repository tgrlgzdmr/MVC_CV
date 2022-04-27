using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class ProjectController : Controller
    {
        GenericRepository<Tbl_Project> repo = new GenericRepository<Tbl_Project>();
        // GET: Project
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Tbl_Project p)
        {
            //var x = "01/18/2022";
            //DateTime ti = Convert.ToDateTime(x);
            //p.Date = ti;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            Tbl_Project t=repo.Find(x=>x.Id==id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateProject(Tbl_Project p)
        {
            Tbl_Project t = repo.Find(x => x.Id == p.Id);
            t.Url = p.Url;
            t.Explanation = p.Explanation;
            t.Title = p.Title;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            Tbl_Project t = repo.Find(x=>x.Id== id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}