using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepository<Tbl_SocialMedia> repo=new GenericRepository<Tbl_SocialMedia>();
        public ActionResult Index()
        {
            var socialmedia =repo.List();
            return View(socialmedia);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(Tbl_SocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var account = repo.Find(x=>x.ID == id);
            return View(account);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(Tbl_SocialMedia p)
        {
            Tbl_SocialMedia t = repo.Find(x => x.ID == p.ID);
            t.SocialName = p.SocialName;
            t.Situation = true;
            t.Link=p.Link;
            t.icon = p.icon;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(Tbl_SocialMedia p)
        {
            Tbl_SocialMedia t=repo.Find(x=>x.ID == p.ID);
            t.Situation = false;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}