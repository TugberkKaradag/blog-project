using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogProject.Web.Views.Shared.Components.Categories
{
    [ViewComponent(Name = "Categories")]
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryViewComponent(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var list = categoryRepository.GetByDefaults
                (
                    selector: a => new GetCategoryForComponentDTO()
                    {
                        Name = a.Name,
                        Description = a.Description,
                        CreatedDate = a.CreatedDate
                    },
                    expression: a => a.Statu != Model.Enums.Statu.Passive,
                    include: a => a.Include(a => a.Articles).Include(a => a.Articles),
                    orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                );

            return View(list.ToList());

        }

    }
}
