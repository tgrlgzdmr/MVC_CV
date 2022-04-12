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
    }
}