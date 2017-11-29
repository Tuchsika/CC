using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        ITShopEntities1 db = new ITShopEntities1();
        // GET: Account
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var a = db.Member.SingleOrDefault(x=>x.username == username && x.password == password);
            if (a != null)
            {
                Session["Email"] = a.username.ToString();
                Session["Fname"] = a.firstname.ToString();
                Session["Lname"] = a.lastname.ToString();
                Session["PM"] = a.permission.ToString();
            }
            else
            {
                ViewBag.SError = "รหัสผ่าน หรือ ชื่อผู้ใช้ไม่ถูกต้อง!";
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index","Home");
        }
       
    }
}