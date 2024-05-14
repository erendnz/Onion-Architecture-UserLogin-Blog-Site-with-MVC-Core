using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.VMs.KonuVMs
{
    public class AdminKonuVM
    {
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }
      
        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }
    }
}
