using AutoMapper;
using Blog.Application.Models.DTOs.MakaleDTOs;
using Blog.Application.Models.VMs.MakaleVMs;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.MakaleService
{
    public class MakaleService : IMakaleService
    {
        private readonly IMakaleRepository _makaleRepository;
        private readonly IMapper _mapper;

        public MakaleService(IMakaleRepository makaleRepository, IMapper mapper)
        {
            _makaleRepository = makaleRepository;
            this._mapper = mapper;
        }

        // Belirli bir makalenin detayını getiren metod
        public async Task<MakaleDetayVM> MakaleDetayAsync(int id)
        {
            var makale = await _makaleRepository.TumunuFiltreleAsync(
                x => x,
                x => x.MakaleId == id,
                null,
                x => x.Include(x => x.Konu));

            MakaleDetayVM makaleDetay = new MakaleDetayVM();

            // AutoMapper kullanarak varlığı detay DTO'ya eşle
            _mapper.Map(makale.SingleOrDefault(), makaleDetay);

            return makaleDetay;
        }

        // Yeni bir makale ekleyen metod
        public async Task MakaleEkleAsync(MakaleEkleDTO makale)
        {
            Makale eklenecekMakale = new Makale();

            _mapper.Map(makale, eklenecekMakale);
            await _makaleRepository.EkleAsync(eklenecekMakale);
        }

        // Bir makaleyi pasif hale getiren metod
        public async Task MakaleyiPasifHaleGetir(int id)
        {
            await _makaleRepository.SilAsync(id);
        }

        // Bir makaleyi aktif hale getiren metod
        public async Task MakaleyiAktifHaleGetir(int id)
        {
            var makale = await _makaleRepository.BulAsync(id);
            await _makaleRepository.GuncelleAsync(makale);
        }

        // Tüm aktif makaleleri getiren metod
        public async Task<IEnumerable<MakaleVM>> TumAktifMakalelerAsync()
        {
            var makaleler = await _makaleRepository.TumunuFiltreleAsync(
                x => x,
                x => x.KayitDurumu == Domain.Enums.KayitDurumu.Aktif,
                x => x.OrderByDescending(x => x.EklemeTarih),
                x => x.Include(x => x.Konu));

            List<MakaleVM> makalelerVM = new List<MakaleVM>();

            _mapper.Map(makaleler, makalelerVM);

            return makalelerVM;
        }

        // Tüm makaleleri getiren metod (Admin görünümü için)
        public async Task<IEnumerable<AdminMakaleVM>> TumMakalelerAsync()
        {
            var makaleler = await _makaleRepository
                .TumunuGetir()
                .OrderByDescending(x => x.EklemeTarih)
                .Include(x => x.Konu)
                .ToListAsync();

            List<AdminMakaleVM> makalelerVM = new List<AdminMakaleVM>();

            // AutoMapper kullanarak varlıkları Admin VM'ye eşle
            _mapper.Map(makaleler, makalelerVM);

            return makalelerVM;
        }
    }
}
