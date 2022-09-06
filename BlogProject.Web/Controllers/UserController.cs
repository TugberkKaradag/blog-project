using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Models.DTOs;
using BlogProject.Web.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;


        public UserController(UserManager<IdentityUser> userManager, IMapper mapper, IAppUserRepository appUserRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }



        [HttpGet]
        public IActionResult Create(bool IsSuccess=false)
        {
            ViewBag.issuccess = IsSuccess;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            List<string> Mails = new List<string>();
            var userList = userManager.Users.ToList();
            foreach (var item in userList)
            {
                Mails.Add(item.Email);
            }
            var appList = appUserRepository.GetDefaults(a => a.Statu != Statu.Nothing && a.UserName == dto.UserName);
            if (ModelState.IsValid && appList.Count==0 && !Mails.Exists(a=>a.Equals(dto.Mail))) // validasyonlar tamamsa
            {
                string newId = Guid.NewGuid().ToString();
                IdentityUser identityUser = new IdentityUser { Email = dto.Mail, UserName = dto.UserName, Id = newId };           
                IdentityResult result = await userManager.CreateAsync(identityUser, dto.Password);
                if (result.Succeeded) // identity tarafında kişi oluşmuşsa
                {
                    await userManager.AddToRoleAsync(identityUser, "Member");

                    AppUser appUser = new AppUser();
                    appUser.FirstName = dto.FirstName;
                    appUser.LastName = dto.LastName;
                    appUser.Statu = Statu.Passive;

                    var user = mapper.Map<AppUser>(dto);
                    user.IdentityId = newId;  // identity kişisi ile appUser kişisini bağladık.

                    using var image = Image.Load(dto.Image.OpenReadStream()); // dosyayı oku al
                    image.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                    image.Save($"wwwroot/images/{user.UserName}.jpg");  // dosyayı images altına kaydet
                    user.ImagePath = $"/images/{user.UserName}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.

                    appUserRepository.Create(user);
                    ViewData["Hata"] = "Kayıt başarılı";
                    return RedirectToAction("Create", new {IsSuccess = true});
                }
            }
            ViewData["Hata"] = "Şifreniz -*!'^+%&/ işaretlerinden birini barındırmalıdır, kullanıcı adı ve mail özgün olmalıdır.";
            return View(dto);
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
                    //orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(articleList);
        }



    }
}
