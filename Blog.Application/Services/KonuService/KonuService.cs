using AutoMapper;
using Blog.Application.Models.DTOs.KonuDTOs;
using Blog.Application.Models.DTOs.MakaleDTOs;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Abstract;
using Blog.Infrastructure.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.KonuService
{
    public class KonuService : IKonuService
    {
        private readonly IKonuRepository _konuRepository;
        private readonly IMapper _mapper;


        public KonuService(IKonuRepository konuRepository, IMapper mapper)
        {
            _konuRepository = konuRepository;
            _mapper = mapper;
        }

        // Tüm aktif konuları getiren metod
        public async Task<IEnumerable<KonuDTO>> TumAktifKonularAsync()
        {

            var konular = await _konuRepository.BulAsync(x => x.KayitDurumu == Domain.Enums.KayitDurumu.Aktif);

            // AutoMapper kullanarak varlıkları DTO'lara eşle
            IEnumerable<KonuDTO> liste = new List<KonuDTO>();
            return _mapper.Map(konular, liste);
        }

        // Yeni bir konu ekleyen metod
        public async Task KonuEkleAsync(KonuEkleDTO konu)
        {
            var eklenecekKonu = new Konu();
            _mapper.Map(konu, eklenecekKonu);

            await _konuRepository.EkleAsync(eklenecekKonu);
        }

        // Bir konuyu pasif hale getiren metod
        public async Task KonuyuPasifHaleGetir(int id)
        {
            await _konuRepository.SilAsync(id);
        }
    }
}
