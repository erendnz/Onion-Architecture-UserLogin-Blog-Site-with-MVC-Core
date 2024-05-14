using AutoMapper;
using Blog.Application.Models.DTOs.KonuDTOs;
using Blog.Application.Models.DTOs.MakaleDTOs;
using Blog.Application.Models.VMs.MakaleVMs;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.AutoMapper
{
    public class BlogMapper : Profile
    {
        //Automapper işlemleri
        public BlogMapper()
        {
            CreateMap<Konu, KonuDTO>().ReverseMap();
            CreateMap<Konu, KonuEkleDTO>().ReverseMap();

            CreateMap<MakaleEkleDTO, Makale>().ReverseMap();

            CreateMap<MakaleVM, Makale>()
                .ReverseMap().ForMember(x => x.KonuAdi, x => x.MapFrom(x => x.Konu.KonuAdi));

            CreateMap<MakaleDetayVM, Makale>().ReverseMap()
                .ForMember(x => x.KonuAdi, x => x.MapFrom(x => x.Konu.KonuAdi));

            CreateMap<Makale, AdminMakaleVM>().ReverseMap();

        }
    }
}
