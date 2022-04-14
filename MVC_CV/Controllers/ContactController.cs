using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Tbl_Contact> repo=new GenericRepository<Tbl_Contact>();
        // GET: Contact
        public ActionResult Index()
        {
            var contact = repo.List();
            return View(contact);
        }
    }
}