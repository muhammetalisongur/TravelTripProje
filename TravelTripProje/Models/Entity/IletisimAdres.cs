using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Entity
{
    public class IletisimAdres
    {
        public IEnumerable<AdresBlog> adresBlogs { get; set; }
        public IEnumerable<Iletisim> ıletisims { get; set; }
    }
}