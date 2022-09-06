using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Views.Shared.Components.Articles
{
    [ViewComponent(Name = "Articles")]
    public class ArticleViewComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;

        //bu componntte en güncel yazılan 10 makaleyi basalım.

        public ArticleViewComponent(IArticleRepository articleRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IdentityUser identityUser = await userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id && a.IdentityId != null);
            var list = articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleForComponentDTO()
                    {
                        Title = a.Title,
                        Content = a.Content,
                        ArticleID = a.ID,
                        UserId = a.AppUser.ID,
                        UserFullName = a.AppUser.FullName,
                        UserImagePath = a.AppUser.ImagePath,
                        Image = a.ImagePath,
                        CreatedDate = a.CreatedDate,
                        CategoryName = a.Category.Name,
                        Comments = a.Comments,
                        Likes = a.Likes,
                        LikeCount = a.Likes.Count(),
                        ConsumeTime = a.Content.Length / 100
                    },
                    expression: a => a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Comments).Include(a => a.Likes),
                    orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                );
            foreach (var item in list)
            {
                if (item.Likes.Exists(a => a.ArticleId == item.ArticleID && a.AppUserId == appUser.ID))
                {
                    item.IsLiked = true;
                }
                else
                {
                    item.IsLiked = false;
                }
            }
            return View(list.Take(10).ToList());

        }

    }
}
