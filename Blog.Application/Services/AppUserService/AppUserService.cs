using Blog.Application.Models.DTOs;
using Blog.Application.Models.DTOs.LoginDTOs;
using Blog.Application.Models.DTOs.UyeDTOs;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Kullanıcının ID'sini almak için bir yardımcı metot
        public int GetUserID(ClaimsPrincipal claims)
        {
            return int.Parse(_userManager.GetUserId(claims));
        }

        // Kullanıcı girişi işlemini gerçekleştiren metot
        public async Task<LoginReturnDTO> LoginAsync(LoginDTO login)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO() { IsUser = false, IsAdmin = false };

            // E-posta ile kullanıcıyı bul
            var user = await _userManager.FindByEmailAsync(login.Email);

            // Kullanıcı yoksa veya şifre eşleşmiyorsa, işlemi sonlandır
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                return returnDTO;

            await _signInManager.SignInAsync(user, true);

            returnDTO.IsUser = true;
            returnDTO.IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            return returnDTO;
        }

        // Kullanıcı çıkış işlemini gerçekleştiren metot
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        // Yeni kullanıcı kaydını gerçekleştiren metot
        public async Task<bool> RegisterAsync(UyeKayitDTO uye)
        {
            // Yeni bir kullanıcı oluştur
            AppUser user = new AppUser
            {
                UserName = uye.UserName,
                Ad = uye.Ad,
                Email = uye.Email,
                Soyad = uye.Soyad
            };

            // Şifreyi hashle ve kullanıcıyı oluştur
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, uye.Password);

            var result = await _userManager.CreateAsync(user);

            // Kullanıcıya "Uye" rolünü ata
            await _userManager.AddToRoleAsync(user, "Uye");

            return result.Succeeded;
        }

        // Kullanıcı güncelleme işlemini gerçekleştiren metot 
        public Task UyeGuncelleAsync(UyeGuncelleDTO uye)
        {
            throw new NotImplementedException();
        }
    }
}
