using Blog.Application.Models.DTOs.UyeDTOs;
using Blog.Application.Services.AppUserService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UserInterface.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAppUserService _service;

        public RegisterController(IAppUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UyeKayitDTO yeniUye)
        {
            bool result = false;
            if (yeniUye.Password == yeniUye.ConfirmPassword)
            {
                result = await _service.RegisterAsync(yeniUye);
                //Kayit oldugunda ise...
                return RedirectToAction("Login", "Login");

            }

            ModelState.AddModelError("Sifre", "Sifre ve Sifre Tekrar aynı olmalı...");
            return View(yeniUye);
        }
    }
}
