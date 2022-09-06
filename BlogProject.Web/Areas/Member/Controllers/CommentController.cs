using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly ILikeRepository likeRepository;
        private readonly ICommentRepository commentRepository;




        public CommentController(IArticleRepository articleRepository, ICommentRepository commentRepository, ILikeRepository likeRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.articleRepository = articleRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.likeRepository = likeRepository;
            this.commentRepository = commentRepository;

        }
        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Article article = articleRepository.GetDefault(a => a.ID == id);
            var comment = commentRepository.GetByDefault(
                selector: a => new CreateCommentVM()
                {
                    AppUserID = appUser.ID,
                    ArticleID = article.ID,
                    ArticleTitle = article.Title,
                },
                expression: a => a.Statu != Statu.Passive);
            return View(comment);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentVM comment)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await userManager.GetUserAsync(User);
                AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
                var article = articleRepository.GetDefault(a => a.ID == comment.ArticleID);
                Comment comentat = new Comment { AppUser = appUser, AppUserId = comment.AppUserID, Text = comment.Text, Article = article, ArticleId = article.ID, Statu = Statu.Passive };
                commentRepository.Create(comentat);
                return RedirectToAction("List");
            }
            return View(comment);
        }


        public async Task<IActionResult> List()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
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
                    },
                    expression: a => a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category).Include(a => a.Likes)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            // cookide olan kşinin kendi makalelerini çekeceğimiz için önce kişyi yakaladık.

            var commentList = commentRepository.GetByDefaults
                (
                    selector: a => new GetCommentVM()
                    {
                        CommentID = a.ID,
                        AppUserId = appUser.ID,
                        ArticleId = a.ArticleId,
                        Text = a.Text,
                        ArticleTitle = a.Article.Title,
                        UserName = a.AppUser.UserName,
                    },
                    expression: a => a.AppUserId == appUser.ID && a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Article)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(commentList);

        }

        public IActionResult Edit(int id)
        {
            Comment updated = commentRepository.GetDefault(a => a.ID == id);
            UpdateCommentVM vm = new UpdateCommentVM();
            vm.Text = updated.Text;
            vm.ID = updated.ID;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(UpdateCommentVM model)
        {
            Comment updated = commentRepository.GetDefault(a => a.ID == model.ID);
            updated.Text = model.Text;
            updated.ID = model.ID;
            updated.Statu = Statu.Passive;

            commentRepository.Update(updated);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var comment = commentRepository.GetByDefault
                (
                    selector: a => new GetCommentVM()
                    {
                        CommentID = a.ID,
                        AppUserId = a.AppUserId,
                        ArticleId = a.ArticleId,
                        Text = a.Text,
                        ArticleTitle = a.Article.Title,
                        UserName = a.AppUser.UserName,

                    },
                    expression: a => a.ID == id && a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Article)
                    //,orderBy: a=>a.OrderByDescending(a=>a.CreatedDate)
                );
            return View(comment);
        }
        [HttpPost]
        public IActionResult Delete(Comment comment)
        {
            Comment comment1 = commentRepository.GetDefault(a => a.ID == comment.ID);
            commentRepository.Delete(comment1);
            return RedirectToAction("List");
        }
    }
}
