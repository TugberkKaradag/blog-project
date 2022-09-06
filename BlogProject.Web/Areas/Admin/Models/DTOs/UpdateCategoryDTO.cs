using BlogProject.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string Description { get; set; }
        public Statu Statu { get; set; }
    }
}
