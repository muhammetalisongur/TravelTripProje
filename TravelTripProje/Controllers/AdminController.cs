using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
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
            var degerler = c.Blogs.OrderByDescending(x => x.ID).ToPagedList(SayfaNo, 5);
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
            if (Request.Files.Count > 0)
            {
                string dosyaYolu = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaYolu;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BlogImage = "/Images/" + dosyaYolu;
                c.Blogs.Add(p);
                c.SaveChanges();
            }

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
            if (Request.Files.Count > 0)
            {
                string dosyaYolu = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaYolu;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                b.BlogImage = "/Images/" + dosyaYolu;

                var deger = c.Blogs.Find(b.ID);
                deger.Baslik = b.Baslik;
                deger.Aciklama = b.Aciklama;
                deger.BlogImage = b.BlogImage;
                deger.Tarih = b.Tarih;
                c.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi(int SayfaNo = 1)
        {
            var yorumlar = c.Yorumlars.OrderBy(x => x.ID).ToPagedList(SayfaNo, 5);
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

        public ActionResult Hakkimizda()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniHakkimizda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHakkimizda(Hakkimizda h)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaYolu = Path.GetFileName(Request.Files[1].FileName);
                string yol = "~/Images/" + dosyaYolu;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                h.FotoUrl = "/Images/" + dosyaYolu;
                c.Hakkimizdas.Add(h);
                c.SaveChanges();
            }

            return RedirectToAction("Hakkimizda");
        }

        public ActionResult HakkimizdaSil(int id)
        {
            var degerler = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var degerler = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", degerler);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaYolu = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/Images/" + dosyaYolu;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                h.FotoUrl = "/Images/" + dosyaYolu;

                var deger = c.Hakkimizdas.Find(h.ID);
                deger.Aciklama = h.Aciklama;
                deger.FotoUrl = h.FotoUrl;
                c.SaveChanges();

            }

            return RedirectToAction("Hakkimizda");
        }

        public ActionResult Iletisim()
        {
            var degerler = c.AdresBlogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniIletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIletisim(AdresBlog p)
        {
            c.AdresBlogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }

        public ActionResult IletisimSil(int id)
        {
            var degerler = c.AdresBlogs.Find(id);
            c.AdresBlogs.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }

        public ActionResult IletisimGetir(int id)
        {
            var degerler = c.AdresBlogs.Find(id);
            return View("IletisimGetir", degerler);
        }
        public ActionResult IletisimGuncelle(AdresBlog p)
        {
            var degerler = c.AdresBlogs.Find(p.ID);
            degerler.Baslik = p.Baslik;
            degerler.Aciklama = p.Aciklama;
            degerler.AdresAcik = p.AdresAcik;
            degerler.Mail = p.Mail;
            degerler.Telefon = p.Telefon;
         
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}