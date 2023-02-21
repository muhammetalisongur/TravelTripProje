using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entity;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();

        [Authorize]
        public ActionResult Index(int SayfaNo = 1)
        {
            var degerler = c.Blogs.OrderBy(x=>x.ID).ToPagedList(SayfaNo, 10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var degerler = c.Blogs.Find(id);
            c.Blogs.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var degerler = c.Blogs.Find(id);
            return View("BlogGetir", degerler);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var deger = c.Blogs.Find(b.ID);
            deger.Baslik = b.Baslik;
            deger.Aciklama = b.Aciklama;
            deger.BlogImage = b.BlogImage;
            deger.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var degerler = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        
        public ActionResult YorumGetir(int id)
        {
            var degerler = c.Yorumlars.Find(id);
            return View("YorumGetir", degerler);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var degerler = c.Yorumlars.Find(y.ID);
            degerler.KullaniciAdi = y.KullaniciAdi;
            degerler.Mail = y.Mail;
            degerler.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}