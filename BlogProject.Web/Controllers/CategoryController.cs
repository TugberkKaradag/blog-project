using AutoMapper;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Web.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAppUserRepository appUserRepository;
        private readonly IArticleRepository articleRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository, UserManager<IdentityUser> userManager, IAppUserRepository appUserRepository, IArticleRepository articleRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
            this.appUserRepository = appUserRepository;
            this.articleRepository = articleRepository;
        }

        public IActionResult List()
        {
            List<Category> list = categoryRepository.GetDefaults(a => a.Statu != Statu.Passive);
            return View(list);
        }
        public IActionResult ListByCategory(int id)
        {
            Category category = categoryRepository.GetDefault(a => a.ID == id);
            GetCategoryForComponentDTO dto = new GetCategoryForComponentDTO();
            dto.Name = category.Name;
            dto.CreatedDate = category.CreatedDate;
            dto.Id = id;
            dto.Description = category.Description;

            return View(dto);
        }


    }
}
