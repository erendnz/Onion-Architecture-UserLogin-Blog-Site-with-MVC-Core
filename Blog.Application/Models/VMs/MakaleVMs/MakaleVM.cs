using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.VMs.MakaleVMs
{
    public class MakaleVM
    {
        public int MakaleId { get; set; }
        public string Baslik { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }

        public DateTime EklemeTarih { get; set; }

        public string KonuAdi { get; set; }
    }
}
