using AutoMapper;
using Blog.Application.Models.DTOs.KonuDTOs;
using Blog.Application.Services.AppUserService;
using Blog.Application.Services.KonuService;
using Blog.Domain.Entities;
using Blog.UI.Areas.AdminPanel.Models;
using Blog.UI.Areas.UyePanel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Blog.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class KonuController : Controller
    {

        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;

        public KonuController(IKonuService konuService, IMapper mapper)
        {
            _konuService = konuService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //Tum konuları goster...
            var konular = await _konuService.TumAktifKonularAsync();

            return View(konular);
        }

        public IActionResult KonuEkle()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> KonuEkle(KonuEkleDTO konu)
        {
            await _konuService.KonuEkleAsync(konu);

            return RedirectToAction("Index");
        }

        public IActionResult KonuSil()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KonuSil(int id)
        {
            await _konuService.KonuyuPasifHaleGetir(id);
            return RedirectToAction("Index");
        }
    }
}
