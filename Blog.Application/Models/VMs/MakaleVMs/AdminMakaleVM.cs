using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.VMs.MakaleVMs
{
    public class AdminMakaleVM
    {
        public int MakaleId { get; set; }
        public string Baslik { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }

        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }

        public string MakaleEkleyen { get; set; }
        public string KonuAdi { get; set; }
    }
}
