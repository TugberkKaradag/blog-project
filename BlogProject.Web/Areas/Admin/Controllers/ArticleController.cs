using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly ILikeRepository likeRepository;


        public ArticleController(IArticleRepository articleRepository, ILikeRepository likeRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.likeRepository = likeRepository;
        }

        public async Task<IActionResult> Create()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            CreateArticleVM vm = new CreateArticleVM()
            {
                Categories = categoryRepository.GetByDefaults
                (
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.Passive

                 ),
                AppUserID = appUser.ID
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateArticleVM vm)
        {
            if (ModelState.IsValid)
            {
                var article = mapper.Map<Article>(vm);

                using var image = Image.Load(vm.Image.OpenReadStream()); // dosyayı oku al
                image.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                Guid guid = Guid.NewGuid();

                image.Save($"wwwroot/images/{guid}.jpg");  // dosyayı images altına kaydet
                article.ImagePath = $"/images/{guid}.jpg"; // ama biz kaydettiğimiz yolu veritabanında tutuyoruz.

                articleRepository.Create(article);
                return RedirectToAction("List");

            }
            // toDo: validasyon sağlanmadığında hataya düşmemek için httpgetteki gibi categories ve apppuser ıd dolmalı ki , null exception hatası vermesin ( selec optionslarda)
            return View(vm);
        }



        public async Task<IActionResult> List()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            // cookide olan kşinin kendi makalelerini çekeceğimiz için önce kişyi yakaladık.

            var articleList = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = a.Category.Name,
                        LikeCount = a.Likes.Count,
                        IsLiked = a.Likes.Any(),
                        Statu = a.Statu
                    },
                    expression: a => a.Statu != Model.Enums.Statu.Nothing,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Likes)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(articleList);

        }

        public IActionResult Edit(int id)
        {
            Article updated = articleRepository.GetDefault(a => a.ID == id);
            UpdateArticleVM vm = new UpdateArticleVM();
            vm.Title = updated.Title;
            vm.Content = updated.Content;
            vm.ImagePath = updated.ImagePath;
            vm.CategoryID = updated.CategoryId;
            vm.AppUserID = updated.AppUserId;
            vm.ID = updated.ID;
            vm.Statu = updated.Statu;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(UpdateArticleVM model)
        {

            Article updated = articleRepository.GetDefault(a => a.ID == model.ID);
            updated.Title = model.Title;
            updated.Content = model.Content;
            updated.ImagePath = model.ImagePath;
            updated.ID = model.ID;
            updated.Statu = model.Statu;
            articleRepository.Update(updated);
            return RedirectToAction("List");

        }

        public IActionResult Detail(int id)
        {
            var article = articleRepository.GetByDefault
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = a.Category.Name,
                        LikeCount = a.Likes.Count,
                        IsLiked = a.Likes.Any()
                    },
                    expression: a => a.ID == id && a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Likes)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(article); ;
        }

        public async Task<IActionResult> Like(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Article article = articleRepository.GetDefault(a => a.ID == id);
            if (article.Likes.Exists(a => a.AppUserId == appUser.ID))
            {
                return RedirectToAction("List");
            }
            else
            {
                article.Likes.Add(new Like { Article = article, ArticleId = article.ID, AppUser = appUser, AppUserId = appUser.ID });
                articleRepository.Update(article);
                ViewBag.Message = "Makale beğenildi.";
                return RedirectToAction("List");
            }

        }
        public async Task<IActionResult> Dislike(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Article article = articleRepository.GetDefault(a => a.ID == id);
            article.Likes.Remove(new Like { Article = article, ArticleId = article.ID, AppUser = appUser, AppUserId = appUser.ID });
            articleRepository.Update(article);
            ViewBag.Message = "Makalenin beğenilmesi kaldırıldı.";
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var article = articleRepository.GetDefault(a => a.ID == id && a.Statu != Statu.Passive);

            return View(article);
        }
        [HttpPost]
        public IActionResult Delete(Article article)
        {
            Article article1 = articleRepository.GetDefault(a => a.ID == article.ID);
            article1.Statu = Statu.Passive;
            articleRepository.Update(article1);
            return RedirectToAction("List");
        }
    }
}
