using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class InterestController : Controller
    {
        GenericRepository<Tbl_Interest> repo = new GenericRepository<Tbl_Interest>();
        // GET: Interest


        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }

        [HttpGet]
        public ActionResult UpdateInterest(int id)
        {
            Tbl_Interest t = repo.Find(x => x.Id == id);
            
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateInterest(Tbl_Interest p)
        {
            Tbl_Interest t = repo.Find(x => x.Id == p.Id);
            t.Explanation1 = p.Explanation1;
            t.Explanation2 = p.Explanation2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterest(int id)
        {
            Tbl_Interest t=repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInterest(Tbl_Interest p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

    }
}