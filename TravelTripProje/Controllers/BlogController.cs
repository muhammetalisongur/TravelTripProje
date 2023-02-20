using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;
using TravelTripProje.Models.Entity;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            by.deger1 = c.Blogs.ToList();
            by.deger3 = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            by.deger1 = c.Blogs.Where(x => x.ID == id);
            by.deger2 = c.Yorumlars.Where(x => x.BlogID == id);
            return View(by);
        }
    }
}