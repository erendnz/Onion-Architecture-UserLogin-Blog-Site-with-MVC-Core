using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.UI.Areas.UyePanel.Models
{
    public class MakaleEkleVM
    {
        public string Baslik { get; set; }
        public string Detay { get; set; }

        public int KonuId { get; set; }
        public int MakaleEkleyenID { get; set; }

        public IFormFile ResimDosyasi { get; set; }
        public SelectList Konular { get; set; }
    }
}
