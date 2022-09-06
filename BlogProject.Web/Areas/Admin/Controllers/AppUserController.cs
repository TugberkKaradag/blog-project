using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAppUserRepository appUserRepository;

        public AppUserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserRepository = appUserRepository;
        }

        public async Task<IActionResult> Index()
        {
            // identity user kişisi
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            if (appUser != null)
            {
                return View(appUser);
            }
            // return RedirectToAction("Index","Home"); // globaldeki home-index yani anasayfa
            return Redirect("~/");  // areasız başlangıç sayfasına yani home- index
        }
        public IActionResult List()
        {
            List<AppUser> list = appUserRepository.GetDefaults(a => a.Statu != Statu.Nothing);
            return View(list);
        }

        public  IActionResult Edit(int id)
        { 
            AppUser AppUser = appUserRepository.GetDefault(a => a.ID == id);
            return View(AppUser);
        }

        [HttpPost]
        public IActionResult Edit(AppUser dto)
        {   
            AppUser AppUser = appUserRepository.GetDefault(a => a.ID == dto.ID);
            AppUser.Statu = dto.Statu;
            appUserRepository.Update(AppUser);
            return RedirectToAction("List");
        }


        public IActionResult Detail(int id)
        {
            return View(appUserRepository.GetDefault(a => a.ID == id));
        }

        public IActionResult Delete(int id)
        {
            AppUser AppUser = appUserRepository.GetDefault(a => a.ID == id);
            return View(AppUser);
        }
        [HttpPost]
        public IActionResult Delete(AppUser AppUser)
        {
            AppUser AppUser1 = appUserRepository.GetDefault(a => a.ID == AppUser.ID);
            appUserRepository.Delete(AppUser1);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");  // areanın dışındaki anasayfa demiş olduk.
        }

    }
}
