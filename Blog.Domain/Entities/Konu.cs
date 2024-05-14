using Blog.Domain.Entities.Abstract;
using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Konu:IBaseEntity
    {
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }

        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }

        public ICollection<Makale>? Makaleler { get; set; }
    }
}
