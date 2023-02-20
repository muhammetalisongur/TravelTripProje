using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Entity
{
    public class BlogYorum
    {
        //Enumerable: Belli sayidaki degerleri bir koleksiyon sinifinda toplayan yapidir.
        // birden fazla veriyi bir cshtml cekmekebiliriz.
        public IEnumerable<Blog> deger1 { get; set; }
        public IEnumerable<Yorumlar> deger2 { get; set; }
        public IEnumerable<Blog> deger3 { get; set; }
    }
}