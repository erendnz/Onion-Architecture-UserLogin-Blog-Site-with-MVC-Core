using Blog.Application.Services.MakaleService;
using Blog.Domain.Entities;
using Blog.UserInterface.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMakaleService _makaleService;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(IMakaleService makaleService,
              SignInManager<AppUser> signInManager)
        {
            _makaleService = makaleService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var makaleler = await _makaleService.TumAktifMakalelerAsync();
            return View(makaleler);
        }

        public async Task<IActionResult> MakaleDetay(int id)
        {
            var makaleDetay = await _makaleService.MakaleDetayAsync(id);
            makaleDetay.IsSignedUser = _signInManager.IsSignedIn(User);
            return View(makaleDetay);
        }
    }
}