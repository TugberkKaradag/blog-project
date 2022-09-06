using AutoMapper;
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
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid) // validasyon tamamsa 
            {
                //Category category = new Category();
                //category.Name = dto.Name;
                //category.Description = dto.Description;

                var category = mapper.Map<Category>(dto);
                categoryRepository.Create(category);
                return RedirectToAction("List");

            }
            return View(dto);
        }

        public IActionResult List()
        {
            List<Category> list = categoryRepository.GetDefaults(a => a.Statu != Statu.Nothing);
            return View(list);
        }

        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            UpdateCategoryDTO dto = new UpdateCategoryDTO();
            dto.Description = category.Description;
            dto.Name = category.Name;
            dto.ID = category.ID;
            dto.Statu = category.Statu;

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryDTO dto)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == dto.ID);
            category.Name = dto.Name;
            category.Description = dto.Description;
            category.Statu = dto.Statu;
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

            category.UserFollowCategories.Add(new UserFollowCategory { Category = category, CategoryId = category.ID, AppUser = appUser, AppUserId = appUser.ID });

            categoryRepository.Update(category);
            return RedirectToAction("List");
        }


    }
}
