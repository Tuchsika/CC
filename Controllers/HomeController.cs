using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using PagedList.Mvc;
using PagedList;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        ITShopEntities1 db = new ITShopEntities1();
        // GET: Home
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 7;
            return View(db.Article.OrderByDescending(x=>x.Id).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Detail(int? id)
        {
            return View(db.Article.Find(id));
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ExampleClass ex)
        {
            Article at = new Article();
            at.Title = ex.Title;
            at.Detail = ex.HtmlContent;
            at.Date = DateTime.Now;
            at.username = Session["Email"].ToString();
            db.Article.Add(at);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string user, string pass, string fname, string lname)
        {
            if (db.Member.Where(x => x.username == user).Any())
            {
                ViewBag.ErrorNa = "ชื่อผู้ใช้ของคุณซ้ำโปรดลองชื่ออื่น";
                return View();
            }
            Member m = new Member()
            {
                username = user,
                password = pass,
                firstname = fname,
                lastname = lname
            };
            db.Member.Add(m);
            db.SaveChanges();
            return View("Successfully");
        }
        public ActionResult MyBoard()
        {
            string name = Session["Email"].ToString();
            var t = db.Article.Where(x=>x.username==name);
            return View(t.ToList());
        }
    }
}