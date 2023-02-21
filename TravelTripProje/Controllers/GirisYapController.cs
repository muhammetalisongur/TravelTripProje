using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Entity;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.hata = "Sifrenizi veya Kullanici Adiniz Hatali Girdiniz...";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }

        [HttpGet]
        public ActionResult YeniKullanici()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKullanici(Admin p)
        {
            c.Admins.Add(p);
            c.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}