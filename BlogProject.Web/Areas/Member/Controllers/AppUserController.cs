using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Member.Models.DTOs;
using BlogProject.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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
        private readonly IMapper mapper;
        private readonly IArticleRepository articleRepository;

        public AppUserController(UserManager<IdentityUser> userManager, IMapper mapper,IArticleRepository articleRepository, SignInManager<IdentityUser> signInManager, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserRepository = appUserRepository;
            this.mapper = mapper;
            this.articleRepository = articleRepository;
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

        public async Task<IActionResult> Edit()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            UpdateAppUserDTO dto = new UpdateAppUserDTO();
            dto.FirstName = appUser.FirstName;
            dto.LastName = appUser.LastName;
            dto.UserName = appUser.UserName;
            dto.Password = appUser.Password;
            dto.ID = appUser.ID;
            dto.Image = appUser.Image;
            dto.ImagePath = appUser.ImagePath;

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAppUserDTO dto)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.ID == dto.ID);
            appUser.FirstName = dto.FirstName;
            appUser.LastName = dto.LastName;
            appUser.UserName = dto.UserName;
            appUser.Password = dto.Password;
            appUser.ID = dto.ID;
            appUser.Image = dto.Image;
            using var imag = Image.Load(dto.Image.OpenReadStream()); // dosyayı oku al
            imag.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
            imag.Save($"wwwroot/images/{appUser.UserName}.jpg");  // dosyayı images altına kaydet
            appUser.ImagePath = $"/images/{appUser.UserName}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.
            appUserRepository.Update(appUser);
            return RedirectToAction("Index");

        }
        public IActionResult ProfilePage(int id)
        {
            AppUser appUser = appUserRepository.GetDefault(a => a.ID == id);
            var articleList = articleRepository.GetByDefault
                (
                    selector: a => new GetAppUserVM()
                    {
                        UserName = appUser.UserName,
                        AppUserId = appUser.ID,
                        Articles = a.AppUser.Articles,
                        ImagePathForAppUser = appUser.ImagePath,
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,
                        CreatedDate = appUser.CreatedDate,
                        ArticleCount = a.AppUser.Articles.Count(),

                    },
                    expression: a => a.Statu != Statu.Passive && a.AppUserId == id,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.AppUser)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(articleList);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");  // areanın dışındaki anasayfa demiş olduk.
        }

        public async Task<IActionResult> Delete()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            return View(appUser);
        }

        [HttpPost]
        public IActionResult Delete(AppUser app)
        {
            AppUser app1 = appUserRepository.GetDefault(a => a.ID == app.ID);
            appUserRepository.Delete(app1);
            return Redirect("~/");
        }
    }
}
