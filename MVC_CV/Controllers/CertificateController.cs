using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<Tbl_Certificates> repo = new GenericRepository<Tbl_Certificates>();
        public ActionResult Index()
        {
            var certifica = repo.List();
            return View(certifica);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(Tbl_Certificates p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCertificate");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            Tbl_Certificates t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            Tbl_Certificates t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(Tbl_Certificates p)
        {
            Tbl_Certificates t = repo.Find(x => x.Id == p.Id);
            t.Explanation = p.Explanation;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}