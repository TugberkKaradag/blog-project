using BlogProject.Web.Models;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid) // validasyon tamamsa
            {
                IdentityUser identityUser =await  userManager.FindByEmailAsync(dto.Mail);

                if (identityUser!=null) // kullanıcı var - bu maile sahip biri var
                {
                   await  signInManager.SignOutAsync();  // içerde biri varsa cookiede silinsn
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(identityUser, dto.Password, true, true);
                    if (result.Succeeded) // şifrede doğru ise
                    {
                        string role = (await userManager.GetRolesAsync(identityUser)).FirstOrDefault();
                        return RedirectToAction("Index","AppUser", new { area=role });  // localHost/member/appuser/index - KAYITLI KULLANICI ANASAYFASI
                    }

                }
            }
            return View(dto);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
