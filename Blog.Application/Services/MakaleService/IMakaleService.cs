using Blog.Application.Models.DTOs.MakaleDTOs;
using Blog.Application.Models.VMs.MakaleVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.MakaleService
{
    public interface IMakaleService
    {
        Task MakaleEkleAsync(MakaleEkleDTO haber);
        Task<IEnumerable<MakaleVM>> TumAktifMakalelerAsync();
        Task<IEnumerable<AdminMakaleVM>> TumMakalelerAsync();

        Task<MakaleDetayVM> MakaleDetayAsync(int id);
        Task MakaleyiPasifHaleGetir(int id);
        Task MakaleyiAktifHaleGetir(int id);
    }
}
