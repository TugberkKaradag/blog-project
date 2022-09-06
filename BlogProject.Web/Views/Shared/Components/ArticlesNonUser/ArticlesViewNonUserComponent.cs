namespace BlogProject.Web.Views.Shared.Components.Articles.ArticlesNonUser
{
    using global::BlogProject.Dal.Repositories.Interfaces.Concrete;
    using global::BlogProject.Web.Models.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    namespace BlogProject.Web.Views.Shared.Components.ArticlesNonUser
    {
        [ViewComponent(Name = "ArticlesNonUser")]
        public class ArticlesViewNonUserComponent : ViewComponent
        {
            private readonly IArticleRepository articleRepository;

            //bu componntte en güncel yazılan 10 makaleyi basalım.

            public ArticlesViewNonUserComponent(IArticleRepository articleRepository)
            {
                this.articleRepository = articleRepository;
            }
            public IViewComponentResult Invoke()
            {
                var list = articleRepository.GetByDefaults
                    (
                        selector: a => new GetArticleForNonUserComponentDTO()
                        {
                            Title = a.Title,
                            Content = a.Content,
                            ArticleID = a.ID,
                            UserId = a.AppUser.ID,
                            UserFullName = a.AppUser.FullName,
                            Image = a.ImagePath,
                            CreatedDate = a.CreatedDate,
                            CategoryName = a.Category.Name,
                            ConsumeTime = a.Content.Length / 100,
                            Likes = a.Likes,
                            LikeCount = a.Likes.Count()
                        },
                        expression: a => a.Statu != Model.Enums.Statu.Passive,
                        include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Likes),
                        orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                    );

                return View(list.Take(10).ToList());

            }

        }
    }
}
