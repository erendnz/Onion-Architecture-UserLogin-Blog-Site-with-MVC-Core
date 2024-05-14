using Blog.Application.Services.AppUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog.UI.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Admin,Uye")]
    public class HomeController : Controller
    {

        private readonly IAppUserService _appUserService;

        public HomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
            
        }

    }
}
