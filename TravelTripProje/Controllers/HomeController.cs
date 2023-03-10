using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entity;

namespace TravelTripProje.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return View(degerler);
        }
        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Blogs.OrderBy(x => x.ID).Take(1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger);
        }
        public ActionResult Iletisim()
        {
            var degerler = c.AdresBlogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult GelenMaillerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GelenMaillerEkle(Iletisim p)
        {
            c.Iletisims.Add(p);
            c.SaveChanges();
            


            return RedirectToAction("/Iletisim");
        }

    }
}