using BlogProject.Model.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class UpdateAppUserDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(30)]
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
