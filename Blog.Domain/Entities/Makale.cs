using Blog.Domain.Entities.Abstract;
using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Makale:IBaseEntity
    {
        public int MakaleId { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }



        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }


        //Makaleyi Ekleyen
        [ForeignKey("User")]
        public int MakaleEkleyenId { get; set; }
        public int KonuId { get; set; }

        public Konu Konu { get; set; }
        public AppUser User { get; set; }
    }
}
