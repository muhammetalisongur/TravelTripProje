using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Entity
{
    public class Yorumlar
    {
       [Key] public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; } // 1 yorum 1 blog icin // yorum eklemek istendigi zaman virtual olmadigi zaman yeni bir bos blog olusturacak bunun onune gecmek icin virtual kullanilir
    }
}