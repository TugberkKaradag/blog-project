using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Member.Models.DTOs
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
    }
}
