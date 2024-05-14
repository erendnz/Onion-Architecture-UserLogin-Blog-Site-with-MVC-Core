using AutoMapper;
using Blog.Application.Models.DTOs.MakaleDTOs;
using Blog.Application.Services.AppUserService;
using Blog.Application.Services.KonuService;
using Blog.Application.Services.MakaleService;
using Blog.UI.Areas.UyePanel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Blog.UI.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Admin,Uye")]
    public class MakaleController : Controller
    {
        private readonly IMakaleService _makaleService;
        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _userService;

        public MakaleController(IMakaleService makaleService, IKonuService konuService, IMapper mapper, IAppUserService userService)
        {
            _makaleService = makaleService;
            _konuService = konuService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            //Tum haberleri goster...
            var makaleler = await _makaleService.TumMakalelerAsync();

            return View(makaleler);
        }


        public async Task<IActionResult> MakaleEkle()
        {
            MakaleEkleVM makaleVM = new MakaleEkleVM();
            makaleVM.Konular = new SelectList(await _konuService.TumAktifKonularAsync(), "KonuId", "KonuAdi");

            return View(makaleVM);
        }

        [HttpPost]
        public async Task<IActionResult> MakaleEkle(MakaleEkleVM makale)
        {
            MakaleEkleDTO makaleDTO = new MakaleEkleDTO();

            makaleDTO.Baslik = makale.Baslik;
            makaleDTO.Detay = makale.Detay;
            makaleDTO.KonuId = makale.KonuId;

            makaleDTO.ResimYolu = makale.ResimDosyasi.FileName;

            FileStream fs = new FileStream("wwwroot/HaberResimleri/" + makale.ResimDosyasi.FileName, FileMode.Create);
            await makale.ResimDosyasi.CopyToAsync(fs);
            fs.Close();

            makaleDTO.MakaleEkleyenId = _userService.GetUserID(User);

            await _makaleService.MakaleEkleAsync(makaleDTO);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> MakaleSil(int id)
        {
            await _makaleService.MakaleyiPasifHaleGetir(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MakaleyiAktifEt(int id)
        {
            await _makaleService.MakaleyiAktifHaleGetir(id);
            return RedirectToAction("Index");
        }
    }
}
