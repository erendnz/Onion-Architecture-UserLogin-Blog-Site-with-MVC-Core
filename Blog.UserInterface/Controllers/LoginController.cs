using Blog.Application.Models.DTOs.LoginDTOs;
using Blog.Application.Services.AppUserService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UserInterface.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUserService _service;

        public LoginController(IAppUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _service.LoginAsync(login);

            if (result.IsUser)
            {
                if (result.IsAdmin)
                    return RedirectToAction("Index", "Home", new { Area = "AdminPanel" });
                else
                    return RedirectToAction("Index", "Home", new { Area = "UyePanel" });
            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
