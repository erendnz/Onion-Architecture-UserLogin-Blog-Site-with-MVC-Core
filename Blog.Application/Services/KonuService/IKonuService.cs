using Blog.Application.Models.DTOs.KonuDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.KonuService
{
    public interface IKonuService
    {
        Task<IEnumerable<KonuDTO>> TumAktifKonularAsync();
        Task KonuEkleAsync(KonuEkleDTO konu);
        Task KonuyuPasifHaleGetir(int id);
    }
}
