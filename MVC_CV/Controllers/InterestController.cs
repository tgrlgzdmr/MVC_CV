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

        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Interest p)
        {
            Tbl_Interest t = repo.Find(x => x.Id == 1);
            t.Explanation1 = p.Explanation1;
            t.Explanation2 = p.Explanation2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}