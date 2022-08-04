using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAppUserRepository appUserRepository;

        public AppUserController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserRepository = appUserRepository;
        }

        public async Task<IActionResult> Index()
        {
            // identity user kişisi
            IdentityUser identityUser =await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a=>a.IdentityId==identityUser.Id);
            if (appUser!=null)
            {
                return View(appUser);
            }
           // return RedirectToAction("Index","Home"); // globaldeki home-index yani anasayfa
            return Redirect("~/");  // areasız başlangıç sayfasına yani home- index
        }


        public async Task<IActionResult> LogOut()
        {
          await  signInManager.SignOutAsync();
            return Redirect("~/");  // areanın dışındaki anasayfa demiş olduk.
        }

    }
}
