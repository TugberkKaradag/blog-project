using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlogProject.Web.Controllers
{
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;

        public ArticleController(IMapper mapper, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, IArticleRepository articleRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
        }

        public IActionResult List()
        {
            List<Article> list = articleRepository.GetDefaults(a => a.Statu != Statu.Passive);
            return View(list);
        }

        public IActionResult ListByCategory(int id)
        {
            List<Category> categories = categoryRepository.GetDefaults(a => a.ID == id);
            foreach (var item in categories)
            {
                var articleList = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = item.Name,
                        appUserId = a.AppUserId
                    },
                    expression: a => a.Statu != Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
                return View(articleList);
            }
            return View();
            

        }
        public IActionResult GetArticle(int id)
        {
            Article article = articleRepository.GetDefault(a => a.Statu != Statu.Passive && a.ID == id);
            return View(article);


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
                        CreatedDate = a.CreatedDate,
                        appUserId = a.AppUserId
                    },
                    expression: a => a.ID == id && a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Likes)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(article); ;
        }
    }
}
