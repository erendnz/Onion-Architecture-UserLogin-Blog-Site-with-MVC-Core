using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Models.DTOs.MakaleDTOs
{
    public class MakaleEkleDTO
    {
        public string Baslik { get; set; }
        public string Detay { get; set; }

        public int KonuId { get; set; }
        public int MakaleEkleyenId { get; set; }
        public string ResimYolu { get; set; }
    }
}
