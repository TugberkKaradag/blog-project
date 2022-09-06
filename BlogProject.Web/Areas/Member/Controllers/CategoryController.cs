using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Member.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]

    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IUserFollowCategoryRepository userFollowCategoryRepository;
        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, IUserFollowCategoryRepository userFollowCategoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.userFollowCategoryRepository = userFollowCategoryRepository;
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            var categoryList = categoryRepository.GetDefaults(a => a.Statu != Statu.Nothing && a.Name == dto.Name);

            if (ModelState.IsValid && categoryList.Count==0) // validasyon tamamsa 
            {
                Category category = new Category();
                category.Name = dto.Name;
                category.Description = dto.Description;
                category.CreatedDate = DateTime.Now;
                category.Statu = Statu.Passive;

                categoryRepository.Create(category);
                return RedirectToAction("List");

            }
            return View(dto);
        }

        public async Task<IActionResult> List()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            var category1 = categoryRepository.GetByDefaults(selector: a => new GetCategoryForFollowsDTO()
            {
                ID = a.ID,
                AppuserId = appUser.ID,
                Name = a.Name,
                UserFollowCategories = a.UserFollowCategories.ToList(),
                IsFollowing = a.UserFollowCategories.Any()
            },
            expression: a => a.Statu != Statu.Passive,
            include: a => a.Include(a => a.UserFollowCategories).Include(a => a.Articles)
            );


            return View(category1);
        }

        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            UpdateCategoryDTO dto = new UpdateCategoryDTO();
            dto.Description = category.Description;
            dto.Name = category.Name;
            dto.ID = category.ID;

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryDTO dto)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == dto.ID);
            category.Name = dto.Name;
            category.Description = dto.Description;
            categoryRepository.Update(category);
            return RedirectToAction("List");
        }

        //toDo: bu controllerın detay,sil,guncellesi sizdedir.

        //TODO: kullanıcı bir kategoriyi takip ediyoersa TAKİBİ BIRAK , etmiyorsa TAKİP ET yazmalı List yapıısnın viewında :)

        public IActionResult Detail(int id)
        {
            return View(categoryRepository.GetDefault(a => a.ID == id));

        }

        public IActionResult Delete(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            Category category1 = categoryRepository.GetDefault(a => a.ID == category.ID);
            categoryRepository.Delete(category1);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Follow(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            var category1 = categoryRepository.GetByDefault(selector: a => new GetCategoryForFollowsDTO()
            {
                ID = id,
                Name = a.Name,
                AppuserId = appUser.ID,
                UserFollowCategories = a.UserFollowCategories,
                IsFollowing = a.UserFollowCategories.Any(),
            },
            expression: a => a.ID == id && a.Statu != Statu.Passive,
            include: a => a.Include(a => a.UserFollowCategories).Include(a => a.Articles)
            );

            if (category1.UserFollowCategories.Exists(a => a.AppUserId == appUser.ID && a.CategoryId == id))
            {
                category1.IsFollowing = true;
            }
            else
            {
                category1.IsFollowing = false;
            }

            if (category1.IsFollowing == true)
            {
                return RedirectToAction("List");

            }
            else
            {
                category.UserFollowCategories.Add(new UserFollowCategory { Category = category, CategoryId = category.ID, AppUser = appUser, AppUserId = appUser.ID });
                categoryRepository.Update(category);
                ViewBag.Message = "Takip ediliyor.";
                return RedirectToAction("List");
            }
        }
        public async Task<IActionResult> Unfollow(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            var category1 = categoryRepository.GetByDefault(selector: a => new GetCategoryForFollowsDTO()
            {
                ID = id,
                Name = a.Name,
                AppuserId = appUser.ID,
                UserFollowCategories = a.UserFollowCategories.ToList(),
            },
            expression: a => a.ID == id && a.Statu != Statu.Passive,
            include: a => a.Include(a => a.UserFollowCategories).Include(a => a.Articles)
            ) ;
            if (category1.UserFollowCategories.Exists(a => a.AppUserId == appUser.ID && a.CategoryId == id))
            {
                category1.IsFollowing = true;
            }
            else
            {
                category1.IsFollowing = false;
            }
            if (category1.IsFollowing == false)
            {
                return RedirectToAction("List");
            }
            else
            {
                var unfollow = category1.UserFollowCategories.Find(a => a.AppUserId == appUser.ID && a.CategoryId == id);
                userFollowCategoryRepository.Delete(unfollow);
                categoryRepository.Update(category);
                ViewBag.Message = "Takip ediliyor.";
                return RedirectToAction("List");
            }
        }
    }
}
